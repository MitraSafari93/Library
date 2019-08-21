using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryProject.Borrow;
using LibraryProject.Model;

namespace LibraryProject
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            LoadForm();
        }

        private void btn_AddB_Click(object sender, EventArgs e)
        {
            Form3 F1 = new Form3();
            F1.MdiParent = this.MdiParent;
            F1.FormClosed += F1_FormClosed;
            F1.Show();
 
        }

        private void F1_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadForm();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void btn_SearchB_Click(object sender, EventArgs e)
        {
                Form5 F5 = new Form5();
                F5.MdiParent = this.MdiParent;
                F5.FormClosed += F5_FormClosed;
                F5.Show();
        }

        private void F5_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadForm();
        }

        private void btn_DeleteB_Click(object sender, EventArgs e)
        {
            DeleteForm DF = new DeleteForm();
            DF.MdiParent = this.MdiParent;
            DF.FormClosed += DF_FormClosed;
            DF.Show();
        }

        private void DF_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadForm();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_BackB_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                MembersTbl _member = (MembersTbl)dataGridView1.SelectedRows[0].DataBoundItem;
                Form3 frm3 = new Form3(_member.ID);
                frm3.FormClosed += F3_FormClosed;
                frm3.Show();
            }
            catch (ArgumentOutOfRangeException) { }
        }

        private void F3_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadForm();
        }

        private void LoadForm()
        {
            try
            {
                using (BlogDbContext mc = new BlogDbContext())
                {
                    var listm = mc.MembersTbls.Where(m => true);
                    dataGridView1.DataSource = listm.ToList();
                }
            }
            catch (ProviderIncompatibleException)
            {
                throw;
            }
        }

        private void btn_borrowedB_Click(object sender, EventArgs e)
        {
            MembersTbl _member = (MembersTbl)dataGridView1.SelectedRows[0].DataBoundItem;
            BooksBorrowed Bfrm = new BooksBorrowed(_member.ID);
            Bfrm.MdiParent = this.MdiParent;
            Bfrm.Show();
        }
    }
}
