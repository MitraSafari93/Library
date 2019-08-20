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
    public partial class DeleteForm : Form
    {
        public DeleteForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                try
                {
                    int ID = int.Parse(textBox1.Text);
                    using (BlogDbContext mc = new BlogDbContext())
                    {
                        MembersTbl removeMem = mc.MembersTbls.Where(x => x.ID == ID).FirstOrDefault();
                        if (removeMem != null)
                        {
                            mc.MembersTbls.Remove(removeMem);
                            mc.SaveChanges();
                            MessageBox.Show("The member removed successfully.");
                        }
                        else
                            MessageBox.Show("Member not found.", "NOT FOUND!");
                    }
                    this.Close();
                }
                catch (FormatException)
                {
                    MessageBox.Show("ID must be a number!", "INCORRECT FORMAT!");
                }
                catch (OverflowException ex)
                {
                    MessageBox.Show(ex.Message, "OVERFLOW!");
                }
            }
        }

        private void DeleteForm_Load(object sender, EventArgs e)
        {

        }
    }
}
