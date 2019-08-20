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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(textBox1.Text))
                {
                    int ID = Int32.Parse(textBox1.Text);
                    using (BlogDbContext mc = new BlogDbContext())
                    {
                        BookTbl removeBook = mc.BookTbls.Where(c => c.ID == ID).FirstOrDefault();
                        if (removeBook != null)
                        {
                            mc.BookTbls.Remove((BookTbl)removeBook);
                            MessageBox.Show("The book removed successfully.");
                            mc.SaveChanges();
                        }
                        else
                        {
                            MessageBox.Show("Book not found.","NOT FOUND!");
                        }
                        this.Close();
                    }
                }
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
