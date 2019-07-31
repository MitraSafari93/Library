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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (BlogDbContext mc = new BlogDbContext())
            {
                List<MembersTbl> tList = new List<MembersTbl>();
                string str = "select * from MembersTbl where ";
                bool tmp = false;
                if (CheckEmptyText(textBox1.Text))
                {
                    str += "FullName=N'" + textBox1.Text + "'";
                    tmp = true;
                }

                if (CheckEmptyText(textBox2.Text))
                {
                    if (tmp)
                        str += " and ";
                    str += " City=N'" + textBox2.Text + "'";
                    tmp = true;
                }
                if (CheckEmptyText(textBox3.Text))
                {
                    if (tmp)
                        str += " and ";
                    str += " Address= N'" + textBox3.Text + "'";
                }

                    var Msearch = mc.Database.SqlQuery<MembersTbl>(str);
                    dataGridView1.DataSource = Msearch.ToList();
                
            }
        }

        public bool CheckEmptyText(string str){
                if(string.IsNullOrEmpty(str))
                    return false;
            return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }
    }
}
