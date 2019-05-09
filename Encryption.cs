using System;
namespace MilitaryCommunications
{
    public class Encryption
    {
        public Encryption(){}

        public static char crypt(char ch, int key)
        {
            if (!char.IsLetter(ch))
            {

                return ch;
            }

            char d = char.IsUpper(ch) ? 'A' : 'a';
            return (char)((((ch + key) - d) % 26) + d);


        }


        public static string Encrypt(string input, int key)
        {
            string output = string.Empty;

            foreach (char ch in input)
                output += crypt(ch, key);

            return output;
        }

        public static string Decrypt(string input, int key)
        {
            return Encrypt(input, 26 - key);
        }
    }
}
