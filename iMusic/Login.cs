using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iMusic
{
    public partial class Login : Form
    {
        int id;
        SqlConnection connection;
        SqlDataReader dataReader;
        SqlCommand command;
        public Login()
        {
            InitializeComponent();
        }

        private void login_btn_Click(object sender, EventArgs e)
        {

            string userName = txtUserName.Text;
            string password = txtPassword.Text;
            connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=iMusic;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            command = new SqlCommand();
            connection.Open();
            command.Connection = connection;
            command.CommandText = "Select * from users where UserName='" + userName + "' and Password='" + password + "'";
            id = (int)command.ExecuteScalar();
            dataReader = command.ExecuteReader();
            if (dataReader.Read())
            {
                MessageBox.Show("Login is succeed!");
                new HomePage(id).Show();
                this.Hide();
                connection.Close();

            }
            else
            {
                MessageBox.Show("Wrong user name or email");
            }





        }
        private void register_btn_Click(object sender, EventArgs e)
        {
            new Register().Show();
            this.Hide();
        }

        private void admin_btn_Click(object sender, EventArgs e)
        {
            new AdminLogin().Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            txtUserName.Clear();
            txtPassword.Clear();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


    }
}
