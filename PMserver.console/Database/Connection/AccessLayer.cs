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
            //> Connection string to connect the database. 
            SqlConnection connection = new SqlConnection(@"Data Source=192.168.0.200,1433;Initial Catalog=PM;User ID=Christian.lsj;Password=chri1sti2an3");

            try
            {
                connection.Open();                                              //Opning connection to database
                SqlDataReader reader;                                           //Reader Stream
                SqlCommand cmd = new SqlCommand("SELECT * FROM ", connection);  //Doing a simple Sql command
                reader = cmd.ExecuteReader();                                   //Exec Readerstream


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
                connection.Close(); //Closing Sql-Connection
            }
        }


    }
}
