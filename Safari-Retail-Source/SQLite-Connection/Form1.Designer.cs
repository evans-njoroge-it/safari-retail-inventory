namespace SafariRetail.InventorySystem
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            Btn_Select_DB = new Button();
            TextBox_Database_Path = new TextBox();
            label1 = new Label();
            label2 = new Label();
            TextBox_Database_Name = new TextBox();
            Btn_Load_Data = new Button();
            TextBox_DB_Connection_String = new TextBox();
            label3 = new Label();
            label4 = new Label();
            TextBox_SQL_Query_Executed = new TextBox();
            DataGrid_Inventory = new DataGridView();
            TextBox_Search = new TextBox();
            Button_Clear_Search = new Button();
            Label_Total_Value = new Label();
            label_search_hint = new Label();
            Btn_Export_CSV = new Button();
            Btn_Logout = new Button();
            Label_Last_Synced = new Label();
            ((System.ComponentModel.ISupportInitialize)DataGrid_Inventory).BeginInit();
            SuspendLayout();
            // 
            // Btn_Select_DB
            // 
            Btn_Select_DB.Location = new Point(15, 61);
            Btn_Select_DB.Name = "Btn_Select_DB";
            Btn_Select_DB.Size = new Size(212, 74);
            Btn_Select_DB.TabIndex = 14;
            Btn_Select_DB.Text = "Select Database";
            Btn_Select_DB.Click += Btn_Select_DB_Click;
            // 
            // TextBox_Database_Path
            // 
            TextBox_Database_Path.Location = new Point(354, 61);
            TextBox_Database_Path.Name = "TextBox_Database_Path";
            TextBox_Database_Path.Size = new Size(806, 31);
            TextBox_Database_Path.TabIndex = 13;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(236, 67);
            label1.Name = "label1";
            label1.Size = new Size(82, 25);
            label1.TabIndex = 1;
            label1.Text = "Full Path:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(236, 107);
            label2.Name = "label2";
            label2.Size = new Size(94, 25);
            label2.TabIndex = 2;
            label2.Text = "File Name:";
            // 
            // TextBox_Database_Name
            // 
            TextBox_Database_Name.Location = new Point(354, 104);
            TextBox_Database_Name.Name = "TextBox_Database_Name";
            TextBox_Database_Name.Size = new Size(403, 31);
            TextBox_Database_Name.TabIndex = 5;
            // 
            // Btn_Load_Data
            // 
            Btn_Load_Data.Location = new Point(15, 149);
            Btn_Load_Data.Name = "Btn_Load_Data";
            Btn_Load_Data.Size = new Size(115, 71);
            Btn_Load_Data.TabIndex = 12;
            Btn_Load_Data.Text = "Load Data Sync";
            Btn_Load_Data.Click += Btn_Load_Data_Click;
            // 
            // TextBox_DB_Connection_String
            // 
            TextBox_DB_Connection_String.Location = new Point(354, 149);
            TextBox_DB_Connection_String.Name = "TextBox_DB_Connection_String";
            TextBox_DB_Connection_String.Size = new Size(806, 31);
            TextBox_DB_Connection_String.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(233, 152);
            label3.Name = "label3";
            label3.Size = new Size(106, 25);
            label3.TabIndex = 3;
            label3.Text = "Connection:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(233, 192);
            label4.Name = "label4";
            label4.Size = new Size(101, 25);
            label4.TabIndex = 4;
            label4.Text = "SQL Query:";
            // 
            // TextBox_SQL_Query_Executed
            // 
            TextBox_SQL_Query_Executed.Location = new Point(354, 189);
            TextBox_SQL_Query_Executed.Name = "TextBox_SQL_Query_Executed";
            TextBox_SQL_Query_Executed.Size = new Size(806, 31);
            TextBox_SQL_Query_Executed.TabIndex = 7;
            // 
            // DataGrid_Inventory
            // 
            DataGrid_Inventory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGrid_Inventory.ColumnHeadersHeight = 34;
            DataGrid_Inventory.Location = new Point(15, 260);
            DataGrid_Inventory.Name = "DataGrid_Inventory";
            DataGrid_Inventory.RowHeadersWidth = 62;
            DataGrid_Inventory.Size = new Size(1145, 395);
            DataGrid_Inventory.TabIndex = 11;
            // 
            // TextBox_Search
            // 
            TextBox_Search.Location = new Point(180, 15);
            TextBox_Search.Name = "TextBox_Search";
            TextBox_Search.Size = new Size(159, 31);
            TextBox_Search.TabIndex = 10;
            TextBox_Search.TextChanged += TextBox_Search_TextChanged;
            // 
            // Button_Clear_Search
            // 
            Button_Clear_Search.Location = new Point(354, 15);
            Button_Clear_Search.Name = "Button_Clear_Search";
            Button_Clear_Search.Size = new Size(68, 34);
            Button_Clear_Search.TabIndex = 9;
            Button_Clear_Search.Text = "Clear";
            Button_Clear_Search.Click += Button_Clear_Search_Click;
            // 
            // Label_Total_Value
            // 
            Label_Total_Value.Location = new Point(15, 680);
            Label_Total_Value.Name = "Label_Total_Value";
            Label_Total_Value.Size = new Size(600, 35);
            Label_Total_Value.TabIndex = 8;
            Label_Total_Value.Text = "Total Inventory Value: KES 0.00";
            // 
            // label_search_hint
            // 
            label_search_hint.AutoSize = true;
            label_search_hint.Location = new Point(15, 18);
            label_search_hint.Name = "label_search_hint";
            label_search_hint.Size = new Size(148, 25);
            label_search_hint.TabIndex = 0;
            label_search_hint.Text = "Search Inventory:";
            // 
            // Btn_Export_CSV
            // 
            Btn_Export_CSV.BackColor = Color.FromArgb(0, 51, 102);
            Btn_Export_CSV.FlatStyle = FlatStyle.Flat;
            Btn_Export_CSV.ForeColor = Color.White;
            Btn_Export_CSV.Location = new Point(136, 149);
            Btn_Export_CSV.Name = "Btn_Export_CSV";
            Btn_Export_CSV.Size = new Size(88, 71);
            Btn_Export_CSV.TabIndex = 15;
            Btn_Export_CSV.Text = "Export to CSV";
            Btn_Export_CSV.UseVisualStyleBackColor = false;
            Btn_Export_CSV.Click += Btn_Export_CSV_Click;
            // 
            // Btn_Logout
            // 
            Btn_Logout.BackColor = Color.FromArgb(0, 51, 102);
            Btn_Logout.FlatStyle = FlatStyle.Flat;
            Btn_Logout.Font = new Font("Segoe UI Semibold", 9F);
            Btn_Logout.ForeColor = Color.White;
            Btn_Logout.Location = new Point(1050, 12);
            Btn_Logout.Name = "Btn_Logout";
            Btn_Logout.Size = new Size(110, 40);
            Btn_Logout.TabIndex = 16;
            Btn_Logout.Text = "Logout";
            Btn_Logout.UseVisualStyleBackColor = false;
            Btn_Logout.Click += Btn_Logout_Click;
            // 
            // Label_Last_Synced
            // 
            Label_Last_Synced.AutoSize = true;
            Label_Last_Synced.Font = new Font("Microsoft Sans Serif", 9F);
            Label_Last_Synced.ForeColor = Color.DimGray;
            Label_Last_Synced.Location = new Point(15, 235);
            Label_Last_Synced.Name = "Label_Last_Synced";
            Label_Last_Synced.Size = new Size(131, 22);
            Label_Last_Synced.TabIndex = 17;
            Label_Last_Synced.Text = "Last Synced: --";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 726);
            Controls.Add(Label_Last_Synced);
            Controls.Add(Btn_Logout);
            Controls.Add(Btn_Export_CSV);
            Controls.Add(label_search_hint);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(TextBox_Database_Name);
            Controls.Add(TextBox_DB_Connection_String);
            Controls.Add(TextBox_SQL_Query_Executed);
            Controls.Add(Label_Total_Value);
            Controls.Add(Button_Clear_Search);
            Controls.Add(TextBox_Search);
            Controls.Add(DataGrid_Inventory);
            Controls.Add(Btn_Load_Data);
            Controls.Add(TextBox_Database_Path);
            Controls.Add(Btn_Select_DB);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Safari Retail Asset Manager | Operator: Evans";
            ((System.ComponentModel.ISupportInitialize)DataGrid_Inventory).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Btn_Select_DB;
        private TextBox TextBox_Database_Path;
        private Label label1;
        private Label label2;
        private TextBox TextBox_Database_Name;
        private Button Btn_Load_Data;
        private TextBox TextBox_DB_Connection_String;
        private Label label3;
        private Label label4;
        private TextBox TextBox_SQL_Query_Executed;
        private DataGridView DataGrid_Inventory;
        private TextBox TextBox_Search;
        private Button Button_Clear_Search;
        private Label Label_Total_Value;
        private Label label_search_hint;
        private Button Btn_Export_CSV;
        private Button Btn_Logout;
        private Label Label_Last_Synced;
    }
}