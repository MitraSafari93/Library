using LibraryProject.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryProject.Borrow
{
    public partial class BooksBorrowed : Form
    {   
        private int UserID;
        private int BookID;
        public BooksBorrowed(int UserID)
        {
            InitializeComponent();
            dataGridView2.AutoGenerateColumns = false;
            dataGridView3.AutoGenerateColumns = false;
            this.UserID = UserID;
            txt_userID.Text = UserID.ToString();
            txt_name.Text= getUserName();
            LoadDataGridView();
        }
        private string getUserName()
        {
           using (BlogDbContext mc = new BlogDbContext())
           {
               var name= mc.Database.SqlQuery<MembersTbl>("select * from MembersTbls where ID={0}",UserID).FirstOrDefault();
               return name.FullName;
           }
        }

        private void LoadDataGridView() 
        {
            using (BlogDbContext mc = new BlogDbContext())
            {

                var _borrowedList = from bookTbl in mc.BookTbls
                                    join BrwTbl in mc.BorrowerTbls
                                    on bookTbl.ID equals BrwTbl.IDBook
                                    where BrwTbl.IDMember == UserID
                                    where bookTbl.Available == false
                                    select new Info()
                                    {   ID=BrwTbl.ID,
                                        BookID = bookTbl.ID,
                                        Title = bookTbl.Title,
                                        Author = bookTbl.Author,
                                        Publisher = bookTbl.Publisher,
                                        Translator = bookTbl.translator
                                    };
                if (_borrowedList != null)
                {
                    dataGridView2.DataSource = _borrowedList.ToList();
                }
            }
        }

        

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

                   
                   
        }

        private void btn_borrow_Click(object sender, EventArgs e)
        {

        }

        //private void btn_search_Click(object sender, EventArgs e)
        //{
        //    lbl_status.Text = "";
        //    int ID = Convert.ToInt32(txt_IDbook.Text);
        //    string str = "select * from BookTbl where BookID=" + ID;
        //    using (BlogDbContext mc = new BlogDbContext())
        //    {
        //        var _bookList = mc.Database.SqlQuery<BookTbl>("select * from BookTbl where BookID={0}", ID);
        //        var _bookList = mc.Database.SqlQuery<BookTbl>(str);
        //        if (_bookList != null)
        //        {
        //            dataGridView1.DataSource = _bookList.ToList();
        //            BookID = ID;
        //        }
        //        else
        //        {
        //            lbl_status.Text = "شناسه کتاب معتبر نیست";
        //        }

        //    }
        //}

        private void btn_borrow_Click_1(object sender, EventArgs e)
        {
            using (BlogDbContext mc = new BlogDbContext())
            {
                var _bookList = mc.BookTbls.Where(x => x.ID == this.BookID).FirstOrDefault();
                if (_bookList != null)
                {
                    if (_bookList.Available == false)
                    {
                        _lbl_s.Text = "کتاب در قفسه موجود نیست";
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
                                IDBook = BookID,
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count == 0)
                return;
            Info _inftbl = (Info)dataGridView2.SelectedRows[0].DataBoundItem;
            ReturnBook(_inftbl.BookID, _inftbl.ID);
            this.Close();
        }
                 
        private void ReturnBook(int BookID,int ID)
        {
            using (BlogDbContext mc = new BlogDbContext())
            {
                BookTbl _BTbl= mc.BookTbls.Where(x => x.ID==BookID).FirstOrDefault();
                _BTbl.Available=true;
                BorrowerTbl _BrwTbl = mc.BorrowerTbls.Where(x=> x.ID==ID).FirstOrDefault();
                _BrwTbl.ReturnDate = DateTime.Now;
                mc.SaveChanges();
            }
        }



        private void _btnSearch_Click(object sender, EventArgs e)
        {


            using (BlogDbContext mc = new BlogDbContext())
            {
                _lbl_s.Text = "";
                try
                {
                    string str = "select * from BookTbls where ";
                    bool tmp = false;
                    if (!string.IsNullOrEmpty(_txt_ID.Text))
                    {
                        int ID = Convert.ToInt32(_txt_ID.Text);
                        str += "ID like N'%" + ID + "%'";

                        tmp = true;
                    }
                    if (!string.IsNullOrEmpty(_txt_title.Text))
                    {
                        if (tmp)
                            str += " and ";
                        str += "title like N'%" + _txt_title.Text + "%'";
                        tmp = true;
                    }

                    if (!string.IsNullOrEmpty(_txt_author.Text))
                    {
                        if (tmp)
                            str += " and ";
                        str += " author like N'%" + _txt_author.Text + "%'";
                        tmp = true;
                    }
                    if (!string.IsNullOrEmpty(_txt_publisher.Text))
                    {
                        if (tmp)
                            str += " and ";
                        str += " publisher like N'%" + _txt_publisher.Text + "%'";
                        tmp = true;
                    }
                    if (!tmp)
                    {
                        str = "select * from BookTbls";
                    }
                    var _search = mc.Database.SqlQuery<BookTbl>(str).ToList();
                    if (_search.FirstOrDefault() != null)
                    {
                        dataGridView3.DataSource = _search.ToList();
                    }
                    else
                    {
                        _lbl_s.Text = "نتیجه ای یافت نشد";
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("ID must be a number.", "ATTENTION");
                }
                catch (OverflowException ex)
                {
                    MessageBox.Show(ex.Message, "OVERFLOW!");
                }
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void _btn_Borrow_Click(object sender, EventArgs e)
        {
            if (dataGridView3.SelectedRows.Count == 0)
            {
                return;
            }
            BookTbl _infBook = (BookTbl)dataGridView3.SelectedRows[0].DataBoundItem;
            BookID = _infBook.ID;
            using (BlogDbContext mc = new BlogDbContext())
            {
                var _bookList = mc.BookTbls.Where(x => x.ID == this.BookID).FirstOrDefault();
                if (_bookList != null)
                {
                    if (_bookList.Available == false)
                    {
                        _lbl_s.Text = "کتاب در قفسه موجود نیست";
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
                                IDBook = BookID,
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


    }
    public class Info
    {
        public int ID { get; set; }
        public int BookID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string Translator { get; set; }
    }
}
