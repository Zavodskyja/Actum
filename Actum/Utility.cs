using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actum
{
    public class Utility
    {

        private static string Login = ramdomString();

        public static string login
        {
            get { return Login; }
            set { Login = value; }

        }

        private static string Password = ramdomString();

        public static string password
        {
            get { return Password; }
            set { Password = value; }

        }

        public static string ramdomString()
        {
            Random rand = new Random();
            string username = "";
            int stringlen = rand.Next(8, 15);
            int randValue;
            char letter;
            for (int i = 0; i < stringlen; i++)
            {
                randValue = rand.Next(0, 26);
                letter = Convert.ToChar(randValue + 65);
                username = username + letter;
            }
            return username.ToLower();
        }
    }
}
