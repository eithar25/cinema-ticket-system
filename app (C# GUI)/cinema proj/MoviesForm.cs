using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace cinema_proj
{
    public partial class MoviesForm : Form
    {
        int userID;
        public MoviesForm(int userID)
        {
            this.userID = userID;
            InitializeComponent();
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=CinemaSystem;Integrated Security=True;Encrypt=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Movie", con);
            cmd.CommandType = CommandType.Text;
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable movies = new DataTable();
            movies.Columns.Add("MovieID");
            movies.Columns.Add("Name");
            movies.Columns.Add("Duration");
            movies.Columns.Add("Rating");
            movies.Columns.Add("Classification");
            DataRow row;
            while (reader.Read())
            {
                row = movies.NewRow();
                row["MovieID"] = reader["MovieID"];
                row["Name"] = reader["Name"];
                row["Duration"] = reader["Duration"];
                row["Rating"] = reader["Rating"];
                row["Classification"] = reader["Classification"];
                movies.Rows.Add(row);
            }
            reader.Close();
            con.Close();
            MoviesGridView.DataSource = movies;
        }

        private void btn_show_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(chosen_movie.Text))
            {
                MessageBox.Show("Please enter a Movie ID.");
                return;
            }

            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=CinemaSystem;Integrated Security=True;Encrypt=False");
            try
            {
                con.Open();
                string sql = "SELECT COUNT(*) FROM Movie WHERE MovieID = @id";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", chosen_movie.Text);

                int count = (int)cmd.ExecuteScalar();

                if (count > 0)
                {
                    
                    ShowsForm showtimesWindow = new ShowsForm(userID, chosen_movie.Text);
                    showtimesWindow.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid Movie ID! This ID does not exist.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard(userID);
            dashboard.Show();
            this.Hide();
        }
    }
}