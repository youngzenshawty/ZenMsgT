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
using FireSharp.Interfaces;
using FireSharp.Response;
using Firebase;



namespace ZenMsg
{
    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();
        }

        IFirebaseConfig Config = new FirebaseConfig
        {
            AuthSecret = "oySsq6VUnGjBSunrwBlO5bupnxBhu7adNZa4fOPj",
            BasePath = "https://zenmsg-default-rtdb.firebaseio.com"


        };

        IFirebaseClient Client;

       
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void FrmRegister_Load(object sender, EventArgs e)
        {
            Client = new FireSharp.FirebaseClient(Config);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (username.Text == "" && email.Text == "" && password.Text == "")
            {
                MessageBox.Show("Empty Fields!");
            }
            else
            {
                CreateUser();
            }
        }

        private async void CreateUser()
        {
            var Info = new userInfo
            {
                usernameV = username.Text,
                emailV = email.Text,
                passwordV = password.Text

            };

            FirebaseResponse response = await Client.SetAsync(@"Users/"+username.Text,Info);
            MessageBox.Show("Registerd User!");
        }

        private void password_TextChanged(object sender, EventArgs e)
        {
        }

        private void checkbxShowPas_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbxShowPas.Checked)
            {
                password.PasswordChar = '\0';
            }else
            {
                password.PasswordChar = '•';
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            username.Text = "";
            email.Text = "";
            password.Text = "";
            username.Focus();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            new frmLogin().Show();
            this.Hide();
        }
    }
}
