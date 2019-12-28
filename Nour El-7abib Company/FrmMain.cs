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
    public partial class FrmMain : Form
    {
        FrmLogin login;
        public FrmMain(FrmLogin login)
        {
            InitializeComponent();
            this.login = login;
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FrmAddCustomer(this).Show();
        }

        private void btnAddQuantity_Click(object sender, EventArgs e)
        {
            this.Hide();
            Entities en = new Entities();
            List<Customer> customers = en.Customers.ToList();
            new FrmCustomerProfile(this, customers).Show();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            login.Show();
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            login.Show();
        }

        private void btnInvoice_Click(object sender, EventArgs e)
        {
            this.Hide();
            Entities en = new Entities();
            List<Customer> customers = en.Customers.ToList();
            new FrmAccountStatement(this,  customers).Show();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Entities en = new Entities();
            List<Customer> customers = en.Customers.ToList();
            new FrmAccountStatement(this, customers).Show();
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            this.Hide();
            Entities en = new Entities();
            List<Customer> customers = en.Customers.ToList();
            new FrmPayment(this, customers).Show();
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FrmSettings(this).Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FrmAddCustomer(this).Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (Entities ent=new Entities())
            {
                new FrmAccountStatement(this, ent.Customers.ToList()).Show();
            }
        }
    }
}
