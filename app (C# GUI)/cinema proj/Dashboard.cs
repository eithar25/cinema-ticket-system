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

namespace cinema_proj
{
    public partial class Dashboard : Form
    {
        private int UserID;
        string connString = @"Data Source=.;Initial Catalog=CinemaSystem;Integrated Security=True;Encrypt=False";

        public Dashboard(int UserId)
        {
            InitializeComponent();
            this.UserID = UserId;
        }

        private void btn_MoviesOption_Click(object sender, EventArgs e)
        {
            MoviesForm mov = new MoviesForm(UserID);
            mov.Show();
            this.Hide();
        }

        private void btn_BookingsOption_Click(object sender, EventArgs e)
        {
            MyBookingsForm bookings = new MyBookingsForm(UserID);
            bookings.Show();
            this.Hide();
        }

        private void btn_ViewProfile_Click(object sender, EventArgs e)
        {
            Profile profile = new Profile(UserID);
            profile.Show();
            this.Hide();
        }
    }
}