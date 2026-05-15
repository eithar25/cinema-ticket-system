using cinema_proj;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Linq;

namespace cinema_proj
{
    public partial class RegisterForm : Form
    {
        string connString = @"Data Source=.;Initial Catalog=CinemaSystem;Integrated Security=True;Encrypt=False";

        public RegisterForm() { InitializeComponent(); }

        private void btnRegister_Click_1(object sender, EventArgs e)
        {
            // Regex for Email Address
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            // Regex for Name
            string namePattern = @"^[a-zA-Z\s]{3,50}$";

            // If name is empty or not valid
            if (string.IsNullOrWhiteSpace(txtName.Text) || !Regex.IsMatch(txtName.Text, namePattern))
            {
                MessageBox.Show("Please fill a correct name in the required field");
                return;
            }

            // if Email is empty or not valid
            if (string.IsNullOrWhiteSpace(txtEmail.Text) || !Regex.IsMatch(txtEmail.Text, emailPattern))
            {
                MessageBox.Show("Please fill a correct Email Address in the required field (ex: name@domain.com)");
                return;
            }

            if (txtPassword.Text.Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters long");
                return;
            }

            if (txtPhone.Text.Length != 11 || !txtPhone.Text.All(char.IsDigit))
            {
                MessageBox.Show("Please enter a valid 11-digit phone number");
                return;
            }

            string connString = @"Data Source=.;Initial Catalog=CinemaSystem;Integrated Security=True;Encrypt=False";

            using (SqlConnection con = new SqlConnection(connString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("RegisterUser", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // These 5 parameters must match the SQL procedure exactly
                    cmd.Parameters.Add(new SqlParameter("@name", txtName.Text));
                    cmd.Parameters.Add(new SqlParameter("@email", txtEmail.Text));
                    cmd.Parameters.Add(new SqlParameter("@password", txtPassword.Text));
                    cmd.Parameters.Add(new SqlParameter("@phoneNumber", txtPhone.Text));

                    // Converting text to decimal for the database
                    decimal userBalance = 0;
                    if (decimal.TryParse(txtBalance.Text, out userBalance))
                    {
                        cmd.Parameters.Add(new SqlParameter("@balance", userBalance));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("@balance", 0.00m));
                    }

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Registration Successful! Redirecting to Login...");

                    // Go to Login Form
                    LoginForm login = new LoginForm();
                    login.Show();
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            Home Home = new Home();
            Home.Show();
            this.Hide();
        }
    }
}