using System;
using System.Data.SqlClient;
using System.Runtime.InteropServices.ComTypes;
using System.Windows.Forms;
namespace emi
{
    public partial class Form3:Form
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\roshni\Desktop\eup_practicals\EMI MINDER\emi\emi\Database1.mdf;Integrated Security=True";
        public Form3()
        {
            InitializeComponent();
            comboBox1.Items.Add("Home Loan");
            comboBox1.Items.Add("Personal Loan");
            comboBox1.Items.Add("Car Loan");
        }
        private void button1_Click(object sender, EventArgs e)
        { 
            double principal=double.Parse(textBox1.Text);
            double annualRate=double.Parse(textBox2.Text);
            int tenureMonths=int.Parse(textBox3.Text)*12;
            double monthlyRate = (annualRate / 100) / 12;
            double emi = (principal * monthlyRate * Math.Pow(1 + monthlyRate, tenureMonths)) / (Math.Pow(1 + monthlyRate, tenureMonths) - 1);
            label6.Text= emi.ToString("0.00");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string LoanType=comboBox1.SelectedItem.ToString();
            double principal = double.Parse(textBox1.Text);
            double annualRate=double.Parse(textBox2.Text);
            int tenureMonths=int.Parse (textBox3.Text);
            DateTime startdate = dateTimePicker1.Value;
            double emi = double.Parse(label6.Text);
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            string query = "INSERT INTO LOANS (LoanType,Principal,InterestRate,TenureMonths,StartDate,EMI)" +
            "VALUES(@LoanType,@Principal,@InterestRate,@TenureMonths,@StartDate,@EMI)";
            SqlCommand cmd=new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@LoanType",LoanType);
            cmd.Parameters.AddWithValue("@Principal", principal);
            cmd.Parameters.AddWithValue("@InterestRate", annualRate);
            cmd.Parameters.AddWithValue("@TenureMonths", tenureMonths);
            cmd.Parameters.AddWithValue("@StartDate",startdate);
            cmd.Parameters.AddWithValue("@EMI",emi);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Loan Details saved successfully!");
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}