using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZenMsg
{
   internal class userInfo
    {
        public string usernameV { get; set; }
        public string emailV { get; set; }
        public string passwordV { get; set; }


        private static string error="Error!";

        public static void ShowError()
        {
            System.Windows.Forms.MessageBox.Show(error);
        }

        public static bool IsEqual(userInfo user1, userInfo user2)
        {
            if(user1 ==null || user2 ==null) { return false; }

            if(user1.usernameV!= user2.usernameV)
            {
                error = "Username does not exist!";
                return false;
            }

          else if (user1.passwordV != user2.passwordV)
            {
                error = "Username does not match password!";
                return false;
            }

            return true;
        }
    }
}
