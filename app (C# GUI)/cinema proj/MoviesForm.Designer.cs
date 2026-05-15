namespace cinema_proj
{
    partial class MoviesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MoviesGridView = new System.Windows.Forms.DataGridView();
            this.lbl_welcome = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chosen_movie = new System.Windows.Forms.TextBox();
            this.btn_show = new System.Windows.Forms.Button();
            this.btn_back = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.MoviesGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // MoviesGridView
            // 
            this.MoviesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MoviesGridView.Location = new System.Drawing.Point(34, 75);
            this.MoviesGridView.Name = "MoviesGridView";
            this.MoviesGridView.RowHeadersWidth = 51;
            this.MoviesGridView.RowTemplate.Height = 24;
            this.MoviesGridView.Size = new System.Drawing.Size(594, 606);
            this.MoviesGridView.TabIndex = 0;
            // 
            // lbl_welcome
            // 
            this.lbl_welcome.AutoSize = true;
            this.lbl_welcome.BackColor = System.Drawing.Color.Transparent;
            this.lbl_welcome.Font = new System.Drawing.Font("Microsoft YaHei", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_welcome.ForeColor = System.Drawing.Color.Maroon;
            this.lbl_welcome.Location = new System.Drawing.Point(482, 21);
            this.lbl_welcome.Name = "lbl_welcome";
            this.lbl_welcome.Size = new System.Drawing.Size(209, 31);
            this.lbl_welcome.TabIndex = 1;
            this.lbl_welcome.Text = "Available Movies";
            this.lbl_welcome.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(657, 211);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(415, 27);
            this.label1.TabIndex = 2;
            this.label1.Text = "Enter Movie ID to show available shows";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // chosen_movie
            // 
            this.chosen_movie.Location = new System.Drawing.Point(725, 252);
            this.chosen_movie.Name = "chosen_movie";
            this.chosen_movie.Size = new System.Drawing.Size(282, 22);
            this.chosen_movie.TabIndex = 3;
            // 
            // btn_show
            // 
            this.btn_show.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_show.Location = new System.Drawing.Point(807, 301);
            this.btn_show.Name = "btn_show";
            this.btn_show.Size = new System.Drawing.Size(122, 39);
            this.btn_show.TabIndex = 4;
            this.btn_show.Text = "View";
            this.btn_show.UseVisualStyleBackColor = true;
            this.btn_show.Click += new System.EventHandler(this.btn_show_Click);
            // 
            // btn_back
            // 
            this.btn_back.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_back.Location = new System.Drawing.Point(946, 632);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(117, 34);
            this.btn_back.TabIndex = 11;
            this.btn_back.Text = "Back";
            this.btn_back.UseVisualStyleBackColor = true;
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
            // 
            // MoviesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::cinema_proj.Properties.Resources.WhatsApp_Image_2026_04_27_at_18_41_29;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1084, 703);
            this.Controls.Add(this.btn_back);
            this.Controls.Add(this.btn_show);
            this.Controls.Add(this.chosen_movie);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_welcome);
            this.Controls.Add(this.MoviesGridView);
            this.MaximizeBox = false;
            this.Name = "MoviesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MoviesForm";
            ((System.ComponentModel.ISupportInitialize)(this.MoviesGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView MoviesGridView;
        private System.Windows.Forms.Label lbl_welcome;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox chosen_movie;
        private System.Windows.Forms.Button btn_show;
        private System.Windows.Forms.Button btn_back;
    }
}