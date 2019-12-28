namespace Nour_El_7abib_Company
{
    partial class FrmLogin
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPasswrod = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLogin = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(391, 45);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(124, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "اسم المستخدم :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(52, 42);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtUserName.Size = new System.Drawing.Size(307, 35);
            this.txtUserName.TabIndex = 1;
            // 
            // txtPasswrod
            // 
            this.txtPasswrod.Location = new System.Drawing.Point(52, 141);
            this.txtPasswrod.Name = "txtPasswrod";
            this.txtPasswrod.PasswordChar = '*';
            this.txtPasswrod.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPasswrod.Size = new System.Drawing.Size(307, 35);
            this.txtPasswrod.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(417, 144);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(98, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "كلمة السر :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtLogin
            // 
            this.txtLogin.BackColor = System.Drawing.Color.DarkOrange;
            this.txtLogin.Location = new System.Drawing.Point(52, 240);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(458, 44);
            this.txtLogin.TabIndex = 4;
            this.txtLogin.Text = "دخول";
            this.txtLogin.UseVisualStyleBackColor = false;
            this.txtLogin.Click += new System.EventHandler(this.txtLogin_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkRed;
            this.panel1.Controls.Add(this.txtLogin);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtPasswrod);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtUserName);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(221, 200);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(566, 328);
            this.panel1.TabIndex = 5;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PeachPuff;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.panel1);
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "شركة نور الحبيب | تسجيل الدخول";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmLogin_FormClosed);
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPasswrod;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button txtLogin;
        private System.Windows.Forms.Panel panel1;
    }
}

