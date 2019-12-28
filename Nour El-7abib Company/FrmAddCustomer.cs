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
    public partial class FrmAddCustomer : Form
    {
        FrmMain main;
        public FrmAddCustomer(FrmMain main)
        {
            InitializeComponent();
            this.main = main;
        }

        private void FrmAddCustomer_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Customer c = new Customer();
            if(String.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("ادخل اسم العميل اولا");
                return;
            }
            c.Name = txtName.Text;
            Entities en = new Entities();
            en.Customers.Add(c);
            en.SaveChanges();
            c = en.Customers.Where(cc => cc.Name == c.Name).First();
            FrmCustomerProfile cp = new FrmCustomerProfile(main,c);
            this.Hide();
            cp.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
            main.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.Close();
            main.Hide();
            Entities en = new Entities();
            List<Customer> customers = en.Customers.ToList();
            new FrmCustomerProfile(main, customers).Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            
        }

        private void FrmAddCustomer_FormClosed(object sender, FormClosedEventArgs e)
        {
            main.Show();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            this.Close();
            Entities en = new Entities();
            List<Customer> customers = en.Customers.ToList();
            new FrmAccountStatement(main, customers).Show();
        }
    }
}
