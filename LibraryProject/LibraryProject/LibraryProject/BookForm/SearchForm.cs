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
    enum TypeSearch {title,auther,publisher}
    public partial class _SearchForm : Form
    {
        public _SearchForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (BlogDbContext mc = new BlogDbContext())
            {   
                string str = "select * from BookTbl where ";
                bool tmp=false;
                if (CheckEmptyText(textBox1.Text))
                {
                  str += "title=N'" + textBox1.Text+ "'";
                 tmp = true ;
                }

                if (CheckEmptyText(textBox2.Text))
                {
                    if (tmp)
                        str += " and ";
                    str += " author=N'" + textBox2.Text + "'";
                    tmp = true;
                }
                if (CheckEmptyText(textBox3.Text))
                {
                    if (tmp)
                        str += " and ";
                    str += " publisher= N'" + textBox3.Text + "'";
                    tmp = true;
                }
                if (tmp)
                {
                    var search = mc.Database.SqlQuery<BookTbl>(str);
                    dataGridView2.DataSource = search.ToList();
                }
            }
        }
        private bool CheckEmptyText(string txt)
        {
            if (string.IsNullOrEmpty(txt))
                return false;
            return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

    }
}
