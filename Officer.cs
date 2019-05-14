using System;
using System.Collections.Generic;

namespace MilitaryCommunications
{
    public delegate void LoginUser();
    public class Officer : Datahandler
    {
        private string nationalId;
        private string firstName;
        private string lastName;
        private int age;
        private int rank;
        private string username;
        private string password;

        public string NationalId { get => nationalId; set => nationalId = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public int Age { get => age; set => age = value; }
        public int Rank { get => rank; set => rank = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }

        public Officer() { }

        public Officer(string firstName, string lastName, int age, int rank, string username, string password)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Rank = rank;
            this.Username = username;
            this.Password = password;
        }

        /* Used to log in user */
        public Officer(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }

        public int Login()
        {
            List<Officer> officers = GetOfficers();
            int result = 0;

            foreach (Officer officer in officers)
            {
                if (this.CompareTo(officer))
                {
                    result = 1;
                }
            }

            return result;
        }

        public int Save()
        {
            int rowsAffected = SaveOfficer(this);
            return rowsAffected;
        }

        public int Update()
        {
            int rowsAffected = UpdateOfficer(this);
            return rowsAffected;
        }

        public int Delete()
        {
            int rowsAffected = DeleteOfficer(this);
            return rowsAffected;
        }

        public bool CompareTo(object obj)
        {
            Officer officerToCompare = obj as Officer;
            bool result = false;

            if(officerToCompare.username == this.username)
            {
                if(officerToCompare.password == this.password)
                {
                    result = true;
                    this.FirstName = officerToCompare.FirstName;
                    this.LastName = officerToCompare.LastName;
                    this.Age = officerToCompare.Age;
                    this.Rank = officerToCompare.Rank;
                }
            }

            return result;
        }
    }
}
