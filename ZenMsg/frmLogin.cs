using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;

namespace ZenMsg
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        IFirebaseConfig Config = new FirebaseConfig
        {
            AuthSecret = "oySsq6VUnGjBSunrwBlO5bupnxBhu7adNZa4fOPj",
            BasePath = "https://zenmsg-default-rtdb.firebaseio.com"
        };

        IFirebaseClient Client;


        private void frmLogin_Load(object sender, EventArgs e)
        {
            Client = new FireSharp.FirebaseClient(Config);
        }

        private void LgnButton_Click(object sender, EventArgs e)
        {

            FirebaseResponse res = Client.Get("Users/" + username.Text);
            userInfo ResUser = res.ResultAs<userInfo>(); //DATABASE RESULTS

            userInfo CurUser = new userInfo() // USER GIVIN INFO
            {
                usernameV = username.Text,
                passwordV = password.Text
            };
            if (userInfo.IsEqual(ResUser, CurUser))
            {
                this.Hide();
                TestForm Test = new TestForm();
                Test.ShowDialog();
            }
            else
            {
                userInfo.ShowError();
            }


        }

    }
}
