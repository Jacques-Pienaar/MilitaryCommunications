using System;

namespace MilitaryCommunications
{
    class MainClass
    {

        static private int isLogged;
      

        enum Menu
        {
            NewMail
        }

        static void Main(string[] args)
        {
            do
            {
                if (isLogged == 0)
                {
                    LoginUser();
                }
                else
                {
                    WriteHeader();
                    Console.WriteLine("Welcome to Military Communication!\nPlease choose your option:");
                    WriteOptions();
                }

                Console.ReadLine();
            } while (true);

        }

        static public void LoginUser()
        {
            string username = "";
            string password = "";

            /* Console app logic */
            WriteHeader();
            Console.WriteLine("Username:");
            username = Console.ReadLine();
            Console.WriteLine("Password:");
            password = Console.ReadLine();
            /* End console app logic */

            Officer officer = new Officer(username, password);
            isLogged = officer.Login();

        }

        static public void WriteHeader()
        {
            Console.Clear();
            Console.WriteLine("*********** Military Communications ***********");
            Console.WriteLine("_______________________________________________");
        }

        static public void WriteOptions()
        {
            string menu = @"
1. Mails
2. Officers
3. Logs
4. Encryptions
            ";

            Console.WriteLine(menu);
        }
    }
}
