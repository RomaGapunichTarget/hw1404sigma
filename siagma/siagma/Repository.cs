using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace siagma
{
    public class Repository
    {
        public SqlConnection conn;
        public Repository(SqlConnection sql)
        {
            conn = sql;
            
            conn.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database.mdf;Initial Catalog=Database;Integrated Security=True";
            
        }

        public void Connect()
        {
            SqlDataReader rdr = null;

            try
            {
                // 2. Open the connection
                conn.Open();

                // 3. Pass the connection to a command object
                SqlCommand cmd = new SqlCommand("select * from Animals", conn);

                //
                // 4. Use the connection
                //

                // get query results
                rdr = cmd.ExecuteReader();

                // print the CustomerID of each record
                while (rdr.Read())
                {
                    Console.WriteLine(rdr[0]);
                }
            }
            catch (Exception e)
            {
                SqlCommand cmd = new SqlCommand(@"CREATE TABLE [dbo].Animals
                    ([Id] INT NOT NULL PRIMARY KEY IDENTITY,
                    [Name] NVARCHAR(MAX) NULL,
                    [Height] DECIMAL(18, 3) NULL,
                    [Weight] DECIMAL(18, 3) NULL)", conn);
                cmd.CommandType = CommandType.Text;
            }
            finally
            {
                // close the reader
                if (rdr != null)
                {
                    rdr.Close();
                }

                // 5. Close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
    }
}
