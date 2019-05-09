using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

namespace TestingForm_MilitaryComms
{
    abstract class Datahandler
    {

        SqlConnectionStringBuilder connection = new SqlConnectionStringBuilder();
        SqlConnection conn = new SqlConnection();
        private string ConnectionString = @"Data Source=DESKTOP-RLPPP3A;Initial Catalog=MilitaryComms;Integrated Security=True";

        public Datahandler()
        {
            connection.DataSource = @"DESKTOP-RLPPP3A";
            connection.InitialCatalog = "MilitaryComms";
            connection.IntegratedSecurity = true;
            conn = new SqlConnection(connection.ConnectionString);
        }

    


        /* 
         * Gets all the officers from the database and returns it in a list 
         * so that the list can then be compared in other functions. It can be used to login
         * a user or display all officers
         */

 

        public List<Officer> GetOfficers()
        {
            List<Officer> listToReturn = new List<Officer>();

            /* All database related functions */
            connection.Open();
            SqlCommand com = new SqlCommand("sp_SelectAllOffices", connection);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = com.ExecuteReader();
            
            while (reader.Read())
            {
                Officer officerToAdd = new Officer();
                officerToAdd.NationId = (string)reader["OfficerID"];
                officerToAdd.FirstName = (string)reader["FirstName"];
                officerToAdd.LastName = (string)reader["LastName"];
                officerToAdd.Age = (int)reader["Age"];
                officerToAdd.Rank = (int)reader["Rank"];
                officerToAdd.Username = (string)reader["Username"];
                officerToAdd.Password = (string)reader["Password"];
                listToReturn.Add(officerToAdd);
            }
            
            connection.Close();

    
            /* Database functionality end */

            return listToReturn;
        }

         
    }
}
