using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using SQLite_Connection;

namespace SafariRetail.InventorySystem
{
    public partial class Form1 : Form
    {
        private string _activeDatabasePath = string.Empty;
        private DatabaseHelper db = new DatabaseHelper();

        public Form1()
        {
            InitializeComponent();
            ApplyEnterpriseStyling();

            this.Text = $"Safari Retail Asset Manager | Operator: {LoginForm.LoggedInUser}";
        }

        private void ApplyEnterpriseStyling()
        {
            this.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            Color safariNavy = Color.FromArgb(0, 51, 102);

            Btn_Select_DB.BackColor = safariNavy;
            Btn_Select_DB.ForeColor = Color.White;
            Btn_Select_DB.FlatStyle = FlatStyle.Flat;

            Btn_Load_Data.BackColor = safariNavy;
            Btn_Load_Data.ForeColor = Color.White;
            Btn_Load_Data.FlatStyle = FlatStyle.Flat;

            Btn_Logout.BackColor = safariNavy;
            Btn_Logout.ForeColor = Color.White;
            Btn_Logout.FlatStyle = FlatStyle.Flat;

            Label_Total_Value.ForeColor = Color.FromArgb(0, 102, 0);
            Label_Total_Value.Font = new Font("Segoe UI", 11, FontStyle.Bold);

            // REFINEMENT: Makes the grid look like a solid "unit" by removing the grey area
            DataGrid_Inventory.BackgroundColor = Color.White;
            DataGrid_Inventory.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 250, 255);

            // OPTIONAL: Removes the dark border for a flatter, modern look
            DataGrid_Inventory.BorderStyle = BorderStyle.None;
        }

        private void Btn_Logout_Click(object sender, EventArgs e)
        {
            var confirmLogout = MessageBox.Show("Are you sure you want to log out, Evans?",
                "Safari Retail | Session Management",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmLogout == DialogResult.Yes)
            {
                this.Hide();
                LoginForm login = new LoginForm();
                login.Show();
            }
        }

        private void InitializeDataSync()
        {
            DataTable inventoryTable = db.GetAllProducts();
            DataGrid_Inventory.DataSource = inventoryTable;

            ExecuteFinancialValuation();
            HighlightLowStock();

            Label_Last_Synced.Text = $"Last Synced: {DateTime.Now:HH:mm:ss}";
            Label_Last_Synced.ForeColor = Color.DarkSlateBlue;

            if (inventoryTable.Rows.Count > 0)
            {
                MessageBox.Show($"{inventoryTable.Rows.Count} items synced from database.",
                                "Safari Retail | Data Sync",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
        }

        private void HighlightLowStock()
        {
            foreach (DataGridViewRow row in DataGrid_Inventory.Rows)
            {
                if (row.Cells["currentStock"].Value != null && row.Cells["currentStock"].Value != DBNull.Value)
                {
                    int stock = Convert.ToInt32(row.Cells["currentStock"].Value);

                    if (stock < 5)
                    {
                        row.DefaultCellStyle.BackColor = Color.LightPink;
                        row.Cells["currentStock"].Style.ForeColor = Color.Red;
                        row.Cells["currentStock"].Style.Font = new Font(DataGrid_Inventory.Font, FontStyle.Bold);
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.White;
                        row.Cells["currentStock"].Style.ForeColor = Color.Black;
                        row.Cells["currentStock"].Style.Font = new Font(DataGrid_Inventory.Font, FontStyle.Regular);
                    }
                }
            }
        }

        private void ExecuteFinancialValuation()
        {
            double aggregateValue = 0;
            foreach (DataGridViewRow row in DataGrid_Inventory.Rows)
            {
                if (row.IsNewRow) continue;
                if (row.Cells["currentStock"].Value != DBNull.Value && row.Cells["price"].Value != DBNull.Value)
                {
                    aggregateValue += (Convert.ToDouble(row.Cells["currentStock"].Value) * Convert.ToDouble(row.Cells["price"].Value));
                }
            }
            Label_Total_Value.Text = $"Total Inventory Value: KES {aggregateValue:N2}";
        }

        private void Btn_Select_DB_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dbSelector = new OpenFileDialog())
            {
                dbSelector.Title = "Select Safari Inventory Database";
                dbSelector.Filter = "SQLite Database (*.db)|*.db|All Files (*.*)|*.*";

                if (dbSelector.ShowDialog() == DialogResult.OK)
                {
                    _activeDatabasePath = dbSelector.FileName;
                    TextBox_Database_Path.Text = _activeDatabasePath;
                    TextBox_Database_Name.Text = Path.GetFileName(_activeDatabasePath);

                    MessageBox.Show($"Successfully linked to database: {TextBox_Database_Name.Text}",
                                    "Safari Retail | Connection",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
            }
        }

        private void Button_Clear_Search_Click(object sender, EventArgs e)
        {
            TextBox_Search.Clear();
            if (DataGrid_Inventory.DataSource is DataTable dt)
            {
                dt.DefaultView.RowFilter = string.Empty;
                ExecuteFinancialValuation();
            }
        }

        private void Btn_Export_CSV_Click(object sender, EventArgs e)
        {
            if (DataGrid_Inventory.DataSource == null || DataGrid_Inventory.Rows.Count == 0)
            {
                MessageBox.Show("No data available to export.", "Export Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string fileName = $"Safari_Inventory_{DateTime.Now:yyyyMMdd_HHmm}.csv";
                string fullPath = Path.Combine(desktopPath, fileName);

                using (StreamWriter sw = new StreamWriter(fullPath))
                {
                    DataTable dt = (DataTable)DataGrid_Inventory.DataSource;
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        sw.Write(dt.Columns[i].ColumnName + (i < dt.Columns.Count - 1 ? "," : ""));
                    }
                    sw.WriteLine();

                    foreach (DataRow row in dt.Rows)
                    {
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            sw.Write(row[i].ToString() + (i < dt.Columns.Count - 1 ? "," : ""));
                        }
                        sw.WriteLine();
                    }
                }

                MessageBox.Show($"CSV Report successfully exported to Desktop:\n{fileName}",
                                "Safari Retail | Export Success",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Export Failed: " + ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_Load_Data_Click(object sender, EventArgs e)
        {
            InitializeDataSync();
        }

        private void TextBox_Search_TextChanged(object sender, EventArgs e)
        {
            if (DataGrid_Inventory.DataSource is DataTable dt)
            {
                dt.DefaultView.RowFilter = string.Format("itemName LIKE '%{0}%'", TextBox_Search.Text);
                ExecuteFinancialValuation();
                HighlightLowStock();
            }
        }
    }
}