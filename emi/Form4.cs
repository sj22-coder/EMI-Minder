using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace emi
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            dataGridView1.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double principal = double.Parse(textBox1.Text);
            double annualRate = double.Parse(textBox2.Text);
            int tenureYears=int.Parse(textBox3.Text);
            DateTime startdate = dateTimePicker1.Value;
            int tenureMonths = tenureYears * 12;
            double monthlyRate=annualRate/12/100;
            double emi = (principal * monthlyRate * Math.Pow(1 + monthlyRate,tenureMonths))/(Math.Pow(1+monthlyRate,tenureMonths)-1);
            DataTable dt=new DataTable();
            dt.Columns.Add("Month");
            dt.Columns.Add("Installment Date");
            dt.Columns.Add("EMI");
            dt.Columns.Add("Interest");
            dt.Columns.Add("Principal");
            dt.Columns.Add("Balance");
            double balance=principal;
            for (int i=1;i<=tenureMonths;i++)
            {
                double interest = balance * monthlyRate;
                double principalPart = emi - interest;
                balance -= principalPart;
                dt.Rows.Add
                    (
                    i,
                    startdate.AddMonths(i).ToShortDateString(),
                    emi.ToString("F2"),
                    interest.ToString("F2"),
                    principalPart.ToString("F2"),
                    balance > 0 ? balance.ToString("F2") : "0:00"
                    );

            }
            dataGridView1.DataSource = dt;

        }

        
    }
}
