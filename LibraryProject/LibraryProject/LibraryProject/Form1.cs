using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryProject.Borrow;
namespace LibraryProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void booksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form7 F7 = new Form7();
            F7.MdiParent = this;
            F7.Show();
        }

        private void membersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainForm F8 = new MainForm();
            F8.MdiParent = this;
            F8.Show();
        }

        private void borrowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login BFrm = new Login();
            BFrm.MdiParent = this;
            BFrm.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
