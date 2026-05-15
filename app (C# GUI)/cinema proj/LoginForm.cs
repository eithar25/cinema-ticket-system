using cinema_proj;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace cinema_proj
{
    public partial class LoginForm : Form
    {
        string connString = @"Data Source=.;Initial Catalog=CinemaSystem;Integrated Security=True;Encrypt=False";

        public LoginForm()
        {
            InitializeComponent();
        }

        //private void btnLogin_Click(object sender, EventArgs e)
        //{
        //    using (SqlConnection con = new SqlConnection(connString))
        //    {
        //        try
        //        {
        //            con.Open();

        //            string sql = "SELECT UserID FROM [User] WHERE Email=@email AND Password=@pass";
        //            SqlCommand cmd = new SqlCommand(sql, con);
        //            cmd.Parameters.AddWithValue("@email", loginEmail.Text);
        //            cmd.Parameters.AddWithValue("@pass", loginPassword.Text);

        //            object result = cmd.ExecuteScalar();

        //            if (result != null)
        //            {
        //                int userId = Convert.ToInt32(result);
        //                MessageBox.Show("Login Successful!");

        //                Dashboard dash = new Dashboard(userId);
        //                dash.Show();
        //                this.Hide();
        //            }
        //            else
        //            {
        //                MessageBox.Show("Error: User does not exist or invalid credentials. Please register first.");
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("Login Error: " + ex.Message);
        //        }
        //    }
        //}




        private void btnLogin_Click(object sender, EventArgs e)
        {
            string managerEmail = "admin@cinema.com";
            string managerPass = "admin123";

            if (loginEmail.Text == managerEmail && loginPassword.Text == managerPass)
            {
                MessageBox.Show("Welcome Manager!");
                ManagerDashboard adminDash = new ManagerDashboard(); 
                adminDash.Show();
                this.Hide();
                return; 
            }

            using (SqlConnection con = new SqlConnection(connString))
            {
                try
                {
                    con.Open();

                    string sql = "SELECT UserID FROM [User] WHERE Email=@email AND Password=@pass";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@email", loginEmail.Text);
                    cmd.Parameters.AddWithValue("@pass", loginPassword.Text);

                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        int userId = Convert.ToInt32(result);
                        MessageBox.Show("Login Successful!");

                        Dashboard dash = new Dashboard(userId);
                        dash.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Error: User does not exist or invalid credentials. Please register first.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Login Error: " + ex.Message);
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