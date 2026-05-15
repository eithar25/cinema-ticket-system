namespace cinema_proj
{
    partial class Home
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
            System.Windows.Forms.Label lbl_salute;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.btn_signUP = new System.Windows.Forms.Button();
            this.btn_login = new System.Windows.Forms.Button();
            this.lbl_signUP = new System.Windows.Forms.Label();
            this.lbl_login = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            lbl_salute = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_salute
            // 
            lbl_salute.AutoSize = true;
            lbl_salute.BackColor = System.Drawing.SystemColors.Info;
            lbl_salute.Font = new System.Drawing.Font("Microsoft YaHei UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lbl_salute.Image = global::cinema_proj.Properties.Resources._34f88a57_2743_4cf1_a0fe_6618e334a1b3;
            lbl_salute.Location = new System.Drawing.Point(372, 37);
            lbl_salute.Name = "lbl_salute";
            lbl_salute.Size = new System.Drawing.Size(370, 37);
            lbl_salute.TabIndex = 0;
            lbl_salute.Text = "Welcome to your Cinema";
            // 
            // btn_signUP
            // 
            this.btn_signUP.BackColor = System.Drawing.SystemColors.Info;
            this.btn_signUP.BackgroundImage = global::cinema_proj.Properties.Resources._34f88a57_2743_4cf1_a0fe_6618e334a1b3;
            this.btn_signUP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_signUP.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_signUP.Location = new System.Drawing.Point(255, 176);
            this.btn_signUP.Name = "btn_signUP";
            this.btn_signUP.Size = new System.Drawing.Size(140, 51);
            this.btn_signUP.TabIndex = 1;
            this.btn_signUP.Text = "SignUP";
            this.btn_signUP.UseVisualStyleBackColor = false;
            this.btn_signUP.Click += new System.EventHandler(this.btn_signUP_Click);
            // 
            // btn_login
            // 
            this.btn_login.BackColor = System.Drawing.SystemColors.Info;
            this.btn_login.BackgroundImage = global::cinema_proj.Properties.Resources._34f88a57_2743_4cf1_a0fe_6618e334a1b3;
            this.btn_login.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_login.Location = new System.Drawing.Point(255, 267);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(140, 52);
            this.btn_login.TabIndex = 2;
            this.btn_login.Text = "Login";
            this.btn_login.UseVisualStyleBackColor = false;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // lbl_signUP
            // 
            this.lbl_signUP.AutoSize = true;
            this.lbl_signUP.BackColor = System.Drawing.SystemColors.HighlightText;
            this.lbl_signUP.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_signUP.Location = new System.Drawing.Point(400, 190);
            this.lbl_signUP.Name = "lbl_signUP";
            this.lbl_signUP.Size = new System.Drawing.Size(319, 28);
            this.lbl_signUP.TabIndex = 3;
            this.lbl_signUP.Text = "Don\'t miss the premiere! Join us.";
            // 
            // lbl_login
            // 
            this.lbl_login.AutoSize = true;
            this.lbl_login.BackColor = System.Drawing.SystemColors.HighlightText;
            this.lbl_login.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_login.Location = new System.Drawing.Point(403, 282);
            this.lbl_login.Name = "lbl_login";
            this.lbl_login.Size = new System.Drawing.Size(272, 28);
            this.lbl_login.TabIndex = 4;
            this.lbl_login.Text = "Your seat is waiting for you.";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::cinema_proj.Properties.Resources.image_welcome;
            this.pictureBox1.Location = new System.Drawing.Point(728, 284);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(139, 189);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::cinema_proj.Properties.Resources.WhatsApp_Image_2026_04_27_at_14_15_17;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1084, 703);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lbl_login);
            this.Controls.Add(this.lbl_signUP);
            this.Controls.Add(this.btn_login);
            this.Controls.Add(this.btn_signUP);
            this.Controls.Add(lbl_salute);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_signUP;
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.Label lbl_signUP;
        private System.Windows.Forms.Label lbl_login;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}