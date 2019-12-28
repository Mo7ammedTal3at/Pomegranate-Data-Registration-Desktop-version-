using DGVPrinterHelper;
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
    public partial class FrmPayment : Form
    {
        FrmMain frmMain;
        List<Customer> customers;
        private Customer customer;
        double totalMoney = 0;
        public FrmPayment(FrmMain frmMain, List<Customer> customers)
        {
            InitializeComponent();
            this.frmMain = frmMain;
            this.customers = customers;
            combName.Items.AddRange(customers.Select(o => o.Name).ToArray());
            combName.SelectedIndex = -1;
            dataGridView1.ColumnCount = 2;
            dataGridView1.Columns[0].Name = "المبلغ";
            dataGridView1.Columns[1].Name = "التاريخ";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combName.SelectedIndex > -1)
            {
                this.customer = customers[combName.SelectedIndex];
                Entities en = new Entities();
                totalMoney = 0;
                List<double> money = en.Quantities.Where(q => q.CustomerId == customer.Id).Select(q=>q.TotalPrice).ToList();
                if (money.Count > 0)
                {
                    totalMoney = money.Sum();
                    List<double> payment = en.Payments.Where(p => p.CustomerId == customer.Id).Select(pp=>pp.Money).ToList();
                    if(payment.Count>0)
                    {
                        totalMoney -= payment.Sum(); 
                    }
                }
                lblCharge.Text = "رصيد العميل الكلى : " + totalMoney + "جنيه";
                List<Payment> payments = en.Payments.Where(p => p.CustomerId == customer.Id).ToList();
                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.Rows.Clear();
                    dataGridView1.Refresh();
                }
                if (payments.Count > 0)
                {
                    foreach (Payment temp in payments)
                    {
                        List<string> dataRaw = new List<string>();
                        dataRaw.Add(temp.Money.ToString());
                        dataRaw.Add(temp.Date.ToString("MM/dd/yyyy"));
                        dataGridView1.Rows.Add(dataRaw.ToArray());
                    }

                }
            }
            }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            if (!ValidateEntry())
            {
                MessageBox.Show("من فضلك قم باختيار اسم العميل ثم ادخل المبلغ المراد دفعه قبل الدفع", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (!ValidateEntryFormat())
            {
                MessageBox.Show("المبلغ المراد دفعه لابد ان يكون ارقام و ليس حروف من فضللك ادخل المبلغ بطريقه صحيحه", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            Entities en = new Entities();
            Payment p = new Payment();
            p.CustomerId = customer.Id;
            p.Money = float.Parse(txtMoney.Text);
            p.Date = dtpDate.Value;        
            en.Payments.Add(p);
            en.SaveChanges();
            MessageBox.Show("تم دفع المبلغ", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information);
            totalMoney -= p.Money;
            lblCharge.Text = "رصيد العميل الكلى : " + totalMoney + "جنيه";
            List<string> dataRaw = new List<string>();
            dataRaw.Add(p.Money.ToString());
            dataRaw.Add(p.Date.ToString("MM/dd/yyyy"));
            dataGridView1.Rows.Add(dataRaw.ToArray());
        }

        private bool ValidateEntryFormat()
        {
            float x;
            return float.TryParse(txtMoney.Text, out x);
        }

        private bool ValidateEntry()
        {
            return (!String.IsNullOrEmpty(txtMoney.Text));
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
            frmMain.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Close();
            new FrmAddCustomer(frmMain).Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.Close();
            frmMain.Hide();
            Entities en = new Entities();
            List<Customer> customers = en.Customers.ToList();
            new FrmCustomerProfile(frmMain, customers).Show();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            this.Close();
            Entities en = new Entities();
            List<Customer> customers = en.Customers.ToList();
            new FrmAccountStatement(frmMain,customers).Show();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount == 0)
            {
                MessageBox.Show("عفوا لايوجد شئ لطباعته", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "شركة نور الحبيب";
            printer.SubTitle = "مدفوعات للسيد /" + customer.Name;
            printer.SubTitleFormatFlags = StringFormatFlags.NoClip | StringFormatFlags.LineLimit;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "شركة نور الحبيب";
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(dataGridView1);
        }
    }
}
