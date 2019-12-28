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
    
    public partial class FrmCustomerProfile : Form
    {
        private Customer customer;
        private FrmAddCustomer frmAC;
        private FrmMain frmMain;
        List<Customer> customers;
        Entities en = new Entities();
        FrmLogin login;
        public FrmCustomerProfile(FrmMain main,Customer c)
        {
            InitializeComponent();
            this.frmMain = main;
            this.customer = c;
            combName.Items.Add(customer.Name);
            combName.SelectedIndex = 0;
            dataGridView1.ColumnCount = 9;
            
            List<Quantity> qqq = en.Quantities.Where(qq => qq.CustomerId == customer.Id).ToList();
            if (qqq.Count > 0)
            {
                dataGridView1.DataSource = qqq.Select(o => new
                {
                    Column1 = o.Type,
                    Column2 = o.Quantity1,
                    Column3 = o.Weight,
                    Column4 = o.TotalWeight,
                    Column5 = o.Price,
                    Column6 = o.TotalPrice,
                    Column7 = o.Charge,
                    Column8 = o.Date,
                    Column9 = o.Notes
                });
            }
            dataGridView1.Columns[0].Name = "الفئة";
            dataGridView1.Columns[1].Name = "العدد";
            dataGridView1.Columns[2].Name = "الوزن";
            dataGridView1.Columns[3].Name = "الوزن الكلى";
            dataGridView1.Columns[4].Name = "سعر الكيلو";
            dataGridView1.Columns[5].Name = "السعر الكلى";
            dataGridView1.Columns[6].Name = "الرصيد الكلى";
            dataGridView1.Columns[7].Name = "التاريخ";
            dataGridView1.Columns[8].Name = "الملاحظات";
        }
        public FrmCustomerProfile(FrmMain main, List<Customer> customers)
        {
            InitializeComponent();
            this.frmMain = main;
            this.login = login;

            this.customers = customers;
            combName.Items.AddRange(customers.Select(o => o.Name).ToArray());
            combName.SelectedIndex = -1;
            dataGridView1.ColumnCount = 9;
            
            dataGridView1.Columns[0].Name = "الفئة";
            dataGridView1.Columns[1].Name = "العدد";
            dataGridView1.Columns[2].Name = "الوزن";
            dataGridView1.Columns[3].Name = "الوزن الكلى";
            dataGridView1.Columns[4].Name = "سعر الكيلو";
            dataGridView1.Columns[5].Name = "السعر الكلى";
            dataGridView1.Columns[6].Name = "الرصيد الكلى";
            dataGridView1.Columns[7].Name = "التاريخ";
            dataGridView1.Columns[8].Name = "الملاحظات";
        }
        private void FrmCustomerProfile_Load(object sender, EventArgs e)
        {
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(!ValidateEntry())
            {
                MessageBox.Show("من فضلك ادخل النوع و العدد و الوزن والسعر قبل الإضافة", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if(!ValidateEntryFormat())
            {
                MessageBox.Show("من فضلك ادخل فى العدد والسعر و الوزن ارقام و ليس حروف", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            Quantity q = new Quantity();
            q.CustomerId = customer.Id;
            q.Quantity1 = int.Parse(txtQuantity.Text);
            q.Weight = float.Parse(txtWeight.Text);
            q.Price = float.Parse(txtPrice.Text);
            q.TotalWeight = q.Quantity1 * q.Weight;
            q.TotalPrice = q.TotalWeight * q.Price;
            q.Date = dtpDate.Value;
            List<Quantity> qqq = en.Quantities.Where(qq => qq.CustomerId == customer.Id).ToList();
            if (qqq.Count == 0)
            {
                q.Charge = q.TotalPrice;
            }
            else
            {
                q.Charge = en.Quantities.Where(qq => qq.CustomerId == customer.Id).Sum(qq => qq.TotalPrice) + q.TotalPrice;
            }
            q.Notes = rtbNotes.Text;
            q.Type = txtType.Text;
            en.Quantities.Add(q);
            en.SaveChanges();
            MessageBox.Show("تم اضافة الكمية","تم", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //Quantity quantity = en.Quantities.Where(qq => qq.CustomerId == customer.Id).Last();
            //dataGridView1.Rows.Clear();
            //DataRaw dr = new DataRaw();
            List<string> dataRaw = new List<string>();
            dataRaw.Add(q.Type);
            dataRaw.Add(q.Quantity1.ToString());
            dataRaw.Add(q.Weight.ToString());
            dataRaw.Add(q.TotalWeight.ToString());
            dataRaw.Add(q.Price.ToString());
            dataRaw.Add(q.TotalPrice.ToString());
            dataRaw.Add(q.Charge.ToString());
            dataRaw.Add(q.Date.ToString());
            dataRaw.Add(q.Notes);
            
            dataGridView1.Rows.Add(dataRaw.ToArray());
            
        }
        private bool ValidateEntry()
        {
            return (!String.IsNullOrEmpty(txtQuantity.Text))
                && (!String.IsNullOrEmpty(txtWeight.Text))
                &&(!String.IsNullOrEmpty(txtPrice.Text))
                && (!String.IsNullOrEmpty(txtType.Text));
        }
        private bool ValidateEntryFormat()
        {
            double r;
            int rr;
            return (Double.TryParse(txtPrice.Text, out r)
                &&Int32.TryParse(txtQuantity.Text, out rr)
                && Double.TryParse(txtWeight.Text, out r));
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void combName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(combName.SelectedIndex>-1)
            {
                if (customers != null)
                    this.customer = customers[combName.SelectedIndex];
                
                List<Quantity> qqq = en.Quantities.Where(qq => qq.CustomerId == customer.Id).ToList();
                if(dataGridView1.Rows.Count>0)
                {
                    dataGridView1.Rows.Clear();
                    dataGridView1.Refresh();
                }
                if (qqq.Count > 0)
                {
                    //DataTable dt = new DataTable();
                    //dt.Columns.Add("الفئة");
                    //dt.Columns.Add("العدد");
                    //dt.Columns.Add("الوزن");
                    //dt.Columns.Add("الوزن الكلى");
                    //dt.Columns.Add("سعر الكيلو");
                    //dt.Columns.Add("السعر الكلى");
                    //dt.Columns.Add("الرصيد الكلى");
                    //dt.Columns.Add("التاريخ");
                    //dt.Columns.Add("الملاحظات");

                    
                    foreach (Quantity temp in qqq)
                    {
                        List<string> dataRaw = new List<string>();
                        dataRaw.Add(temp.Type);
                        dataRaw.Add(temp.Quantity1.ToString());
                        dataRaw.Add(temp.Weight.ToString());
                        dataRaw.Add(temp.TotalWeight.ToString());
                        dataRaw.Add(temp.Price.ToString());
                        dataRaw.Add(temp.TotalPrice.ToString());
                        dataRaw.Add(temp.Charge.ToString());
                        dataRaw.Add(temp.Date.ToString());
                        dataRaw.Add(temp.Notes);

                        dataGridView1.Rows.Add(dataRaw.ToArray());
                    }
                    //dataGridView1.DataSource = dt;
                   
                }
            }
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

        private void FrmCustomerProfile_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
            frmMain.Show();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            this.Close();
            Entities en = new Entities();
            List<Customer> customers = en.Customers.ToList();
            new FrmAccountStatement(frmMain, customers).Show();
        }
    }
}
