using LibraryProject.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryProject
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
            dataGridView2.AutoGenerateColumns = false;
            LoadForm();
        }
        private void btn_AddB_Click(object sender, EventArgs e)
        {

            Form2 F2 = new Form2();
            F2.MdiParent = this.MdiParent;
            F2.Closed += F2_Closed;
            F2.Show();
        }

        private void F2_Closed(object sender, EventArgs e)
        {
            LoadForm();
        }



        private void btn_SearchB_Click(object sender, EventArgs e)
        {
            _SearchForm F4 = new _SearchForm();
            F4.MdiParent = this.MdiParent;
            F4.Show();
        }

        private void F4_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadForm();
        }

        private void btn_DeleteB_Click(object sender, EventArgs e)
        {
            Form6 F6 = new Form6();
            F6.MdiParent = this.MdiParent;
            F6.FormClosed+=F6_FormClosed;
            F6.Show();
        }

        private void F6_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadForm();
        }

        private void btn_BackB_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
          
            BookTbl _Book = ((BookTbl)(dataGridView2.SelectedRows[0].DataBoundItem));
            Form2 F2 = new Form2(_Book.ID);
            F2.FormClosed += F2_FormClosed;
            F2.Show();
        }

        private void F2_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadForm();
        }



        private void LoadForm()
        {
            using (BlogDbContext mc = new BlogDbContext())
            {
                var ListBook = mc.BookTbls.Where(x => true);
                if(ListBook.Count()!=0)
                    dataGridView2.DataSource = ListBook.ToList();
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


    }
}
