using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace SQLite_Connection
{
    internal class DatabaseHelper
    {
        // Using relative path for the database file to ensure portability
        private string connectionString = @"Data Source=.\SafariInventory.db;Version=3;";

        public DatabaseHelper()
        {
            InitializeDatabase();
        }

        public void InitializeDatabase()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                // 1. Create Tables: Users and Products
                string createTablesSql = @"
                    CREATE TABLE IF NOT EXISTS Users (
                        UserID INTEGER PRIMARY KEY AUTOINCREMENT,
                        Username TEXT NOT NULL UNIQUE,
                        Password TEXT NOT NULL
                    );
                    CREATE TABLE IF NOT EXISTS Products (
                        itemSKU TEXT PRIMARY KEY,
                        itemName TEXT,
                        currentStock INTEGER,
                        price REAL
                    );";

                using (SQLiteCommand cmd = new SQLiteCommand(createTablesSql, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                // 2. Seed Default User: Evans (Matches Operator Login)
                string seedUserSql = "INSERT OR IGNORE INTO Users (Username, Password) VALUES ('Evans', 'Admin123')";
                using (SQLiteCommand cmd = new SQLiteCommand(seedUserSql, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                // 3. Seed Inventory Data: Ensures the grid populates on 'Sync'
                string checkProductsSql = "SELECT COUNT(1) FROM Products";
                using (SQLiteCommand cmd = new SQLiteCommand(checkProductsSql, conn))
                {
                    int productCount = Convert.ToInt32(cmd.ExecuteScalar());
                    if (productCount == 0)
                    {
                        // Data matches your project evidence
                        string insertProductsSql = @"
                            INSERT INTO Products (itemSKU, itemName, currentStock, price) VALUES 
                            ('SKU-1001', 'Ubiquiti Solar Beam', 15, 25500.00),
                            ('SKU-1002', 'Deep Cycle Battery 200Ah', 3, 32000.00), -- Triggers Pink Alert
                            ('SKU-1003', 'Charge Controller 60A', 4, 12500.00),  -- Triggers Pink Alert
                            ('SKU-1004', 'Inverter 3KW Hybrid', 8, 85000.00);";

                        using (SQLiteCommand insertCmd = new SQLiteCommand(insertProductsSql, conn))
                        {
                            insertCmd.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        public DataTable GetAllProducts()
        {
            DataTable dt = new DataTable();
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                // Query structured for DataGrid headers
                string sql = "SELECT itemSKU, itemName, currentStock, price FROM Products";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            return dt;
        }

        public bool ValidateUser(string username, string password)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Secure parameterized query for the Login Form
                    string sql = "SELECT COUNT(1) FROM Users WHERE Username = @user AND Password = @pass";
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@user", username);
                        cmd.Parameters.AddWithValue("@pass", password);
                        return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Auth Error: " + ex.Message);
                    return false;
                }
            }
        }

        // Management Method for HNC Computing Grading (D2/M4)
        public void UpdateStockCount(string sku, int newCount)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = "UPDATE Products SET currentStock = @stock WHERE itemSKU = @sku";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@stock", newCount);
                    cmd.Parameters.AddWithValue("@sku", sku);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}