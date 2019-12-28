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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void txtLogin_Click(object sender, EventArgs e)
        {
           if(!ValidateEntry())
            {
                MessageBox.Show("من فضلك ادخل اسم المستخدم و كلمة السر قبل الدخول", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                Login();
            }
        }
        private bool ValidateEntry()
        {
            return (!String.IsNullOrEmpty(txtUserName.Text)) 
                && (!String.IsNullOrEmpty(txtPasswrod.Text));
        }
        private void Login()
        {
            Account account = new Account();
            account.UserName = txtUserName.Text;
            account.Password = txtPasswrod.Text;
            using (Entities entities = new Entities())
            {
                Account ac;
                ac=entities.Accounts.FirstOrDefault(a => a.UserName.Equals(account.UserName) && a.Password.Equals(account.Password));
                if(ac==null)
                {
                    MessageBox.Show("اسم المستخدم غير صحيح او كلمة السر غير صحيحة سجل الدخول مرة اخرى", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    LoginInfo.UserName = ac.UserName;
                    new FrmMain(this).Show();
                    txtUserName.Text = "";
                    txtPasswrod.Text = "";
                    this.Hide();
                }
            }

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
