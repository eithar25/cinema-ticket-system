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
    public partial class Profile : Form
    {
        private int UserID;
        string connString = @"Data Source=.;Initial Catalog=CinemaSystem;Integrated Security=True;";

        public Profile(int UserId)
        {
            InitializeComponent();
            this.UserID = UserId;
        }

        private void LoadUser()
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Open();
                string query = @"SELECT Name, balance, Email, Password 
                                 FROM [User] 
                                 WHERE UserID = @Id";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", UserID);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txt_name.Text = reader["Name"].ToString();
                            txt_balance.Text = reader["balance"].ToString();
                            txt_email.Text = reader["Email"].ToString();
                            txt_pass.Text = reader["Password"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("User not found");
                        }
                    }
                }
            }
        }

        private void UpdateUser()
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Open();
                string query = @"UPDATE [User] 
                                 SET Name = @Name, 
                                     balance = @Balance, 
                                     Email = @Email, 
                                     Password = @Password
                                 WHERE UserID = @Id";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Name", txt_name.Text);
                    cmd.Parameters.AddWithValue("@Balance", decimal.Parse(txt_balance.Text));
                    cmd.Parameters.AddWithValue("@Email", txt_email.Text);
                    cmd.Parameters.AddWithValue("@Password", txt_pass.Text);
                    cmd.Parameters.AddWithValue("@Id", UserID);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Data updated successfully");
                    }
                    else
                    {
                        MessageBox.Show("Update failed");
                    }
                }
            }
        }

        private void ApplyStyles()
        {
            TextBox[] textBoxes = { txt_name, txt_balance, txt_email, txt_pass };
            foreach (TextBox txt in textBoxes)
            {
                txt.Size = new Size(250, 35);
                txt.Font = new Font("Segoe UI", 11);
                txt.BackColor = Color.White;
                txt.ForeColor = Color.Black;
                txt.BorderStyle = BorderStyle.FixedSingle;
            }
        }

        private void Profile_Load(object sender, EventArgs e)
        {
            LoadUser();
            ApplyStyles();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateUser();
            LoadUser();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard(UserID);
            dashboard.Show();
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }
    }
}