using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace cinema_proj
{
    public partial class SeatSelectionForm : Form
    {
        private int userID;
        private int showId;
        private string movieName;
        private int hallId;
        private DateTime showDate;
        private TimeSpan showTime;
        private List<int> selectedSeats = new List<int>();
        private Dictionary<int, decimal> seatPrices = new Dictionary<int, decimal>();
        private Dictionary<int, string> seatTypes = new Dictionary<int, string>();
        string connString = @"Data Source=.;Initial Catalog=CinemaSystem;Integrated Security=True;Encrypt=False";

        public SeatSelectionForm(int userID, int showId, string movieName, int hallId, DateTime showDate, TimeSpan showTime)
        {
            InitializeComponent();
            this.userID = userID;
            this.showId = showId;
            this.movieName = movieName;
            this.hallId = hallId;
            this.showDate = showDate;
            this.showTime = showTime;
            this.Text = $"Select Seats - {movieName}";
            lblMovieInfo.Text = $"{movieName} | {showDate:yyyy-MM-dd} | {showTime:hh\\:mm} | Hall {hallId}";
            LoadSeats();
        }

        private void LoadSeats()
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Open();
                string query = @"
                    SELECT 
                        st.SeatNumber,
                        st.Raw_number AS RowNumber,
                        st.Type,
                        st.Price,
                        ISNULL(i.Status, 'Available') AS Status
                    FROM Seat st
                    LEFT JOIN Includes i ON st.SeatNumber = i.SeatNumber 
                        AND st.HallID = i.HallID AND i.ShowID = @ShowID
                    WHERE st.HallID = @HallID
                    ORDER BY st.Raw_number, st.SeatNumber";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ShowID", showId);
                cmd.Parameters.AddWithValue("@HallID", hallId);

                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                reader.Close();

                flpSeats.Controls.Clear();
                selectedSeats.Clear();
                seatPrices.Clear();
                seatTypes.Clear();

                int currentRow = -1;
                FlowLayoutPanel rowPanel = null;

                foreach (DataRow row in dt.Rows)
                {
                    int seatNum = Convert.ToInt32(row["SeatNumber"]);
                    int rowNum = Convert.ToInt32(row["RowNumber"]);
                    string type = row["Type"].ToString();
                    decimal price = Convert.ToDecimal(row["Price"]);
                    string status = row["Status"].ToString();

                    seatPrices[seatNum] = price;
                    seatTypes[seatNum] = type;

                    if (rowNum != currentRow)
                    {
                        currentRow = rowNum;
                        rowPanel = new FlowLayoutPanel
                        {
                            FlowDirection = FlowDirection.LeftToRight,
                            AutoSize = true,
                            AutoSizeMode = AutoSizeMode.GrowAndShrink,
                            Margin = new Padding(5)
                        };

                        Label lblRow = new Label
                        {
                            Text = $"Row {rowNum}",
                            Width = 50,
                            Height = 40,
                            TextAlign = ContentAlignment.MiddleCenter,
                            Font = new Font("Arial", 8, FontStyle.Bold),
                            ForeColor = Color.White
                        };
                        rowPanel.Controls.Add(lblRow);
                        flpSeats.Controls.Add(rowPanel);
                    }

                    Button btnSeat = new Button
                    {
                        Text = seatNum.ToString(),
                        Width = 50,
                        Height = 40,
                        Tag = seatNum,
                        Font = new Font("Arial", 9, FontStyle.Bold),
                        FlatStyle = FlatStyle.Flat,
                        Margin = new Padding(3)
                    };

                    if (status == "Reserved")
                    {
                        btnSeat.BackColor = Color.Gray;
                        btnSeat.Enabled = false;
                    }
                    else
                    {
                        switch (type)
                        {
                            case "VIP":
                                btnSeat.BackColor = Color.Gold;
                                break;
                            case "Premium":
                                btnSeat.BackColor = Color.LightCoral;
                                break;
                            default:
                                btnSeat.BackColor = Color.LightGreen;
                                break;
                        }
                        btnSeat.Click += BtnSeat_Click;
                    }

                    ToolTip tt = new ToolTip();
                    tt.SetToolTip(btnSeat, $"Type: {type}\nPrice: {price:C}");

                    rowPanel.Controls.Add(btnSeat);
                }
            }

            UpdateSummary();
        }

        private void BtnSeat_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int seatNum = (int)btn.Tag;

            if (selectedSeats.Contains(seatNum))
            {
                selectedSeats.Remove(seatNum);
                string type = seatTypes[seatNum];
                switch (type)
                {
                    case "VIP": btn.BackColor = Color.Gold; break;
                    case "Premium": btn.BackColor = Color.LightCoral; break;
                    default: btn.BackColor = Color.LightGreen; break;
                }
            }
            else
            {
                selectedSeats.Add(seatNum);
                btn.BackColor = Color.DodgerBlue;
            }

            UpdateSummary();
        }

        private void UpdateSummary()
        {
            decimal totalPrice = 0;
            int regularCount = 0, vipCount = 0, premiumCount = 0;

            foreach (int seat in selectedSeats)
            {
                totalPrice += seatPrices[seat];
                switch (seatTypes[seat])
                {
                    case "VIP": vipCount++; break;
                    case "Premium": premiumCount++; break;
                    default: regularCount++; break;
                }
            }

            lblSummary.Text = $"Selected: {selectedSeats.Count} seats\n" +
                             $"Regular: {regularCount} | VIP: {vipCount} | Premium: {premiumCount}\n" +
                             $"Total Price: {totalPrice:C}";

            btnBook.Enabled = selectedSeats.Count > 0;
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            if (selectedSeats.Count == 0)
            {
                MessageBox.Show("Please select at least one seat.", "No Seats Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal totalPrice = selectedSeats.Sum(s => seatPrices[s]);
            string seatList = string.Join(", ", selectedSeats.OrderBy(s => s));

            DialogResult result = MessageBox.Show(
                $"Movie: {movieName}\n" +
                $"Date: {showDate:yyyy-MM-dd}\n" +
                $"Time: {showTime:hh\\:mm}\n" +
                $"Hall: {hallId}\n" +
                $"Seats: {seatList}\n" +
                $"Total Price: {totalPrice:C}\n\n" +
                $"Proceed with booking?",
                "Confirm Booking",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                BookTickets();
            }
        }

        private void BookTickets()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connString))
                {
                    con.Open();
                    using (SqlTransaction trans = con.BeginTransaction())
                    {
                        try
                        {
                            SqlCommand cmdBooking = new SqlCommand(
                                "INSERT INTO Booking (ShowID, UserID, Status, Booking_date) OUTPUT INSERTED.BookingID VALUES (@ShowID, @UserID, 'Pending', GETDATE())",
                                con, trans);
                            cmdBooking.Parameters.AddWithValue("@ShowID", showId);
                            cmdBooking.Parameters.AddWithValue("@UserID", userID);
                            int bookingId = (int)cmdBooking.ExecuteScalar();

                            foreach (int seatNum in selectedSeats)
                            {
                                SqlCommand cmdHas = new SqlCommand(
                                    "INSERT INTO Has (BookingID, SeatNumber, HallID) VALUES (@BookingID, @SeatNumber, @HallID)",
                                    con, trans);
                                cmdHas.Parameters.AddWithValue("@BookingID", bookingId);
                                cmdHas.Parameters.AddWithValue("@SeatNumber", seatNum);
                                cmdHas.Parameters.AddWithValue("@HallID", hallId);
                                cmdHas.ExecuteNonQuery();
                            }

                            foreach (int seatNum in selectedSeats)
                            {
                                SqlCommand cmdIncludes = new SqlCommand(
                                    "UPDATE Includes SET Status = 'Reserved' WHERE ShowID = @ShowID AND HallID = @HallID AND SeatNumber = @SeatNumber",
                                    con, trans);
                                cmdIncludes.Parameters.AddWithValue("@ShowID", showId);
                                cmdIncludes.Parameters.AddWithValue("@HallID", hallId);
                                cmdIncludes.Parameters.AddWithValue("@SeatNumber", seatNum);
                                cmdIncludes.ExecuteNonQuery();
                            }

                            SqlCommand cmdPayment = new SqlCommand("ProcessBalancePayment", con, trans);
                            cmdPayment.CommandType = CommandType.StoredProcedure;
                            cmdPayment.Parameters.AddWithValue("@bookingId", bookingId);
                            cmdPayment.Parameters.AddWithValue("@userId", userID);
                            cmdPayment.ExecuteNonQuery();

                            SqlCommand cmdCheck = new SqlCommand(
                                "SELECT Status FROM Booking WHERE BookingID = @BookingID",
                                con, trans);
                            cmdCheck.Parameters.AddWithValue("@BookingID", bookingId);
                            string bookingStatus = cmdCheck.ExecuteScalar().ToString();

                            trans.Commit();

                            if (bookingStatus == "Confirmed")
                            {
                                MessageBox.Show(
                                    $"Booking Successful!\n\n" +
                                    $"Booking ID: {bookingId}\n" +
                                    $"Movie: {movieName}\n" +
                                    $"Date: {showDate:yyyy-MM-dd} | Time: {showTime:hh\\:mm}\n" +
                                    $"Seats: {string.Join(", ", selectedSeats.OrderBy(s => s))}\n" +
                                    $"Total: {selectedSeats.Sum(s => seatPrices[s]):C}",
                                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.DialogResult = DialogResult.OK;
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show(
                                    "Booking failed due to insufficient balance.\nPlease add funds to your account.",
                                    "Payment Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.DialogResult = DialogResult.Cancel;
                                this.Close();
                            }
                        }
                        catch (Exception ex)
                        {
                            trans.Rollback();
                            throw ex;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Booking Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btn_back_Click(object sender, EventArgs e)
        {

            Dashboard dashboard = new Dashboard(userID);
            dashboard.Show();
            this.Hide();
        }
    }
}