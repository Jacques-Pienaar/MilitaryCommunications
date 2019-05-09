using System;
using System.Collections.Generic;
namespace MilitaryCommunications
{
    abstract public class Datahandler
    {
        public Datahandler()
        {
        }

        /* 
         * Gets all the officers from the database and returns it in a list 
         * so that the list can then be compared in other functions. It can be used to login
         * a user or display all officers
         */       
        public List<Officer> GetOfficers()
        {
            List<Officer> listToReturn = new List<Officer>();

            /* Return dummy values till database is connected */
            listToReturn.Add(new Officer("Herco", "Bezuidenhout", 20, 0, "hercobez@gmail.com", "herco1999"));
            listToReturn.Add(new Officer("Jandre", "Bezuidenhout", 15, 1, "jandrebez@gmail.com", "jandre2005"));
            listToReturn.Add(new Officer("Billy", "Jones", 34, 0, "billyjones@gmail.com", "billyisgay"));
            listToReturn.Add(new Officer("Andrew", "Holt", 32, 2, "andrewholt@gmail.com", "andrewisgreat"));

            return listToReturn;
        }
    }
}
