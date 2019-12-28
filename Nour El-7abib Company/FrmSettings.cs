using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nour_El_7abib_Company
{
    public partial class FrmSettings : Form
    {
        private FrmMain main;
        public FrmSettings(FrmMain main)
        {
            InitializeComponent();
            this.main = main;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnChangeUserName_Click(object sender, EventArgs e)
        {
            using (Entities ent = new Entities())
            {
                if (txtNewUserName.Text == "")
                {
                    MessageBox.Show("لم يتم كتابة اسم مستخدم","تغيير اسم المستخدم",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
                var firstOrDefault = ent.Accounts.FirstOrDefault(a => a.UserName.Equals(LoginInfo.UserName));
                if (firstOrDefault != null)
                {
                    firstOrDefault.UserName =
                        txtNewUserName.Text;
                    ent.SaveChanges();
                    LoginInfo.UserName = txtNewUserName.Text;
                    MessageBox.Show("تم تغيير اسم المستخدم بنجاح","تغيير اسم المستخدم",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                    
            }
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            using (Entities ent = new Entities())
            {
                if (txtOldPassword.Text == ""||txtNewPassword.Text==""||txtConfirmNewPassword.Text=="")
                {
                    MessageBox.Show("ادخل كلمة المرور القديمة و الجديدة و نأكيد الجديدة اولا", "تغيير كلمة المرور", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!txtNewPassword.Text.Equals(txtConfirmNewPassword.Text))
                {
                    MessageBox.Show("كلمة المرور الجديدة و تأكيدها غير متطابقتان", "تغيير كلمة المرور", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var firstOrDefault = ent.Accounts.FirstOrDefault(a => a.UserName.Equals(LoginInfo.UserName));
                if (firstOrDefault != null)
                {
                    if (!firstOrDefault.Password.Equals(txtOldPassword.Text))
                    {
                        MessageBox.Show("كلمة المرور القديمة غير صحيحة", "تغيير كلمة المرور", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    firstOrDefault.Password =
                        txtNewPassword.Text;
                    ent.SaveChanges();
                    MessageBox.Show("تم تغيير كلمة المرور بنجاح", "تغيير كلمة المرور", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
            main.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Close();
            new FrmAddCustomer(main).Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.Close();
            using (Entities ent = new Entities())
            {
                new FrmCustomerProfile(main, ent.Customers.ToList()).Show();
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            this.Close();
            using (Entities ent = new Entities())
            {
                new FrmAccountStatement(main, ent.Customers.ToList()).Show();
            }
        }
    }
}
