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

namespace LibraryProject.Borrow
{
    public partial class BooksDetail : Form
    {
        private int ID;
        private int UserID;
        public BooksDetail(int UserID)
        {
            InitializeComponent();
            dataGridView2.AutoGenerateColumns = false;
            this.UserID = UserID;
            txt_userID.Text = UserID.ToString();
            txt_name.Text= getUserName();
        }
        private string getUserName()
        {
           using (BlogDbContext mc = new BlogDbContext())
           {
               var name= mc.Database.SqlQuery<MembersTbl>("select * from MembersTbl where Idmember={0}",UserID).FirstOrDefault();
               return name.FullName;
           }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_search_Click(object sender, EventArgs e)
        {
           
        }


        private void btn_borrow_Click(object sender, EventArgs e)
        {
            using (BlogDbContext mc = new BlogDbContext())
            {
                var _bookList = mc.BookTbls.Where(x => x.ID == this.ID).FirstOrDefault();
                if (_bookList != null)
                {
                    if (_bookList.Available == false)
                    {
                        lbl_status.Text = "کتاب در قفسه موجود نیست";
                        return;
                    }
                    else
                    {

                        _bookList.Available = false;
                        mc.SaveChanges();
                        using (BlogDbContext le2 = new BlogDbContext())
                        {
                            BorrowerTbl _borrowList = new BorrowerTbl()
                            {
                                IDBook = ID,
                                IDMember = UserID,
                                ReciveDate = DateTime.Now,
                                DueDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).AddDays(20)
                            };
                            mc.BorrowerTbls.Add(_borrowList);

                            mc.SaveChanges();
                        }
                        this.Close();
                    }
                }
            }

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lbl_status_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txt_IDbook_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
