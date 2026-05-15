namespace cinema_proj
{
    partial class LoginForm
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
            this.btnLogin = new System.Windows.Forms.Button();
            this.lbl_signUPtitle = new System.Windows.Forms.Label();
            this.lbl_PassLogin = new System.Windows.Forms.Label();
            this.lbl_EmailLogin = new System.Windows.Forms.Label();
            this.loginPassword = new System.Windows.Forms.TextBox();
            this.loginEmail = new System.Windows.Forms.TextBox();
            this.btn_back = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Location = new System.Drawing.Point(449, 422);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(183, 60);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lbl_signUPtitle
            // 
            this.lbl_signUPtitle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_signUPtitle.AutoSize = true;
            this.lbl_signUPtitle.BackColor = System.Drawing.Color.Transparent;
            this.lbl_signUPtitle.Font = new System.Drawing.Font("Microsoft YaHei", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_signUPtitle.ForeColor = System.Drawing.Color.Maroon;
            this.lbl_signUPtitle.Location = new System.Drawing.Point(574, 119);
            this.lbl_signUPtitle.Name = "lbl_signUPtitle";
            this.lbl_signUPtitle.Size = new System.Drawing.Size(130, 52);
            this.lbl_signUPtitle.TabIndex = 12;
            this.lbl_signUPtitle.Text = "Login";
            // 
            // lbl_PassLogin
            // 
            this.lbl_PassLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_PassLogin.AutoSize = true;
            this.lbl_PassLogin.BackColor = System.Drawing.Color.Transparent;
            this.lbl_PassLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_PassLogin.Location = new System.Drawing.Point(208, 331);
            this.lbl_PassLogin.Name = "lbl_PassLogin";
            this.lbl_PassLogin.Size = new System.Drawing.Size(138, 32);
            this.lbl_PassLogin.TabIndex = 16;
            this.lbl_PassLogin.Text = "Password";
            // 
            // lbl_EmailLogin
            // 
            this.lbl_EmailLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_EmailLogin.AutoSize = true;
            this.lbl_EmailLogin.BackColor = System.Drawing.Color.Transparent;
            this.lbl_EmailLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_EmailLogin.Location = new System.Drawing.Point(195, 224);
            this.lbl_EmailLogin.Name = "lbl_EmailLogin";
            this.lbl_EmailLogin.Size = new System.Drawing.Size(197, 32);
            this.lbl_EmailLogin.TabIndex = 15;
            this.lbl_EmailLogin.Text = "Email Address";
            // 
            // loginPassword
            // 
            this.loginPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loginPassword.Location = new System.Drawing.Point(410, 340);
            this.loginPassword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.loginPassword.Name = "loginPassword";
            this.loginPassword.Size = new System.Drawing.Size(263, 26);
            this.loginPassword.TabIndex = 14;
            // 
            // loginEmail
            // 
            this.loginEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loginEmail.Location = new System.Drawing.Point(410, 232);
            this.loginEmail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.loginEmail.Name = "loginEmail";
            this.loginEmail.Size = new System.Drawing.Size(263, 26);
            this.loginEmail.TabIndex = 13;
            // 
            // btn_back
            // 
            this.btn_back.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_back.Location = new System.Drawing.Point(824, 422);
            this.btn_back.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(157, 60);
            this.btn_back.TabIndex = 17;
            this.btn_back.Text = "Back";
            this.btn_back.UseVisualStyleBackColor = true;
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::cinema_proj.Properties.Resources.WhatsApp_Image_2026_04_27_at_15_40_02;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1220, 879);
            this.Controls.Add(this.btn_back);
            this.Controls.Add(this.lbl_PassLogin);
            this.Controls.Add(this.lbl_EmailLogin);
            this.Controls.Add(this.loginPassword);
            this.Controls.Add(this.loginEmail);
            this.Controls.Add(this.lbl_signUPtitle);
            this.Controls.Add(this.btnLogin);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoginForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lbl_signUPtitle;
        private System.Windows.Forms.Label lbl_PassLogin;
        private System.Windows.Forms.Label lbl_EmailLogin;
        private System.Windows.Forms.TextBox loginPassword;
        private System.Windows.Forms.TextBox loginEmail;
        private System.Windows.Forms.Button btn_back;
    }
}