namespace cinema_proj
{
    partial class SeatSelectionForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.flpSeats = new System.Windows.Forms.FlowLayoutPanel();
            this.lblSummary = new System.Windows.Forms.Label();
            this.btnBook = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblLegend = new System.Windows.Forms.Label();
            this.lblMovieInfo = new System.Windows.Forms.Label();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.lblSidebarTitle = new System.Windows.Forms.Label();
            this.lblScreen = new System.Windows.Forms.Label();
            this.btn_back = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.panelSidebar.SuspendLayout();
            this.SuspendLayout();
            // 
            // flpSeats
            // 
            this.flpSeats.AutoScroll = true;
            this.flpSeats.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.flpSeats.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpSeats.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpSeats.Location = new System.Drawing.Point(30, 130);
            this.flpSeats.Name = "flpSeats";
            this.flpSeats.Size = new System.Drawing.Size(580, 360);
            this.flpSeats.TabIndex = 0;
            this.flpSeats.WrapContents = false;
            // 
            // lblSummary
            // 
            this.lblSummary.BackColor = System.Drawing.Color.White;
            this.lblSummary.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSummary.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblSummary.Location = new System.Drawing.Point(20, 55);
            this.lblSummary.Name = "lblSummary";
            this.lblSummary.Size = new System.Drawing.Size(220, 90);
            this.lblSummary.TabIndex = 1;
            this.lblSummary.Text = "Selected: 0 seats\nTotal Price: $0.00";
            // 
            // btnBook
            // 
            this.btnBook.BackColor = System.Drawing.Color.DarkRed;
            this.btnBook.Enabled = false;
            this.btnBook.FlatAppearance.BorderSize = 0;
            this.btnBook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBook.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnBook.ForeColor = System.Drawing.Color.White;
            this.btnBook.Location = new System.Drawing.Point(20, 160);
            this.btnBook.Name = "btnBook";
            this.btnBook.Size = new System.Drawing.Size(220, 55);
            this.btnBook.TabIndex = 2;
            this.btnBook.Text = "Book Now";
            this.btnBook.UseVisualStyleBackColor = false;
            this.btnBook.Click += new System.EventHandler(this.btnBook_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(20, 230);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(220, 50);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblLegend
            // 
            this.lblLegend.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblLegend.ForeColor = System.Drawing.Color.White;
            this.lblLegend.Location = new System.Drawing.Point(30, 500);
            this.lblLegend.Name = "lblLegend";
            this.lblLegend.Size = new System.Drawing.Size(580, 35);
            this.lblLegend.TabIndex = 4;
            this.lblLegend.Text = "Green = Regular | Gold = VIP | Red = Premium | Blue = Selected | Gray = Reserved";
            // 
            // lblMovieInfo
            // 
            this.lblMovieInfo.AutoSize = true;
            this.lblMovieInfo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblMovieInfo.ForeColor = System.Drawing.Color.White;
            this.lblMovieInfo.Location = new System.Drawing.Point(20, 15);
            this.lblMovieInfo.Name = "lblMovieInfo";
            this.lblMovieInfo.Size = new System.Drawing.Size(305, 32);
            this.lblMovieInfo.TabIndex = 5;
            this.lblMovieInfo.Text = "Movie | Date | Time | Hall";
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panelHeader.Controls.Add(this.lblMovieInfo);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(900, 50);
            this.panelHeader.TabIndex = 6;
            // 
            // panelSidebar
            // 
            this.panelSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(240)))));
            this.panelSidebar.Controls.Add(this.btn_back);
            this.panelSidebar.Controls.Add(this.lblSidebarTitle);
            this.panelSidebar.Controls.Add(this.lblSummary);
            this.panelSidebar.Controls.Add(this.btnBook);
            this.panelSidebar.Controls.Add(this.btnCancel);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelSidebar.Location = new System.Drawing.Point(640, 50);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(260, 550);
            this.panelSidebar.TabIndex = 7;
            // 
            // lblSidebarTitle
            // 
            this.lblSidebarTitle.AutoSize = true;
            this.lblSidebarTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblSidebarTitle.ForeColor = System.Drawing.Color.DarkRed;
            this.lblSidebarTitle.Location = new System.Drawing.Point(20, 20);
            this.lblSidebarTitle.Name = "lblSidebarTitle";
            this.lblSidebarTitle.Size = new System.Drawing.Size(225, 38);
            this.lblSidebarTitle.TabIndex = 0;
            this.lblSidebarTitle.Text = "Booking Details";
            // 
            // lblScreen
            // 
            this.lblScreen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblScreen.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblScreen.ForeColor = System.Drawing.Color.White;
            this.lblScreen.Location = new System.Drawing.Point(30, 100);
            this.lblScreen.Name = "lblScreen";
            this.lblScreen.Size = new System.Drawing.Size(580, 25);
            this.lblScreen.TabIndex = 8;
            this.lblScreen.Text = "▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬  SCREEN  ▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬";
            this.lblScreen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_back
            // 
            this.btn_back.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_back.Location = new System.Drawing.Point(20, 287);
            this.btn_back.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(220, 40);
            this.btn_back.TabIndex = 12;
            this.btn_back.Text = "Back";
            this.btn_back.UseVisualStyleBackColor = true;
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
            // 
            // SeatSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.lblScreen);
            this.Controls.Add(this.panelSidebar);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.lblLegend);
            this.Controls.Add(this.flpSeats);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "SeatSelectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seat Selection";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelSidebar.ResumeLayout(false);
            this.panelSidebar.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.FlowLayoutPanel flpSeats;
        private System.Windows.Forms.Label lblSummary;
        private System.Windows.Forms.Button btnBook;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblLegend;
        private System.Windows.Forms.Label lblMovieInfo;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Label lblSidebarTitle;
        private System.Windows.Forms.Label lblScreen;
        private System.Windows.Forms.Button btn_back;
    }
}