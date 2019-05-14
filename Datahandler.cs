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
    abstract public class Datahandler
    {

        SqlConnectionStringBuilder connection = new SqlConnectionStringBuilder();
        SqlConnection conn = new SqlConnection();
        SqlCommand com;
        SqlDataReader reader;
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

 
        /* Gets All of the officers from the database */
        public List<Officer> GetOfficers()
        {
            List<Officer> listToReturn = new List<Officer>();
            

            /* All database related functions */
            connection.Open();
            com = new SqlCommand("sp_SelectAllOffices", connection);
            com.CommandType = CommandType.StoredProcedure;
            reader = com.ExecuteReader();
            
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

        public List<Message> GetAllMessages()
        {
            string proc = "sp_GetAllMessages";
            conn.Open();

            com = new SqlCommand(proc, conn);
            com.CommandType = CommandType.StoredProcedure;
            reader = com.ExecuteReader();

            while(reader.Read())
            {
                Message message = new Message();
                message.UserId = Convert.ToInt32(reader["UserId"]);
                message.Message = Convert.ToString(reader["Message"]);
                message.TimeToDecrypt = Convert.ToDateTime(reader["TimeToDecrypt"]);

                listToReturn.Add(message);
            }

            conn.Close();

            return listToReturn;
        }

        public Message GetMessage(Message messageToGet)
        {
            Message messageToReturn = new Message();
            string proc = "sp_GetMessage";
            conn.Open();

            com = new SqlCommand(proc, conn);
            com.CommandType = CommandType.StoredProcedure;
            com.Paramaters.Add(new SqlParamater("@message_id", messageToGet.MessageId));

            reader = com.ExecuteReader();

            while(reader.Read())
            {
                messageToReturn.MessageId = messageToGet.MessageId;
                messageToReturn.UserId = Convert.ToInt32(reader["UserId"]);
                messageToReturn.Message = Convert.ToString(reader["Message"]);
                messageToReturn.TimeToDecrypt = Convert.ToDateTime(reader["TimeToDecrypt"]);
            }

            conn.Close();
            return messageToReturn;
        }

        public int SaveMessage(Message message)
        {
            string proc = "sp_SaveMessage";
            int rowsAffected = 0;

            conn.Open();
            com = new SqlCommand(proc, conn);
            com.CommandType = CommandType.StoredProcedure;

            com.Paramaters.Add(new SqlParamater("@UserId", message.UserId));
            com.Paramaters.Add(new SqlParamater("@Message", message.Message));
            com.Paramaters.Add(new SqlParamater("@TimeToDecrypt", message.TimeToDecrypt));

            rowsAffected = com.ExecuteNonQuery();
            
            conn.Close();

            return rowsAffected;
        }

        public int SaveOfficer(Officer officer)
        {
            string proc = "sp_SaveOfficer";
            int rowsAffected = 0;

            conn.Open();
            com = new SqlCommand(proc, conn);
            com.CommandType = CommandType.StoredProcedure;

            com.Paramaters.Add(new SqlParamater("@NationalId", officer.NationalId));
            com.Paramaters.Add(new SqlParamater("@FirstName", officer.FirstName));
            com.Paramaters.Add(new SqlParamater("@LastName", officer.LastName));
            com.Paramaters.Add(new SqlParamater("@Age", officer.Age));
            com.Paramaters.Add(new SqlParamater("@Rank", officer.Rank));
            com.Paramaters.Add(new SqlParamater("@Username", officer.Username));
            com.Paramaters.Add(new SqlParamater("@Password", officer.Password));

            rowsAffected = com.ExecuteNonQuery();
            
            conn.Close();

            return rowsAffected;
        }

        public int UpdateOfficer(Officer officer)
        {
            string proc = "sp_UpdateOfficer";
            int rowsAffected = 0;

            conn.Open();
            com = new SqlCommand(proc, conn);
            com.CommandType = CommandType.StoredProcedure;

            com.Paramaters.Add(new SqlParamater("@NationalId", officer.NationalId));
            com.Paramaters.Add(new SqlParamater("@FirstName", officer.FirstName));
            com.Paramaters.Add(new SqlParamater("@LastName", officer.LastName));
            com.Paramaters.Add(new SqlParamater("@Age", officer.Age));
            com.Paramaters.Add(new SqlParamater("@Rank", officer.Rank));
            com.Paramaters.Add(new SqlParamater("@Username", officer.Username));
            com.Paramaters.Add(new SqlParamater("@Password", officer.Password));

            rowsAffected = com.ExecuteNonQuery();
            
            conn.Close();

            return rowsAffected;
        }

        public int DeleteOfficer(Officer officer)
        {
            string proc = "sp_DeleteOfficer";
            int rowsAffected = 0;

            conn.Open();
            com = new SqlCommand(proc, conn);
            com.CommandType = CommandType.StoredProcedure;

            com.Paramaters.Add(new SqlParamater("@NationalId", officer.NationalId));
            

            rowsAffected = com.ExecuteNonQuery();
            
            conn.Close();

            return rowsAffected;
        }


         
    }
}
