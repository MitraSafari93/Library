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
   
    public partial class Form2 : Form
    {
        private Condition condition;
        private int pBookId;
        public Form2()
        {
            InitializeComponent();
            condition = Condition.Add;
        }
        public Form2(int pBookId)
        {
            InitializeComponent();
            this.pBookId = pBookId;
            condition = Condition.Edit;
            setData();
        }

        private void setData() {
            using (BlogDbContext mc = new BlogDbContext())
            {
                BookTbl bookTbl = mc.BookTbls.Where(x => x.ID == pBookId).FirstOrDefault();
                if (bookTbl != null)
                {
                    mTxtTitle.Text = bookTbl.Title;
                    textBox2.Text = bookTbl.Author;
                    textBox3.Text = bookTbl.Publisher;
                    textBox4.Text = bookTbl.translator;
                    mc.SaveChanges();
                }
            }
        }


        private bool ValidateForm()
        {
            bool _IsValid = true;

            if (string.IsNullOrEmpty(mTxtTitle.Text) == true)
            {
                _IsValid = false;
                errorProvider1.SetError(mTxtTitle, "عنوان را وارد کنید");
            }

            if (string.IsNullOrEmpty(textBox2.Text) == true) 
            {
                _IsValid = false;
                errorProvider1.SetError(textBox2, "نام نویسنده را وارد کنید");
            }
            if (string.IsNullOrEmpty(textBox3.Text) == true) 
            {
                _IsValid = false;
                errorProvider1.SetError(textBox3, "نام ناشر را وارد کنید");
            }

            else
            {
                errorProvider1.SetError(mTxtTitle, "");
            }

            return _IsValid;

            
        }

        private void btn_save_Click(object sender, EventArgs e)
        {   
           
            if (ValidateForm() == false)
                return; {
            using (BlogDbContext mc = new BlogDbContext())
            {
                if (condition == Condition.Add)
                {
                    BookTbl bookTbl = new BookTbl()
                    {

                        Title = mTxtTitle.Text,
                        Author = textBox2.Text,
                        Publisher = textBox3.Text,
                        translator = textBox4.Text,
                        Available = true
                    };
                    mc.BookTbls.Add(bookTbl);
                    mc.SaveChanges();
                }
                else
                {
                    BookTbl bookTbl = mc.BookTbls.Where(x => x.ID == pBookId).FirstOrDefault();
                    if (bookTbl != null)
                    {
                        bookTbl.Title = mTxtTitle.Text;
                        bookTbl.Author = textBox2.Text;
                        bookTbl.Publisher = textBox3.Text;
                        bookTbl.translator = textBox4.Text;
                        mc.SaveChanges();
                    }
                }
            }

            }
            this.Close();
        }
 
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }


    }
}
