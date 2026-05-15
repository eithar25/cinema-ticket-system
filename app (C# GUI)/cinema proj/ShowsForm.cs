using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace cinema_proj
{
    public partial class ShowsForm : Form
    {
        private int userID;
        private string movieID;
        private string movieName;
        string connString = @"Data Source=.;Initial Catalog=CinemaSystem;Integrated Security=True;Encrypt=False";

        public ShowsForm(int userID, string MovieID)
        {
            InitializeComponent();
            this.userID = userID;
            this.movieID = MovieID;

            GetMovieName();
            this.Text = "Showtimes - " + movieName;

            LoadShowtimes();
        }

        private void GetMovieName()
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Name FROM Movie WHERE MovieID = @id", con);
                cmd.Parameters.AddWithValue("@id", movieID);
                object result = cmd.ExecuteScalar();
                movieName = result != null ? result.ToString() : "Unknown Movie";
            }
        }

        private void LoadShowtimes()
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Open();
                string query = @"
                    SELECT 
                        s.ShowID,
                        s.Date AS ShowDate,
                        s.start_time AS ShowTime,
                        h.HallID,
                        h.Capacity,
                        COUNT(DISTINCT CASE WHEN i.Status = 'Reserved' THEN hs.SeatNumber END) AS BookedSeats,
                        h.Capacity - COUNT(DISTINCT CASE WHEN i.Status = 'Reserved' THEN hs.SeatNumber END) AS AvailableSeats
                    FROM Show s
                    JOIN Hall h ON s.HallID = h.HallID
                    LEFT JOIN Includes i ON s.ShowID = i.ShowID AND i.Status = 'Reserved'
                    LEFT JOIN Has hs ON i.SeatNumber = hs.SeatNumber AND i.HallID = hs.HallID
                    WHERE s.MovieID = @MovieID AND s.Date >= CAST(GETDATE() AS DATE)
                    GROUP BY s.ShowID, s.Date, s.start_time, h.HallID, h.Capacity
                    ORDER BY s.Date, s.start_time";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@MovieID", movieID);

                SqlDataReader reader = cmd.ExecuteReader();
                DataTable showsTable = new DataTable();
                showsTable.Load(reader);
                reader.Close();

                ShowsGridView.DataSource = showsTable;
            }

            if (ShowsGridView.Columns["ShowID"] != null)
                ShowsGridView.Columns["ShowID"].Visible = false;
            if (ShowsGridView.Columns["ShowDate"] != null)
                ShowsGridView.Columns["ShowDate"].DefaultCellStyle.Format = "yyyy-MM-dd";
            if (ShowsGridView.Columns["ShowTime"] != null)
                ShowsGridView.Columns["ShowTime"].DefaultCellStyle.Format = "HH:mm";
        }

        private void btnSelectShowtime_Click(object sender, EventArgs e)
        {
            if (ShowsGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a showtime from the table.");
                return;
            }

            DataGridViewRow selectedRow = ShowsGridView.SelectedRows[0];
            int showId = Convert.ToInt32(selectedRow.Cells["ShowID"].Value);
            int hallId = Convert.ToInt32(selectedRow.Cells["HallID"].Value);
            int availableSeats = Convert.ToInt32(selectedRow.Cells["AvailableSeats"].Value);
            DateTime showDate = Convert.ToDateTime(selectedRow.Cells["ShowDate"].Value);
            TimeSpan showTime = (TimeSpan)selectedRow.Cells["ShowTime"].Value;

            if (availableSeats <= 0)
            {
                MessageBox.Show("No available seats for this showtime.", "Sold Out", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SeatSelectionForm seatForm = new SeatSelectionForm(
                userID, showId, movieName, hallId, showDate, showTime);
            seatForm.ShowDialog();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard(userID);
            dashboard.Show();
            this.Hide();
        }
    }
}