using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Xml.Linq;
using System.Data;
using System.Data.SQLite;

/*
// Create Customer Class
public class Customer
{
    public string UserID { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string BillAdd { get; set; } = string.Empty;

    public string DeliverAdd { get; set; } = string.Empty;

    public int TelNum { get; set; }

    public string Email { get; set; } = string.Empty;
}
*/

namespace SQLite_Customers_DB
{
    class Customer
    {
        static void Main(string[] args)
        {

            SQLiteConnection sqliteConnection;
            sqliteConnection = CreateConnection();
            CreateTable(sqliteConnection);
            InsertData(sqliteConnection);
            UpdateData(sqliteConnection);
            ReadData(sqliteConnection);
        }
    
        static SQLiteConnection CreateConnection()
        {
            SQLiteConnection sqliteConn;
            sqliteConn = new SQLiteConnection("Data Source=Customers.db; Version = 3; New = True; Compress = True;");
            try
            {
                sqliteConn.Open();
            }
            catch
            {

            }
            return sqliteConn;
        }

        static void CreateTable(SQLiteConnection conn)
        {
            SQLiteCommand sqliteCommand;
            string createSQL = "@CREATE TABLE Customers (UserID TEXT PRIMARY KEY, Name TEXT NOT NULL, BillAdd TEXT NOT NULL, DeliverAdd TEXT NOT NULL, TelNum INT NOT NULL, Email TEXT NOT NULL)";
            sqliteCommand = conn.CreateCommand();
            sqliteCommand.CommandText = createSQL;
            sqliteCommand.ExecuteNonQuery();
        }

        static void InsertData(SQLiteConnection conn)
        {
            SQLiteCommand sqliteCommand;
            sqliteCommand = conn.CreateCommand();
            sqliteCommand.CommandText = "INSERT INTO Customers(UserID, Name, BillAdd, DeliverAdd, TelNum, Email) VALUES ('JohnDoe1', 'JohnDoe', 'Sinsenterrassen 9 0574 Oslo', 'Sinsenterrassen 9 0574 Oslo', 12345678, 'JohnDoe@gmail.com');";
            sqliteCommand.ExecuteNonQuery();
        }

        static void UpdateData(SQLiteConnection conn)
        {
            SQLiteCommand sqliteCommand;
            sqliteCommand = conn.CreateCommand();
            sqliteCommand.CommandText = "UPDATE INTO Customers(TelNum='newTelnum') VALUES (TelNum='23456789')";
            sqliteCommand.ExecuteNonQuery();
        }

     

        static void ReadData(SQLiteConnection conn)
        {
            SQLiteDataReader sqliteReader;
            SQLiteCommand sqliteCommand;
            sqliteCommand = conn.CreateCommand();
            sqliteCommand.CommandText = "SELECT * FROM Customers";
            sqliteReader = sqliteCommand.ExecuteReader();
            while (sqliteReader.Read())
            {
                string readerString = sqliteReader.GetString(0);
                Console.WriteLine(readerString);
            }
            conn.Close();
        }
    }
}