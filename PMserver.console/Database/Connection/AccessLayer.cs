using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMserver.console.Database.Connection
{
    internal class AccessLayer
    {
        //> 

        public void run()
        {
            SqlConnection connection = new SqlConnection(@"Data Source=192.168.0.200,1433;Initial Catalog=PM;User ID=Christian.lsj;Password=chri1sti2an3");

            try
            {
                connection.Open();
                SqlDataReader reader; 
                SqlCommand cmd = new SqlCommand("SELECT * FROM ", connection);
                reader = cmd.ExecuteReader();


                ///Read and print to console
                while (reader.NextResult())
                {
                    Console.WriteLine(String.Format("{0} ", reader["FirstName".ToString()]));
                }

            }
            
            catch (Exception)
            {
                //TODO Error Logging On database Connection
                throw;
            }

            finally
            {
                connection.Close();
            }
        }


    }
}
