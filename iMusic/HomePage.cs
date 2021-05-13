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
    public partial class HomePage : Form
    {
        int id;
        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter dataAdapter;
        SqlDataReader dataReader;
        public HomePage(int id)
        {
            this.id = id;
            InitializeComponent();
            GetUsers();
            GetMusics();
            GetAlbums();
            GetPopMusics();
            GetJazzMusics();
            GetClassicalMusics();
            GetTopMusics();
            GetTopTenCountries();
            StyleDataGridView();
        }

        void GetUsers()
        {
            connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=iMusic;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            connection.Open();
            dataAdapter = new SqlDataAdapter("SELECT Id, UserName AS [User Name] FROM users", connection);
            DataTable table = new DataTable();
            dataAdapter.Fill(table);
            dgv_users.DataSource = table;
            connection.Close();
        }
        void GetTopMusics()
        {
            connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=iMusic;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            connection.Open();
            dataAdapter = new SqlDataAdapter("Select TOP 10 musics.MusicId as Id ," +
                " musics.MusicName  as [Music Name] ," +
                " artists.ArtistName as [Artist Name] ," +
                " categories.CategoryName as [Category Name]," +
                " musics.ListeningCount as Count from musics " +
                "inner join categories on categories.CategoryId = musics.CategoryId " +
                "inner join artists on artists.ArtistId = musics.ArtistId ", connection);
            DataTable table = new DataTable();
            dataAdapter.Fill(table);
            dgv_top_ten.DataSource = table;
            connection.Close();
        }

        void GetMusics()
        {
            connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=iMusic;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            connection.Open();
            dataAdapter = new SqlDataAdapter("Select musics.MusicId  as [ID] , musics.MusicName  as [Music Name] , artists.ArtistName as [Artist Name] , categories.CategoryName as [Category Name], musics.ListeningCount as [Listening Count] from musics " +
                "inner join categories on musics.CategoryId = categories.CategoryId " +
                "inner join artists on musics.ArtistId = artists.ArtistId ", connection);
            DataTable table = new DataTable();
            dataAdapter.Fill(table);
            dgv_musics.DataSource = table;
            connection.Close();
        }

        void GetAlbums()
        {
            connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=iMusic;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            connection.Open();
            dataAdapter = new SqlDataAdapter("Select albums.AlbumName  as [Album Name], artists.ArtistName as [Artist Name] , categories.CategoryName as [Category Name] from albums " +
                "inner join categories on albums.CategoryId = categories.CategoryId " +
                "inner join musics on albums.MusicId = musics.MusicId " +
                "inner join artists on albums.ArtistId = artists.ArtistId ", connection);
            DataTable table = new DataTable();
            dataAdapter.Fill(table);
            dgv_albums.DataSource = table;
            connection.Close();
        }

        void GetPopMusics()
        {
            connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=iMusic;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            connection.Open();
            dataAdapter = new SqlDataAdapter("Select musics.MusicId as Id , musics.MusicName  as [Music Name] ," +
                " artists.ArtistName as [Artist Name] ," +
                " categories.CategoryName as [Category Name] from playlists " +
                "inner join musics on musics.MusicId = playlists.MusicId " +
                "inner join categories on categories.CategoryId = musics.CategoryId " +
                "inner join users on playlists.UserId = users.Id " +
                "inner join artists on artists.ArtistId = musics.ArtistId " +
                "WHERE categories.CategoryId = 1 AND users.Id=" + this.id, connection);
            DataTable table = new DataTable();
            dataAdapter.Fill(table);
            dgv_musics_pop.DataSource = table;
            connection.Close();
        }

        void GetJazzMusics()
        {
            connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=iMusic;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            connection.Open();
            dataAdapter = new SqlDataAdapter("Select musics.MusicId as Id , musics.MusicName  as [Music Name] , artists.ArtistName as [Artist Name] , categories.CategoryName as [Category Name] from playlists " +
                "inner join musics on musics.MusicId = playlists.MusicId " +
                "inner join categories on musics.CategoryId = categories.CategoryId " +
                "inner join users on playlists.UserId = users.Id " +
                "inner join artists on musics.ArtistId = artists.ArtistId " +
                "WHERE categories.CategoryId = 2 AND users.Id=" + this.id, connection);
            DataTable table = new DataTable();
            dataAdapter.Fill(table);
            dgv_musics_jazz.DataSource = table;
            connection.Close();
        }

        void GetClassicalMusics()
        {
            connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=iMusic;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            connection.Open();
            dataAdapter = new SqlDataAdapter("Select musics.MusicId as Id , musics.MusicName  as [Music Name] , artists.ArtistName as [Artist Name] , categories.CategoryName as [Category Name] from playlists " +
                "inner join musics on musics.MusicId = playlists.MusicId " +
                "inner join categories on musics.CategoryId = categories.CategoryId " +
                "inner join users on playlists.UserId = users.Id " +
                "inner join artists on musics.ArtistId = artists.ArtistId " +
                "WHERE categories.CategoryId = 3 AND users.Id=" + this.id, connection);
            DataTable table = new DataTable();
            dataAdapter.Fill(table);
            dgv_musics_classical.DataSource = table;
            connection.Close();
        }

        private void GetTopTenCountries()
        {
            connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=iMusic;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            connection.Open();
            dataAdapter = new SqlDataAdapter("Select TOP 10 artists.CountryCode as CC ," +
                " musics.MusicName  as [Music Name] ," +
                " artists.ArtistName as [Artist Name] , " +
                " musics.ListeningCount as Count ," +
                " categories.CategoryName as [Category Name] from musics " +
                "inner join categories on categories.CategoryId = musics.CategoryId " +
                "inner join artists on artists.ArtistId = musics.ArtistId " +
                "inner join playlists on playlists.MusicId = musics.MusicId " +
                "inner join users on users.Id = playlists.UserId ", connection);
            DataTable table = new DataTable();
            dataAdapter.Fill(table);
            dgv_top_countries.DataSource = table;
            connection.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            string queryString = "UPDATE musics SET ListeningCount = ListeningCount + 1 WHERE MusicId=@musicid";
            command = new SqlCommand(queryString, connection);
            command.Parameters.AddWithValue("@musicid", dgv_musics.CurrentRow.Cells[0].Value);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            GetMusics();
            GetTopTenCountries();
            GetTopMusics();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string queryString = "SELECT * FROM playlists WHERE UserId = @id AND MusicId=@musicid";
            command = new SqlCommand(queryString, connection);
            command.Parameters.AddWithValue("@id", this.id);
            command.Parameters.AddWithValue("@musicid", dgv_musics.CurrentRow.Cells[0].Value);
            connection.Open();
            command.ExecuteNonQuery();
            dataReader = command.ExecuteReader();
            if (dataReader.Read())
            {
                connection.Close();
                MessageBox.Show("You can add music just one time!");
            }
            else
            {
                connection.Close();
                string queryString1 = "INSERT INTO playlists(UserId,MusicId) VALUES(@userid,@musicid)";
                command = new SqlCommand(queryString1, connection);
                command.Parameters.AddWithValue("@userid", this.id);
                command.Parameters.AddWithValue("@musicid", dgv_musics.CurrentRow.Cells[0].Value);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                GetPopMusics();
                GetJazzMusics();
                GetClassicalMusics();
            }
        }

        private void btn_follow_Click(object sender, EventArgs e)
        {

            int id = (int)dgv_users.CurrentRow.Cells[0].Value;
            string queryString = "SELECT * FROM premium_users WHERE UserId = @id";
            command = new SqlCommand(queryString, connection);
            command.Parameters.AddWithValue("@id", id);
            connection.Open();
            command.ExecuteNonQuery();
            dataReader = command.ExecuteReader();
            if (dataReader.Read())
            {
                connection.Close();
                string queryString1 = "INSERT INTO followersandfollowing(FollowerId,FollowedId) VALUES(@followerid,@followedid)";
                command = new SqlCommand(queryString1, connection);
                command.Parameters.AddWithValue("@followerid", this.id);
                command.Parameters.AddWithValue("@followedid", id);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Following is succeed!");

            }
            else
            {
                connection.Close();
                MessageBox.Show("This User is not a Premium User! ");
            }



        }

        private void btn_show_playlist_Click(object sender, EventArgs e)
        {
            int id = (int)dgv_users.CurrentRow.Cells[0].Value;
            string queryString = "SELECT * FROM followersandfollowing WHERE FollowerId = @followerid AND FollowedId = @followedid";
            command = new SqlCommand(queryString, connection);
            command.Parameters.AddWithValue("@followerid", this.id);
            command.Parameters.AddWithValue("@followedid", id);
            connection.Open();
            command.ExecuteNonQuery();
            dataReader = command.ExecuteReader();
            if (dataReader.Read())
            {
                connection.Close();
                connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=iMusic;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                connection.Open();
                dataAdapter = new SqlDataAdapter("Select musics.MusicId as Id , musics.MusicName  as [Music Name] ," +
                    " artists.ArtistName as [Artist Name] ," +
                    " categories.CategoryName as [Category Name] from playlists " +
                    "inner join musics on musics.MusicId = playlists.MusicId " +
                    "inner join categories on categories.CategoryId = musics.CategoryId " +
                    "inner join users on playlists.UserId = users.Id " +
                    "inner join artists on artists.ArtistId = musics.ArtistId " +
                    "WHERE categories.CategoryId = 1 AND users.Id=" + id, connection);
                DataTable table = new DataTable();
                dataAdapter.Fill(table);
                dgv_musics_pop.DataSource = table;
                connection.Close();
                connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=iMusic;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                connection.Open();
                dataAdapter = new SqlDataAdapter("Select musics.MusicId as Id ,musics.MusicName  as [Music Name] , artists.ArtistName as [Artist Name] , categories.CategoryName as [Category Name] from playlists " +
                    "inner join musics on musics.MusicId = playlists.MusicId " +
                    "inner join categories on musics.CategoryId = categories.CategoryId " +
                    "inner join users on playlists.UserId = users.Id " +
                    "inner join artists on musics.ArtistId = artists.ArtistId " +
                    "WHERE categories.CategoryId = 2 AND users.Id=" + id, connection);
                DataTable table1 = new DataTable();
                dataAdapter.Fill(table1);
                dgv_musics_jazz.DataSource = table1;
                connection.Close();
                connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=iMusic;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                connection.Open();
                dataAdapter = new SqlDataAdapter("Select musics.MusicId as Id ,musics.MusicName  as [Music Name] , artists.ArtistName as [Artist Name] , categories.CategoryName as [Category Name] from playlists " +
                    "inner join musics on musics.MusicId = playlists.MusicId " +
                    "inner join categories on musics.CategoryId = categories.CategoryId " +
                    "inner join users on playlists.UserId = users.Id " +
                    "inner join artists on musics.ArtistId = artists.ArtistId " +
                    "WHERE categories.CategoryId = 3 AND users.Id=" + id, connection);
                DataTable table2 = new DataTable();
                dataAdapter.Fill(table2);
                dgv_musics_classical.DataSource = table2;
                connection.Close();
            }
            else
            {
                connection.Close();
                MessageBox.Show("You must follow this user before show playlist!");
                connection.Close();
            }
        }

        private void btn_add_pop_Click(object sender, EventArgs e)
        {
            string queryString = "SELECT * FROM playlists WHERE UserId = @id AND MusicId=@musicid";
            command = new SqlCommand(queryString, connection);
            command.Parameters.AddWithValue("@id", this.id);
            command.Parameters.AddWithValue("@musicid", dgv_musics_pop.CurrentRow.Cells[0].Value);
            connection.Open();
            command.ExecuteNonQuery();
            dataReader = command.ExecuteReader();
            if (dataReader.Read())
            {
                connection.Close();
                MessageBox.Show("You can add music just one time!");
            }
            else
            {
                connection.Close();
                string queryString1 = "INSERT INTO playlists(UserId,MusicId) VALUES(@userid,@musicid)";
                command = new SqlCommand(queryString1, connection);
                command.Parameters.AddWithValue("@userid", this.id);
                command.Parameters.AddWithValue("@musicid", dgv_musics_pop.CurrentRow.Cells[0].Value);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                GetPopMusics();
                GetJazzMusics();
                GetClassicalMusics();
            }
        }

        private void btn_add_all_pop_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgv_musics_pop.Rows)
            {
                string queryString = "SELECT * FROM playlists WHERE UserId = @id AND MusicId=@musicid";
                command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@id", this.id);
                command.Parameters.AddWithValue("@musicid", row.Cells[0].Value);
                connection.Open();
                command.ExecuteNonQuery();
                dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {
                    connection.Close();
                    MessageBox.Show("You can add music just one time!");
                }
                else
                {
                    connection.Close();
                    string queryString1 = "INSERT INTO playlists(UserId,MusicId) VALUES(@userid,@musicid)";
                    command = new SqlCommand(queryString1, connection);
                    command.Parameters.AddWithValue("@userid", this.id);
                    command.Parameters.AddWithValue("@musicid", row.Cells[0].Value);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            GetPopMusics();
            GetJazzMusics();
            GetClassicalMusics();

        }

        private void btn_add_jazz_Click(object sender, EventArgs e)
        {
            string queryString = "SELECT * FROM playlists WHERE UserId = @id AND MusicId=@musicid";
            command = new SqlCommand(queryString, connection);
            command.Parameters.AddWithValue("@id", this.id);
            command.Parameters.AddWithValue("@musicid", dgv_musics_jazz.CurrentRow.Cells[0].Value);
            connection.Open();
            command.ExecuteNonQuery();
            dataReader = command.ExecuteReader();
            if (dataReader.Read())
            {
                connection.Close();
                MessageBox.Show("You can add music just one time!");
            }
            else
            {
                connection.Close();
                string queryString1 = "INSERT INTO playlists(UserId,MusicId) VALUES(@userid,@musicid)";
                command = new SqlCommand(queryString1, connection);
                command.Parameters.AddWithValue("@userid", this.id);
                command.Parameters.AddWithValue("@musicid", dgv_musics_jazz.CurrentRow.Cells[0].Value);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                GetPopMusics();
                GetJazzMusics();
                GetClassicalMusics();
            }
        }
        private void btn_add_all_jazz_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgv_musics_jazz.Rows)
            {
                string queryString = "SELECT * FROM playlists WHERE UserId = @id AND MusicId=@musicid";
                command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@id", this.id);
                command.Parameters.AddWithValue("@musicid", row.Cells[0].Value);
                connection.Open();
                command.ExecuteNonQuery();
                dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {
                    connection.Close();
                    MessageBox.Show("You can add music just one time!");
                }
                else
                {
                    connection.Close();
                    string queryString1 = "INSERT INTO playlists(UserId,MusicId) VALUES(@userid,@musicid)";
                    command = new SqlCommand(queryString1, connection);
                    command.Parameters.AddWithValue("@userid", this.id);
                    command.Parameters.AddWithValue("@musicid", row.Cells[0].Value);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            GetPopMusics();
            GetJazzMusics();
            GetClassicalMusics();
        }

        private void btn_add_classical_Click(object sender, EventArgs e)
        {
            string queryString = "SELECT * FROM playlists WHERE UserId = @id AND MusicId=@musicid";
            command = new SqlCommand(queryString, connection);
            command.Parameters.AddWithValue("@id", this.id);
            command.Parameters.AddWithValue("@musicid", dgv_musics_classical.CurrentRow.Cells[0].Value);
            connection.Open();
            command.ExecuteNonQuery();
            dataReader = command.ExecuteReader();
            if (dataReader.Read())
            {
                connection.Close();
                MessageBox.Show("You can add music just one time!");
            }
            else
            {
                connection.Close();
                string queryString1 = "INSERT INTO playlists(UserId,MusicId) VALUES(@userid,@musicid)";
                command = new SqlCommand(queryString1, connection);
                command.Parameters.AddWithValue("@userid", this.id);
                command.Parameters.AddWithValue("@musicid", dgv_musics_classical.CurrentRow.Cells[0].Value);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                GetPopMusics();
                GetJazzMusics();
                GetClassicalMusics();
            }
        }
        private void btn_add_all_classical_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgv_musics_classical.Rows)
            {
                string queryString = "SELECT * FROM playlists WHERE UserId = @id AND MusicId=@musicid";
                command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@id", this.id);
                command.Parameters.AddWithValue("@musicid", row.Cells[0].Value);
                connection.Open();
                command.ExecuteNonQuery();
                dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {
                    connection.Close();
                    MessageBox.Show("You can add music just one time!");
                }
                else
                {
                    connection.Close();
                    string queryString1 = "INSERT INTO playlists(UserId,MusicId) VALUES(@userid,@musicid)";
                    command = new SqlCommand(queryString1, connection);
                    command.Parameters.AddWithValue("@userid", this.id);
                    command.Parameters.AddWithValue("@musicid", row.Cells[0].Value);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            GetPopMusics();
            GetJazzMusics();
            GetClassicalMusics();
        }

        private void btn_show_your_playlist_Click(object sender, EventArgs e)
        {

            connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=iMusic;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            connection.Open();
            dataAdapter = new SqlDataAdapter("Select musics.MusicId as Id , musics.MusicName  as [Music Name] ," +
                " artists.ArtistName as [Artist Name] ," +
                " categories.CategoryName as [Category Name] from playlists " +
                "inner join musics on musics.MusicId = playlists.MusicId " +
                "inner join categories on categories.CategoryId = musics.CategoryId " +
                "inner join users on playlists.UserId = users.Id " +
                "inner join artists on artists.ArtistId = musics.ArtistId " +
                "WHERE categories.CategoryId = 1 AND users.Id=" + this.id, connection);
            DataTable table = new DataTable();
            dataAdapter.Fill(table);
            dgv_musics_pop.DataSource = table;
            connection.Close();
            connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=iMusic;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            connection.Open();
            dataAdapter = new SqlDataAdapter("Select musics.MusicId as Id ,musics.MusicName  as [Music Name] , artists.ArtistName as [Artist Name] , categories.CategoryName as [Category Name] from playlists " +
                "inner join musics on musics.MusicId = playlists.MusicId " +
                "inner join categories on musics.CategoryId = categories.CategoryId " +
                "inner join users on playlists.UserId = users.Id " +
                "inner join artists on musics.ArtistId = artists.ArtistId " +
                "WHERE categories.CategoryId = 2 AND users.Id=" + this.id, connection);
            DataTable table1 = new DataTable();
            dataAdapter.Fill(table1);
            dgv_musics_jazz.DataSource = table1;
            connection.Close();
            connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=iMusic;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            connection.Open();
            dataAdapter = new SqlDataAdapter("Select musics.MusicId as Id ,musics.MusicName  as [Music Name] , artists.ArtistName as [Artist Name] , categories.CategoryName as [Category Name] from playlists " +
                "inner join musics on musics.MusicId = playlists.MusicId " +
                "inner join categories on musics.CategoryId = categories.CategoryId " +
                "inner join users on playlists.UserId = users.Id " +
                "inner join artists on musics.ArtistId = artists.ArtistId " +
                "WHERE categories.CategoryId = 3 AND users.Id=" + this.id, connection);
            DataTable table2 = new DataTable();
            dataAdapter.Fill(table2);
            dgv_musics_classical.DataSource = table2;
            connection.Close();

        }

        private void btn_show_top_ten_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=iMusic;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            connection.Open();
            dataAdapter = new SqlDataAdapter("Select TOP 10 musics.MusicId as Id ," +
                " musics.MusicName  as [Music Name] ," +
                " artists.ArtistName as [Artist Name] , " +
                " musics.ListeningCount as Count ," +
                " categories.CategoryName as [Category Name] from musics " +
                "inner join categories on categories.CategoryId = musics.CategoryId " +
                "inner join artists on artists.ArtistId = musics.ArtistId " +
                "WHERE categories.CategoryId = 1", connection);
            DataTable table = new DataTable();
            dataAdapter.Fill(table);
            dgv_musics_pop.DataSource = table;
            connection.Close();
            connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=iMusic;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            connection.Open();
            dataAdapter = new SqlDataAdapter("Select TOP 10 musics.MusicId as Id ," +
                "musics.MusicName  as [Music Name] ," +
                " artists.ArtistName as [Artist Name] , " +
                "musics.ListeningCount as Count , " +
                "categories.CategoryName as [Category Name] from musics " +
                "inner join categories on musics.CategoryId = categories.CategoryId " +
                "inner join artists on musics.ArtistId = artists.ArtistId " +
                "WHERE categories.CategoryId = 2", connection);
            DataTable table1 = new DataTable();
            dataAdapter.Fill(table1);
            dgv_musics_jazz.DataSource = table1;
            connection.Close();
            connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=iMusic;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            connection.Open();
            dataAdapter = new SqlDataAdapter("Select TOP 10 musics.MusicId as Id ," +
                "musics.MusicName  as [Music Name] ," +
                " artists.ArtistName as [Artist Name] ," +
                " musics.ListeningCount as Count ," +
                " categories.CategoryName as [Category Name] from musics " +
                "inner join categories on musics.CategoryId = categories.CategoryId " +
                "inner join artists on musics.ArtistId = artists.ArtistId " +
                "WHERE categories.CategoryId = 3", connection);
            DataTable table2 = new DataTable();
            dataAdapter.Fill(table2);
            dgv_musics_classical.DataSource = table2;
            connection.Close();
        }

        void StyleDataGridView()
        {
            dgv_top_ten.BorderStyle = BorderStyle.None;
            dgv_top_ten.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dgv_top_ten.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv_top_ten.DefaultCellStyle.SelectionBackColor = Color.SeaGreen;
            dgv_top_ten.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dgv_top_ten.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgv_top_ten.EnableHeadersVisualStyles = false;
            dgv_top_ten.ColumnHeadersDefaultCellStyle.Font = new Font("MS Reference Sans Serif", 10);
            dgv_top_ten.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(37, 37, 38);
            dgv_top_ten.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dgv_musics_classical.BorderStyle = BorderStyle.None;
            dgv_musics_classical.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dgv_musics_classical.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv_musics_classical.DefaultCellStyle.SelectionBackColor = Color.SeaGreen;
            dgv_musics_classical.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dgv_musics_classical.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgv_musics_classical.EnableHeadersVisualStyles = false;
            dgv_musics_classical.ColumnHeadersDefaultCellStyle.Font = new Font("MS Reference Sans Serif", 10);
            dgv_musics_classical.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(37, 37, 38);
            dgv_musics_classical.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dgv_musics_jazz.BorderStyle = BorderStyle.None;
            dgv_musics_jazz.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dgv_musics_jazz.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv_musics_jazz.DefaultCellStyle.SelectionBackColor = Color.SeaGreen;
            dgv_musics_jazz.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dgv_musics_jazz.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgv_musics_jazz.EnableHeadersVisualStyles = false;
            dgv_musics_jazz.ColumnHeadersDefaultCellStyle.Font = new Font("MS Reference Sans Serif", 10);
            dgv_musics_jazz.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(37, 37, 38);
            dgv_musics_jazz.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dgv_musics_pop.BorderStyle = BorderStyle.None;
            dgv_musics_pop.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dgv_musics_pop.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv_musics_pop.DefaultCellStyle.SelectionBackColor = Color.SeaGreen;
            dgv_musics_pop.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dgv_musics_pop.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgv_musics_pop.EnableHeadersVisualStyles = false;
            dgv_musics_pop.ColumnHeadersDefaultCellStyle.Font = new Font("MS Reference Sans Serif", 10);
            dgv_musics_pop.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(37, 37, 38);
            dgv_musics_pop.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dgv_musics.BorderStyle = BorderStyle.None;
            dgv_musics.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dgv_musics.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv_musics.DefaultCellStyle.SelectionBackColor = Color.SeaGreen;
            dgv_musics.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dgv_musics.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgv_musics.EnableHeadersVisualStyles = false;
            dgv_musics.ColumnHeadersDefaultCellStyle.Font = new Font("MS Reference Sans Serif", 10);
            dgv_musics.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(37, 37, 38);
            dgv_musics.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dgv_albums.BorderStyle = BorderStyle.None;
            dgv_albums.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dgv_albums.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv_albums.DefaultCellStyle.SelectionBackColor = Color.SeaGreen;
            dgv_albums.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dgv_albums.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgv_albums.EnableHeadersVisualStyles = false;
            dgv_albums.ColumnHeadersDefaultCellStyle.Font = new Font("MS Reference Sans Serif", 10);
            dgv_albums.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(37, 37, 38);
            dgv_albums.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dgv_users.BorderStyle = BorderStyle.None;
            dgv_users.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dgv_users.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv_users.DefaultCellStyle.SelectionBackColor = Color.SeaGreen;
            dgv_users.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dgv_users.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgv_users.EnableHeadersVisualStyles = false;
            dgv_users.ColumnHeadersDefaultCellStyle.Font = new Font("MS Reference Sans Serif", 10);
            dgv_users.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(37, 37, 38);
            dgv_users.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dgv_top_countries.BorderStyle = BorderStyle.None;
            dgv_top_countries.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dgv_top_countries.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv_top_countries.DefaultCellStyle.SelectionBackColor = Color.SeaGreen;
            dgv_top_countries.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dgv_top_countries.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgv_top_countries.EnableHeadersVisualStyles = false;
            dgv_top_countries.ColumnHeadersDefaultCellStyle.Font = new Font("MS Reference Sans Serif", 10);
            dgv_top_countries.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(37, 37, 38);
            dgv_top_countries.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }


    }
}

