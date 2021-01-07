using System;
using System.Data;
using System.Data.SqlClient;

namespace Sql
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = ConnectionString();
            cn.Open();


            Console.WriteLine("Funkcijos:");
            Console.WriteLine("1. Pamatyti visas pajamas");
            Console.WriteLine("2. Ideti naujas pajamas");
            Console.WriteLine("3. Atnaujinti pajamu suma ir data");
            Console.WriteLine("4. Panaikinta pajamas");
            Console.WriteLine("5.Iseiti?");
            Console.WriteLine("Pasirinkite koki veiksma norite atlikti:");
            
            string x = Console.ReadLine();
            while (x != "5")
            {
                if (x == "1")
                {
                    SelectFunction(cn); 
                }
                else if (x == "2")
                {
                    InsertIncome(cn);
                }
                else if (x == "3")
                {
                    UpdateIncome(cn);
                }
                else if (x == "4")
                {
                    DeleteIncome(cn);
                }
                Console.WriteLine("Funkcijos:");
                Console.WriteLine("1. Pamatyti visas pajamas");
                Console.WriteLine("2. Ideti naujas pajamas");
                Console.WriteLine("3. Atnaujinti pajamu suma ir data");
                Console.WriteLine("4. Panaikinta pajamas");
                Console.WriteLine("5.Iseiti?");
                Console.WriteLine("Pasirinkite koki veiksma norite atlikti:");
                x = Console.ReadLine();
            }

            cn.Close();

        }

        private static string ConnectionString()
        {
            string server = "Server=tcp:smart-saver.database.windows.net,1433;"; //Konfidenciali info keliauja i configa ir net nekeliama i githuba (cyber security)
            string initialCatalog = "Initial Catalog=SmartSaver;";
            string persistSecurityInfo = "Persist Security Info=False;";
            string userID = "User ID=smartsaver;";
            string password = $"Password={Password.Pass()};";
            string multipleActiveResultSets = "MultipleActiveResultSets=False;";
            string encrypt = "Encrypt=True;";
            string trustServerCertificate = "TrustServerCertificate=False;";
            string connectionTimeout = "Connection Timeout=30;";
            return (server + initialCatalog + persistSecurityInfo + userID + password + multipleActiveResultSets + encrypt + trustServerCertificate + connectionTimeout);

        }

        private static void DeleteIncome(SqlConnection cn)
        {
            SqlCommand delete = new SqlCommand();
            delete.Connection = cn;
            delete.CommandType = System.Data.CommandType.Text;
            delete.CommandText = "DELETE FROM IncomeDB WHERE incomeId = @incomeId";

            delete.Parameters.Add(new SqlParameter("@incomeId", SqlDbType.Int, 50, "incomeId"));

            SqlDataAdapter dk = new SqlDataAdapter("SELECT incomeId, incomeAmount, incomeDate, userId FROM IncomeDB", cn);
            dk.DeleteCommand = delete;

            DataSet dc = new DataSet();
            dk.Fill(dc, "IncomeDB");

            dc.Tables[0].Rows[0].Delete();
            dk.Update(dc.Tables[0]);
            dk.Dispose();
        }

        private static void UpdateIncome(SqlConnection cn)
        {
            SqlCommand update = new SqlCommand();
            update.Connection = cn;
            update.CommandType = System.Data.CommandType.Text;
            update.CommandText = "UPDATE IncomeDB SET incomeAmount = @IM, incomeDate = @ID WHERE incomeId = @incomeId";

            update.Parameters.Add(new SqlParameter("@IM", System.Data.SqlDbType.Decimal, 2, "incomeAmount"));
            update.Parameters.Add(new SqlParameter("@ID", System.Data.SqlDbType.DateTime, 7, "incomeDate"));
            update.Parameters.Add(new SqlParameter("@incomeId", System.Data.SqlDbType.Int, 50, "incomeId"));

            SqlDataAdapter da = new SqlDataAdapter("SELECT incomeId, incomeAmount, incomeDate, userID FROM IncomeDB", cn);
            da.UpdateCommand = update;

            DataSet ds = new DataSet();
            da.Fill(ds, "IncomeDB");

            ds.Tables[0].Rows[0]["incomeAmount"] = 5;
            ds.Tables[0].Rows[0]["incomeDate"] = DateTime.Now;

            da.Update(ds.Tables[0]);

            da.Dispose();
        }

        private static void InsertIncome(SqlConnection cn)
        {
            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = cn;
            cmd1.CommandType = System.Data.CommandType.Text;
            cmd1.CommandText = "INSERT INTO IncomeDB (incomeAmount,incomeDate, userId) " +
                $"VALUES ('10','{DateTime.Now}','1');";
            cmd1.ExecuteNonQuery();
        }

        private static void SelectFunction(SqlConnection cn)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT incomeAmount, incomeDate FROM IncomeDB";
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Console.WriteLine(string.Format("Income Amount:{0}, Income Date: {1}", dr["incomeAmount"], dr["incomeDate"]));

                }
            }
            dr.Close();
        }

    }



}
