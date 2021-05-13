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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        static string conString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=iMusic;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        SqlConnection connect = new SqlConnection(conString);

        private void label2_Click(object sender, EventArgs e)
        {
            txtUserName.Clear();
            txtPassword.Clear();
            txtCountryCode.Clear();
            txtEmail.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Login().Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (connect.State==ConnectionState.Closed)
                {
                    connect.Open();
                    string register = "insert into users (UserName,UserEmail,Password,CountryCode) values (@UserName,@UserEmail,@Password,@CountryCode)";
                    SqlCommand command = new SqlCommand(register, connect);
                    command.Parameters.AddWithValue("@UserName", txtUserName.Text);
                    command.Parameters.AddWithValue("@UserEmail", txtEmail.Text);
                    command.Parameters.AddWithValue("@Password", txtPassword.Text);
                    command.Parameters.AddWithValue("@CountryCode", txtCountryCode.Text);

                    command.ExecuteNonQuery();

                    connect.Close();
                    MessageBox.Show("Register is succeed!");
                    new Login().Show();
                    this.Hide();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error: " + error.Message);
            }
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }
    }
}
