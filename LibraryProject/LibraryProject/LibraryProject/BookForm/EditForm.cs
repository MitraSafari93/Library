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
    public partial class EditForm : Form
    {
        public EditForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
       //     string str = mColTitle.;
       //     MessageBox.Show(str);
        //    using(BlogDbContext mc = new BlogDbContext()){
              //  BookTbl book = mc.BookTbls.Where(x => x.ID = Convert.ToInt32(mColTitle.ToString())).FirstOrDefault();
                }
            //    Customer _Customer = mNw.Customers.Where(C => C.CustomerID == "ooooo").FirstOrDefault();
            //    if (_Customer != null)
            //    {
            //        //_Customer.CompanyName = "New Compnay Name 22";
            //        mNw.Customers.Remove(_Customer);
            //        mNw.SaveChanges();
            //    }
      //  }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            //BookTbl _Book = ((BookTbl)(dataGridView1.SelectedRows[0].DataBoundItem));


            using (BlogDbContext mc = new BlogDbContext())
            {
                var EditList = mc.Database.SqlQuery<BookTbl>("select * from BookTbl where ID="+ textBox1.Text);
                if(!string.IsNullOrEmpty(textBox1.Text))
                      dataGridView1.DataSource=EditList.ToList();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
