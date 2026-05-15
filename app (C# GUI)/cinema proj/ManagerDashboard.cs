using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace cinema_proj
{
    public partial class ManagerDashboard : Form
    {
        string connString = @"Data Source=.;Initial Catalog=CinemaSystem;Integrated Security=True;Encrypt=False";

        Panel headerPanel = new Panel();
        Chart chartRevenue = new Chart();
        Chart chartOccupancy = new Chart();
        Label lblStatus = new Label();

        public ManagerDashboard()
        {
            InitializeComponent();
            this.Load += ManagerDashboard_Load;
            SetupModernDesign();
        }

        private void SetupModernDesign()
        {
            this.Text = "Cinema Manager Analytics";
            this.Size = new Size(1100, 750); 
            this.BackColor = Color.White;
            this.StartPosition = FormStartPosition.CenterScreen;

            headerPanel.Dock = DockStyle.Top;
            headerPanel.Height = 70;
            headerPanel.BackColor = Color.Maroon;
            Label lblTitle = new Label
            {
                Text = "CINEMA PERFORMANCE DASHBOARD",
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(20, 15)
            };
            headerPanel.Controls.Add(lblTitle);
            this.Controls.Add(headerPanel);

            ConfigureChart(chartRevenue, "Revenue per Movie", new Point(30, 100));
            Series revSeries = new Series("Revenue")
            {
                ChartType = SeriesChartType.Pie,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            chartRevenue.Series.Add(revSeries);

            ConfigureChart(chartOccupancy, "Hall Occupancy %", new Point(540, 100));
            Series occSeries = new Series("Occupancy")
            {
                ChartType = SeriesChartType.Column,
                Color = Color.Maroon
            };
            chartOccupancy.Series.Add(occSeries);

            Button btnRefresh = new Button
            {
                Text = "REFRESH DATA",
                Size = new Size(180, 45),
                Location = new Point(460, 580),
                BackColor = Color.Maroon,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            btnRefresh.Click += (s, e) => LoadData();
            this.Controls.Add(btnRefresh);

            lblStatus.AutoSize = false;
            lblStatus.Size = new Size(400, 30);
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            lblStatus.ForeColor = Color.DimGray;
            this.Controls.Add(lblStatus);
        }

        private void ConfigureChart(Chart chart, string title, Point location)
        {
            chart.Size = new Size(480, 420);
            chart.Location = location;
            chart.BackColor = Color.White;
            chart.BorderlineColor = Color.LightGray;
            chart.BorderlineDashStyle = ChartDashStyle.Solid;

            chart.ChartAreas.Clear();
            ChartArea ca = new ChartArea("MainArea");

            if (chart == chartOccupancy)
            {
                ca.AxisX.Title = "Hall ID";
                ca.AxisX.TitleFont = new Font("Segoe UI", 10, FontStyle.Bold);
                ca.AxisX.TitleAlignment = StringAlignment.Center;

                ca.AxisY.Title = "Occupancy Rate (%)";
                ca.AxisY.TitleFont = new Font("Segoe UI", 10, FontStyle.Bold);
                ca.AxisY.TitleAlignment = StringAlignment.Center;
            }

            ca.BackColor = Color.White;
            ca.AxisX.LabelStyle.ForeColor = Color.Black;
            ca.AxisY.LabelStyle.ForeColor = Color.Black;
            ca.AxisX.LineColor = Color.LightGray;
            ca.AxisY.LineColor = Color.LightGray;
            ca.AxisX.MajorGrid.LineColor = Color.FromArgb(240, 240, 240);
            ca.AxisY.MajorGrid.LineColor = Color.FromArgb(240, 240, 240);
            chart.ChartAreas.Add(ca);

            chart.Titles.Clear();
            chart.Titles.Add(new Title(title, Docking.Top, new Font("Segoe UI", 14, FontStyle.Bold), Color.Maroon));

            if (chart == chartRevenue)
            {
                chart.Legends.Clear();
                Legend l = new Legend("MainLegend") { Docking = Docking.Bottom, BackColor = Color.White };
                chart.Legends.Add(l);
            }
            else
            {
                chart.Legends.Clear();
            }

            this.Controls.Add(chart);
        }

        private void LoadData()
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                try
                {
                    con.Open();

                    SqlDataAdapter daRev = new SqlDataAdapter("SELECT MovieName, TotalRevenue FROM dbo.vw_MovieRevenue", con);
                    DataTable dtRev = new DataTable();
                    daRev.Fill(dtRev);

                    chartRevenue.DataSource = dtRev;
                    Series sRev = chartRevenue.Series["Revenue"];
                    sRev.XValueMember = "MovieName";
                    sRev.YValueMembers = "TotalRevenue";
                    sRev.IsValueShownAsLabel = true;
                    sRev.Label = "#PERCENT{P0}";
                    sRev["PieLabelStyle"] = "Inside";
                    sRev.LabelForeColor = Color.White;
                    sRev.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                    sRev.LegendText = "#VALX";

                    chartRevenue.DataBind();

                    SqlDataAdapter daOcc = new SqlDataAdapter("SELECT HallID, OccupancyPercent FROM dbo.vw_HallOccupancy", con);
                    DataTable dtOcc = new DataTable();
                    daOcc.Fill(dtOcc);

                    chartOccupancy.DataSource = dtOcc;
                    Series sOcc = chartOccupancy.Series["Occupancy"];
                    sOcc.XValueMember = "HallID";
                    sOcc.YValueMembers = "OccupancyPercent";
                    sOcc.IsValueShownAsLabel = false;

                    chartOccupancy.DataBind();

                    lblStatus.Text = "Dashboard Updated: " + DateTime.Now.ToShortTimeString();
                    lblStatus.Location = new Point((this.ClientSize.Width - lblStatus.Width) / 2, 630);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Sync Error: " + ex.Message);
                }
            }
        }

        private void ManagerDashboard_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}