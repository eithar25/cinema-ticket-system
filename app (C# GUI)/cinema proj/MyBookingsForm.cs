using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace cinema_proj
{
    public partial class MyBookingsForm : Form
    {
        private int userID;
        string connString = @"Data Source=.;Initial Catalog=CinemaSystem;Integrated Security=True;Encrypt=False";

        public MyBookingsForm(int userID)
        {
            InitializeComponent();
            this.userID = userID;
            LoadBookings();
        }

        private void LoadBookings()
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Open();
                string query = @"
                    SELECT 
                        b.BookingID,
                        m.Name AS MovieName,
                        s.Date AS ShowDate,
                        s.start_time AS ShowTime,
                        h.HallID,
                        b.Status AS BookingStatus,
                        b.Booking_date AS BookingDate,
                        ISNULL(p.Status, 'Pending') AS PaymentStatus,
                        dbo.fn_CalculateTotalPrice(b.BookingID, 0) AS TotalPrice,
                        STRING_AGG(CAST(hs.SeatNumber AS VARCHAR), ', ') AS Seats
                    FROM Booking b
                    JOIN Show s ON b.ShowID = s.ShowID
                    JOIN Movie m ON s.MovieID = m.MovieID
                    JOIN Hall h ON s.HallID = h.HallID
                    LEFT JOIN Payment p ON b.BookingID = p.BookingID
                    LEFT JOIN Has hs ON b.BookingID = hs.BookingID
                    WHERE b.UserID = @UserID
                    GROUP BY b.BookingID, m.Name, s.Date, s.start_time, h.HallID, 
                             b.Status, b.Booking_date, p.Status
                    ORDER BY b.Booking_date DESC";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UserID", userID);

                SqlDataReader reader = cmd.ExecuteReader();
                DataTable bookingsTable = new DataTable();
                bookingsTable.Load(reader);
                reader.Close();

                BookingsGridView.DataSource = bookingsTable;
            }

            if (BookingsGridView.Columns["ShowDate"] != null)
                BookingsGridView.Columns["ShowDate"].DefaultCellStyle.Format = "yyyy-MM-dd";
            if (BookingsGridView.Columns["ShowTime"] != null)
                BookingsGridView.Columns["ShowTime"].DefaultCellStyle.Format = "HH:mm";
            if (BookingsGridView.Columns["BookingDate"] != null)
                BookingsGridView.Columns["BookingDate"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm";
            if (BookingsGridView.Columns["TotalPrice"] != null)
                BookingsGridView.Columns["TotalPrice"].DefaultCellStyle.Format = "C";

            BookingsGridView.CellFormatting += BookingsGridView_CellFormatting;
        }

        private void BookingsGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (BookingsGridView.Columns[e.ColumnIndex].Name == "BookingStatus")
            {
                string status = e.Value?.ToString();
                if (status == "Confirmed")
                    e.CellStyle.ForeColor = Color.Green;
                else if (status == "Cancelled")
                    e.CellStyle.ForeColor = Color.Red;
                else if (status == "Pending")
                    e.CellStyle.ForeColor = Color.Orange;
            }
            else if (BookingsGridView.Columns[e.ColumnIndex].Name == "PaymentStatus")
            {
                string status = e.Value?.ToString();
                if (status == "Success")
                    e.CellStyle.ForeColor = Color.Green;
                else if (status == "Refunded" || status.Contains("Refunded"))
                    e.CellStyle.ForeColor = Color.Blue;
                else if (status == "Failed: Insufficient Funds")
                    e.CellStyle.ForeColor = Color.Red;
            }
        }

        private void btnCancelBooking_Click(object sender, EventArgs e)
        {
            if (BookingsGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a booking to cancel.", "Select Booking", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow row = BookingsGridView.SelectedRows[0];
            int bookingId = Convert.ToInt32(row.Cells["BookingID"].Value);
            string status = row.Cells["BookingStatus"].Value.ToString();
            string movieName = row.Cells["MovieName"].Value.ToString();
            DateTime showDate = Convert.ToDateTime(row.Cells["ShowDate"].Value);
            TimeSpan showTime = (TimeSpan)row.Cells["ShowTime"].Value;
            DateTime showDateTime = showDate.Add(showTime);

            if (status == "Cancelled")
            {
                MessageBox.Show("This booking is already cancelled.", "Already Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (showDateTime < DateTime.Now.AddHours(24))
            {
                MessageBox.Show("Cannot cancel a booking within 24 hours of showtime.",
                    "Cancellation Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Cancel booking for '{movieName}' on {showDate:yyyy-MM-dd}?\n\nRefund will be added to your balance.",
                "Confirm Cancellation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                CancelBooking(bookingId);
            }
        }

        private void CancelBooking(int bookingId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connString))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("CancelBooking", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@bookingId", bookingId);
                    cmd.Parameters.AddWithValue("@userId", userID);
                    SqlParameter refundParam = new SqlParameter("@refundAmount", SqlDbType.Decimal)
                    {
                        Direction = ParameterDirection.Output,
                        Precision = 10,
                        Scale = 2
                    };
                    cmd.Parameters.Add(refundParam);

                    cmd.ExecuteNonQuery();

                    decimal refundAmount = Convert.ToDecimal(refundParam.Value);

                    MessageBox.Show(
                        $"Booking cancelled successfully!\nRefund Amount: {refundAmount:C} has been added to your balance.",
                        "Cancellation Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadBookings();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cancelling booking: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadBookings();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}