using System;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace emi
{
    public partial class Form1 : Form
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\roshni\Desktop\eup_practicals\EMI MINDER\emi\emi\Database1.mdf;Integrated Security=True";

        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            string query = "SELECT COUNT(*)FROM Users WHERE Username=@username AND Password=@password";
            SqlCommand cmd=new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue ("@password", password);
            int count = (int)cmd.ExecuteScalar();
            conn.Close();
            if (count > 0)
            {
                MessageBox.Show("Login Successful!");
                Form2 frm2=new Form2();
                frm2.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password!");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}