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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (BlogDbContext mc = new BlogDbContext()) 
            {
                int ID = Int32.Parse(txt_ID.Text);
                MembersTbl memberList = mc.MembersTbls.Where(x => x.ID == ID).FirstOrDefault();
                if (memberList == null)
                {
                    txt_message.Text = "شناسه کاربری نامعتبر است";
                    return;
                }
                else if( memberList.ExpiryDate < DateTime.Now)
                {
                    txt_message.Text = "تاریخ عضوبت شما به اتمام رسیده";
                }
                else
                {
                    BooksBorrowed Bfrm = new BooksBorrowed(ID);
                    Bfrm.Show();
                }

            }
          
        }
    }
}
