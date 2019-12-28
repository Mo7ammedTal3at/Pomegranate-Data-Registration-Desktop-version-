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
    public partial class FrmAccountStatement : Form
    {
        FrmMain frmMain;
        List<Customer> customers;
        private Customer customer;

        public FrmAccountStatement(FrmMain frmMain,  List<Customer> customers)
        {
            InitializeComponent();
            this.frmMain = frmMain;
            this.customers = customers;
            combName.Items.AddRange(customers.Select(o => o.Name).ToArray());
            combName.SelectedIndex = -1;
            dataGridView1.ColumnCount = 7;

            dataGridView1.Columns[0].Name = "الفئة";
            dataGridView1.Columns[1].Name = "العدد";
            dataGridView1.Columns[2].Name = "الوزن";
            dataGridView1.Columns[3].Name = "الوزن الكلى";
            dataGridView1.Columns[4].Name = "سعر الكيلو";
            dataGridView1.Columns[5].Name = "السعر الكلى";
            dataGridView1.Columns[6].Name = "التاريخ";
        }

        private void FrmAccountStatement_Load(object sender, EventArgs e)
        {

        }

        private void combName_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (Entities en = new Entities())
            {
                if (combName.SelectedIndex > -1)
                {
                    this.customer = customers[combName.SelectedIndex];
                    //List<Quantity> qq = en.Quantities.Where(i => i.Id == customer.Id).ToList();
                    //List<string> t = qq.Select(i => i.Type).ToList();
                    //List<string> types = t.Distinct().ToList();
                    List<string> types = en.Quantities.Where(i => i.CustomerId == customer.Id).Select(ii => ii.Type).Distinct().ToList();
                    combType.Items.Clear();
                    combType.Items.AddRange(types.ToArray());
                    combType.Enabled = true;
                }
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            if (combName.SelectedIndex == -1 || combType.SelectedIndex == -1)
            {
                MessageBox.Show("من فضلك اختر اسم العميل و الفئة قبل العرض", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            Entities en = new Entities();
            List<Quantity> qqq = en.Quantities.Where(qq => qq.CustomerId == customer.Id && qq.Type == combType.Text).ToList();
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
            }
            if (qqq.Count > 0)
            {
                foreach (Quantity temp in qqq)
                {
                    List<string> dataRaw = new List<string>();
                    dataRaw.Add(temp.Type);
                    dataRaw.Add(temp.Quantity1.ToString());
                    dataRaw.Add(temp.Weight.ToString());
                    dataRaw.Add(temp.TotalWeight.ToString());
                    dataRaw.Add(temp.Price.ToString());
                    dataRaw.Add(temp.TotalPrice.ToString());
                    dataRaw.Add(temp.Date.Value.ToString("MM/dd/yyyy"));

                    dataGridView1.Rows.Add(dataRaw.ToArray());
                    dataGridView1.Rows.Add(dataRaw.ToArray());
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if(dataGridView1.RowCount==0)
            {
                MessageBox.Show("عفوا لايوجد شئ لطباعته", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "شركة نور الحبيب";
            printer.SubTitle = "كشف حساب للسيد / " + customer.Name+"\nفئة /"+combType.Text;
            printer.SubTitleFormatFlags = StringFormatFlags.NoClip | StringFormatFlags.LineLimit;
            
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "شركة نور الحبيب";
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(dataGridView1);
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
            Entities en = new Entities();
            List<Customer> customers = en.Customers.ToList();
            new FrmCustomerProfile(frmMain, customers).Show();
        }

        private void FrmAccountStatement_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmMain.Show();
        }
    }
}
