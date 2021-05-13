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
    public partial class AdminPage : Form
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter dataAdapter;
        private string txt_music_musicid;
        private string txt_artist_artistid;
        private string txt_album_albumid;
        private string txt_category_categoryid;

        public AdminPage()
        {
            InitializeComponent();
        }

        private void AdminPage_Load(object sender, EventArgs e)
        {
            GetMusics();
            GetAlbums();
            GetArtists();
            GetCategories();
            StyleDataGridView();
        }

        void GetMusics()
        {
            connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=iMusic;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            connection.Open();
            dataAdapter = new SqlDataAdapter("SELECT * FROM musics", connection);
            DataTable table = new DataTable();
            dataAdapter.Fill(table);
            dgv_musics.DataSource = table;
            connection.Close();
        }
        void GetAlbums()
        {
            connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=iMusic;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            connection.Open();
            dataAdapter = new SqlDataAdapter("SELECT * FROM albums", connection);
            DataTable table = new DataTable();
            dataAdapter.Fill(table);
            dgv_albums.DataSource = table;
            connection.Close();
        }
        void GetArtists()
        {
            connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=iMusic;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            connection.Open();
            dataAdapter = new SqlDataAdapter("SELECT * FROM artists", connection);
            DataTable table = new DataTable();
            dataAdapter.Fill(table);
            dgv_artists.DataSource = table;
            connection.Close();
        }
        void GetCategories()
        {
            connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=iMusic;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            connection.Open();
            dataAdapter = new SqlDataAdapter("SELECT * FROM categories", connection);
            DataTable table = new DataTable();
            dataAdapter.Fill(table);
            dgv_categories.DataSource = table;
            connection.Close();
        }

        private void label19_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dgv_musics_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txt_music_musicid = dgv_musics.CurrentRow.Cells[0].Value.ToString();
            txt_music_artistid.Text = dgv_musics.CurrentRow.Cells[1].Value.ToString();
            txt_music_albumid.Text = dgv_musics.CurrentRow.Cells[2].Value.ToString();
            txt_music_categoryid.Text = dgv_musics.CurrentRow.Cells[3].Value.ToString();
            txt_music_musicname.Text = dgv_musics.CurrentRow.Cells[4].Value.ToString();
            dtp_music.Text = dgv_musics.CurrentRow.Cells[5].Value.ToString();
            txt_music_time.Text = dgv_musics.CurrentRow.Cells[6].Value.ToString();
        }

        private void dgv_artists_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txt_artist_artistid = dgv_artists.CurrentRow.Cells[0].Value.ToString();
            txt_artist_name.Text = dgv_artists.CurrentRow.Cells[1].Value.ToString();
            txt_artist_cc.Text = dgv_artists.CurrentRow.Cells[2].Value.ToString();
        }

        private void dgv_categories_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

            txt_category_categoryid = dgv_categories.CurrentRow.Cells[0].Value.ToString();
            txt_category_name.Text = dgv_categories.CurrentRow.Cells[1].Value.ToString();
        }

        private void dgv_albums_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txt_album_albumid = dgv_albums.CurrentRow.Cells[0].Value.ToString();
            txt_album_artistid.Text = dgv_albums.CurrentRow.Cells[1].Value.ToString();
            txt_album_categoryid.Text = dgv_albums.CurrentRow.Cells[2].Value.ToString();
            txt_album_musicid.Text = dgv_albums.CurrentRow.Cells[3].Value.ToString();
            txt_album_name.Text = dgv_albums.CurrentRow.Cells[4].Value.ToString();
            dtp_album.Text = dgv_albums.CurrentRow.Cells[5].Value.ToString();
        }

        private void btn_music_add_Click(object sender, EventArgs e)
        {
            if (txt_music_albumid.Text != "")
            {
                string queryString = "INSERT INTO musics(ArtistId,AlbumId,CategoryId,MusicName,MusicDate,Time) VALUES(@artistid,@albumid,@categoryid,@musicname,@musicdate,@time)";
                command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@artistid", Convert.ToInt32(txt_music_artistid.Text));
                command.Parameters.AddWithValue("@albumid", Convert.ToInt32(txt_music_albumid.Text));
                command.Parameters.AddWithValue("@categoryid", Convert.ToInt32(txt_music_categoryid.Text));
                command.Parameters.AddWithValue("@musicname", txt_music_musicname.Text);
                command.Parameters.AddWithValue("@musicdate", dtp_music.Value);
                command.Parameters.AddWithValue("@time", txt_music_time.Text);
            }
            else
            {
                string queryString = "INSERT INTO musics(ArtistId,CategoryId,MusicName,MusicDate,Time) VALUES(@artistid,@categoryid,@musicname,@musicdate,@time)";
                command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@artistid", Convert.ToInt32(txt_music_artistid.Text));
                command.Parameters.AddWithValue("@categoryid", Convert.ToInt32(txt_music_categoryid.Text));
                command.Parameters.AddWithValue("@musicname", txt_music_musicname.Text);
                command.Parameters.AddWithValue("@musicdate", dtp_music.Value);
                command.Parameters.AddWithValue("@time", txt_music_time.Text);
            }
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            GetMusics();

        }

        private void btn_artist_add_Click(object sender, EventArgs e)
        {

            string queryString = "INSERT INTO artists(ArtistName,CountryCode) VALUES(@artistname,@countrycode)";
            command = new SqlCommand(queryString, connection);
            command.Parameters.AddWithValue("@artistname", txt_artist_name.Text);
            command.Parameters.AddWithValue("@countrycode", txt_artist_cc.Text);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            GetArtists();
        }

        private void btn_album_add_Click(object sender, EventArgs e)
        {
            string queryString = "INSERT INTO albums(ArtistId,CategoryId,MusicId,AlbumName,AlbumDate) VALUES(@artistid,@categoryid,@musicid,@albumname,@albumdate)";
            command = new SqlCommand(queryString, connection);
            command.Parameters.AddWithValue("@artistid", Convert.ToInt32(txt_album_artistid.Text));
            command.Parameters.AddWithValue("@categoryid", Convert.ToInt32(txt_album_categoryid.Text));
            command.Parameters.AddWithValue("@musicid", Convert.ToInt32(txt_album_musicid.Text));
            command.Parameters.AddWithValue("@albumname", txt_album_name.Text);
            command.Parameters.AddWithValue("@albumdate", dtp_album.Value);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            GetAlbums();
        }

        private void btn_categories_add_Click(object sender, EventArgs e)
        {
            string queryString = "INSERT INTO categories(CategoryName) VALUES(@categoryname)";
            command = new SqlCommand(queryString, connection);
            command.Parameters.AddWithValue("@categoryname", txt_category_name.Text);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            GetCategories();
        }

        private void btn_music_delete_Click(object sender, EventArgs e)
        {
            string queryString = "DELETE FROM musics WHERE MusicId=@musicid";
            command = new SqlCommand(queryString, connection);
            command.Parameters.AddWithValue("@musicid", Convert.ToInt32(txt_music_musicid));
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            GetMusics();

        }

        private void btn_artist_delete_Click(object sender, EventArgs e)
        {
            string queryString = "DELETE FROM artists WHERE ArtistId=@artistid";
            command = new SqlCommand(queryString, connection);
            command.Parameters.AddWithValue("@artistid", Convert.ToInt32(txt_artist_artistid));
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            GetArtists();
        }

        private void btn_album_delete_Click(object sender, EventArgs e)
        {
            string queryString = "DELETE FROM albums WHERE AlbumId=@albumid";
            command = new SqlCommand(queryString, connection);
            command.Parameters.AddWithValue("@albumid", Convert.ToInt32(txt_album_albumid));
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            GetAlbums();
        }

        private void btn_categories_delete_Click(object sender, EventArgs e)
        {
            string queryString = "DELETE FROM categories WHERE CategoryId=@categoryid";
            command = new SqlCommand(queryString, connection);
            command.Parameters.AddWithValue("@categoryid", Convert.ToInt32(txt_category_categoryid));
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            GetCategories();
        }

        private void btn_music_update_Click(object sender, EventArgs e)
        {
            if (txt_music_albumid.Text != "")
            {
                string queryString = "UPDATE musics SET ArtistId=@artistid,AlbumId=@albumid,CategoryId=@categoryid,MusicName=@musicname,MusicDate=@musicdate,Time=@time WHERE Musicid=@musicid";
                command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@musicid", Convert.ToInt32(txt_music_musicid));
                command.Parameters.AddWithValue("@artistid", Convert.ToInt32(txt_music_artistid.Text));
                command.Parameters.AddWithValue("@albumid", Convert.ToInt32(txt_music_albumid.Text));
                command.Parameters.AddWithValue("@categoryid", Convert.ToInt32(txt_music_categoryid.Text));
                command.Parameters.AddWithValue("@musicname", txt_music_musicname.Text);
                command.Parameters.AddWithValue("@musicdate", dtp_music.Value);
                command.Parameters.AddWithValue("@time", txt_music_time.Text);
            }
            else
            {
                string queryString = "UPDATE musics SET ArtistId=@artistid,CategoryId=@categoryid,MusicName=@musicname,MusicDate=@musicdate,Time=@time WHERE Musicid=@musicid";
                command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@musicid", Convert.ToInt32(txt_music_musicid));
                command.Parameters.AddWithValue("@artistid", Convert.ToInt32(txt_music_artistid.Text));
                command.Parameters.AddWithValue("@categoryid", Convert.ToInt32(txt_music_categoryid.Text));
                command.Parameters.AddWithValue("@musicname", txt_music_musicname.Text);
                command.Parameters.AddWithValue("@musicdate", dtp_music.Value);
                command.Parameters.AddWithValue("@time", txt_music_time.Text);
            }
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            GetMusics();
        }

        private void btn_artist_update_Click(object sender, EventArgs e)
        {
            string queryString = "UPDATE artists SET ArtistName=@artistname,CountryCode=@countrycode WHERE ArtistId=@artistid";
            command = new SqlCommand(queryString, connection);
            command.Parameters.AddWithValue("@artistid", txt_artist_artistid);
            command.Parameters.AddWithValue("@artistname", txt_artist_name.Text);
            command.Parameters.AddWithValue("@countrycode", txt_artist_cc.Text);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            GetArtists();
        }

        private void btn_album_update_Click(object sender, EventArgs e)
        {
            string queryString = "UPDATE albums SET ArtistId=@artistid,CategoryId=@categoryid,MusicId=@musicid,AlbumName=@albumname,AlbumDate=@albumdate WHERE AlbumId=@albumid";
            command = new SqlCommand(queryString, connection);
            command.Parameters.AddWithValue("@albumid", Convert.ToInt32(txt_album_albumid));
            command.Parameters.AddWithValue("@artistid", Convert.ToInt32(txt_album_artistid.Text));
            command.Parameters.AddWithValue("@categoryid", Convert.ToInt32(txt_album_categoryid.Text));
            command.Parameters.AddWithValue("@musicid", Convert.ToInt32(txt_album_musicid.Text));
            command.Parameters.AddWithValue("@albumname", txt_album_name.Text);
            command.Parameters.AddWithValue("@albumdate", dtp_album.Value);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            GetAlbums();
        }

        private void btn_categories_update_Click(object sender, EventArgs e)
        {
            string queryString = "UPDATE categories SET CategoryName=@categoryname WHERE CategoryId=@categoryid";
            command = new SqlCommand(queryString, connection);
            command.Parameters.AddWithValue("@categoryid", Convert.ToInt32(txt_category_categoryid));
            command.Parameters.AddWithValue("@categoryname", txt_category_name.Text);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            GetCategories();
        }

        void StyleDataGridView()
        {
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

            dgv_artists.BorderStyle = BorderStyle.None;
            dgv_artists.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dgv_artists.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv_artists.DefaultCellStyle.SelectionBackColor = Color.SeaGreen;
            dgv_artists.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dgv_artists.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgv_artists.EnableHeadersVisualStyles = false;
            dgv_artists.ColumnHeadersDefaultCellStyle.Font = new Font("MS Reference Sans Serif", 10);
            dgv_artists.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(37, 37, 38);
            dgv_artists.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dgv_categories.BorderStyle = BorderStyle.None;
            dgv_categories.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dgv_categories.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv_categories.DefaultCellStyle.SelectionBackColor = Color.SeaGreen;
            dgv_categories.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dgv_categories.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgv_categories.EnableHeadersVisualStyles = false;
            dgv_categories.ColumnHeadersDefaultCellStyle.Font = new Font("MS Reference Sans Serif", 10);
            dgv_categories.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(37, 37, 38);
            dgv_categories.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
