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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void loanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 frm3= new Form3();
            frm3.ShowDialog();
        }

        private void eMIScheduleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form4 frm4 = new Form4();
            frm4.ShowDialog();
        }

        private void paymentHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 frm5 = new Form5();
            frm5.ShowDialog();

        }

        private void yESToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
                   
            }

        private void yesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void noToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Logout cancelled.");
        }
    }
    }

