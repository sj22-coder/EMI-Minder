using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace emi
{
    public partial class Form5 : Form
    {
        // Update this path to match your database
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\roshni\Desktop\eup_practicals\EMI MINDER\emi\emi\Database1.mdf;Integrated Security=True";

        public Form5()
        {
            InitializeComponent();
            LoadLoans();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // Load loans into ComboBox
        private void LoadLoans()
        {
            comboBox1.Items.Clear();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT DISTINCT LoanType FROM Loans";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    comboBox1.Items.Add(reader["LoanType"].ToString());
                }

                reader.Close();
            }

            // Automatically select first item if nothing is selected
            if (comboBox1.Items.Count > 0 && comboBox1.SelectedIndex == -1)
                comboBox1.SelectedIndex = 0;
        }

        // Public method to refresh ComboBox from outside forms
        public void RefreshLoanComboBox()
        {
            string selectedLoan = comboBox1.SelectedItem?.ToString();
            LoadLoans();
            if (selectedLoan != null && comboBox1.Items.Contains(selectedLoan))
                comboBox1.SelectedItem = selectedLoan;
        }

        // Load payment history for selected loan
        private void button1_Click(object sender, EventArgs e) // Load History button
        {
            LoadPaymentHistory();
        }

        private void LoadPaymentHistory()
        {
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a loan.");
                return;
            }

            string loanType = comboBox1.SelectedItem.ToString();
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT PaymentDate, Amount FROM Payments WHERE LoanType=@LoanType ORDER BY PaymentDate";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@LoanType", loanType);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            dataGridView1.DataSource = dt;
        }

        // Add new payment
        private void button2_Click(object sender, EventArgs e) // Add Payment button
        {
            if (comboBox1.SelectedIndex == -1 || string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Please select a loan and enter an amount.");
                return;
            }

            string loanType = comboBox1.SelectedItem.ToString();
            if (!double.TryParse(textBox1.Text, out double amount))
            {
                MessageBox.Show("Enter a valid numeric amount.");
                return;
            }

            DateTime paymentDate = dateTimePicker1.Value;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO Payments (LoanType, PaymentDate, Amount) VALUES (@LoanType, @PaymentDate, @Amount)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@LoanType", loanType);
                cmd.Parameters.AddWithValue("@PaymentDate", paymentDate);
                cmd.Parameters.AddWithValue("@Amount", amount);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Payment added successfully!");
            textBox1.Clear(); // clear amount textbox
            LoadPaymentHistory(); // refresh DataGridView
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
