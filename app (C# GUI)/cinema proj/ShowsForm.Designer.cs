namespace cinema_proj
{
    partial class ShowsForm
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
            this.ShowsGridView = new System.Windows.Forms.DataGridView();
            this.btnSelectShowtime = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblMovieName = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelHeader = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.ShowsGridView)).BeginInit();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // ShowsGridView
            // 
            this.ShowsGridView.AllowUserToAddRows = false;
            this.ShowsGridView.AllowUserToDeleteRows = false;
            this.ShowsGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ShowsGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.ShowsGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ShowsGridView.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ShowsGridView.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.ShowsGridView.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.ShowsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ShowsGridView.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.ShowsGridView.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ShowsGridView.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ShowsGridView.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.DarkRed;
            this.ShowsGridView.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.ShowsGridView.GridColor = System.Drawing.Color.LightGray;
            this.ShowsGridView.Location = new System.Drawing.Point(30, 130);
            this.ShowsGridView.MultiSelect = false;
            this.ShowsGridView.Name = "ShowsGridView";
            this.ShowsGridView.ReadOnly = true;
            this.ShowsGridView.RowHeadersVisible = false;
            this.ShowsGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ShowsGridView.Size = new System.Drawing.Size(740, 260);
            this.ShowsGridView.TabIndex = 0;
            // 
            // btnSelectShowtime
            // 
            this.btnSelectShowtime.BackColor = System.Drawing.Color.DarkRed;
            this.btnSelectShowtime.FlatAppearance.BorderSize = 0;
            this.btnSelectShowtime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectShowtime.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnSelectShowtime.ForeColor = System.Drawing.Color.White;
            this.btnSelectShowtime.Location = new System.Drawing.Point(30, 410);
            this.btnSelectShowtime.Name = "btnSelectShowtime";
            this.btnSelectShowtime.Size = new System.Drawing.Size(200, 50);
            this.btnSelectShowtime.TabIndex = 1;
            this.btnSelectShowtime.Text = "Select Showtime";
            this.btnSelectShowtime.UseVisualStyleBackColor = false;
            this.btnSelectShowtime.Click += new System.EventHandler(this.btnSelectShowtime_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(570, 410);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(200, 50);
            this.btnBack.TabIndex = 2;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lblMovieName
            // 
            this.lblMovieName.AutoSize = true;
            this.lblMovieName.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblMovieName.ForeColor = System.Drawing.Color.DarkRed;
            this.lblMovieName.Location = new System.Drawing.Point(25, 95);
            this.lblMovieName.Name = "lblMovieName";
            this.lblMovieName.Size = new System.Drawing.Size(127, 25);
            this.lblMovieName.TabIndex = 3;
            this.lblMovieName.Text = "Movie Name";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(240, 32);
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "Available Showtimes";
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(800, 60);
            this.panelHeader.TabIndex = 5;
            // 
            // ShowsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.lblMovieName);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnSelectShowtime);
            this.Controls.Add(this.ShowsGridView);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "ShowsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Showtimes";
            ((System.ComponentModel.ISupportInitialize)(this.ShowsGridView)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.DataGridView ShowsGridView;
        private System.Windows.Forms.Button btnSelectShowtime;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblMovieName;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelHeader;
    }
}