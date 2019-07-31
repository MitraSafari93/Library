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
    public partial class Form3 : Form
    {
        private int ID;
        private Condition condition;
        public Form3()
        {
            condition = Condition.Add;
            InitializeComponent();
        }
        public Form3(int ID)
        {
            InitializeComponent();
            this.ID = ID;
            condition = Condition.Edit;
            setData();
          
        }

        private void setData()
        {
            using (BlogDbContext mc = new BlogDbContext())
            {
                MembersTbl member = mc.MembersTbls.Where(x => x.ID == ID).FirstOrDefault();
                if (member != null)
                {
                    textBox1.Text = member.FullName;
                    textBox2.Text = member.City;
                    textBox3.Text = member.Address;
                    textBox4.Text = member.PhoneNumber.ToString();
                    dateTimePicker1.Value = (DateTime)member.JoinDate;
                    
;
                    mc.SaveChanges();
                }
            }
        }
        private bool validDataForm() 
        {
            bool IsValid = true;
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                errorProvider1.SetError(textBox1, "نام را وارد کنید");
                IsValid = false;
            }
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                errorProvider1.SetError(textBox2, "نام شهر را وارد کنید");
                IsValid = false;
            }
            if (string.IsNullOrEmpty(textBox3.Text))
            {
                errorProvider1.SetError(textBox3, "آدرس را وارد کنید");
                IsValid = false;
            }
            if (string.IsNullOrEmpty(textBox4.Text))
            {
                errorProvider1.SetError(textBox4, "شماره تماس را وارد کنید");
                IsValid = false;
            }

            return IsValid;
        }

         private void textBox4_TextChanged(object sender, EventArgs e)
         {
             if (System.Text.RegularExpressions.Regex.IsMatch(textBox4.Text, "  ^ [0-9]"))
             {
                 textBox4.Text = "";
             }
         }
         private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
         {
             if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
             {
                 e.Handled = true;
             }
         }


                private void btn_cancel_Click(object sender, EventArgs e)
                {
                    this.Close();
                }

                private void btn_save_Click(object sender, EventArgs e)
                {
                    if (!validDataForm())
                        return;

                    using (BlogDbContext le2 = new BlogDbContext())
                    {
                       
                        if (condition == Condition.Add)
                        {
                            MembersTbl mtbl = new MembersTbl()
                            {
                                FullName = textBox1.Text,
                                City = textBox2.Text,
                                Address = textBox3.Text,
                                PhoneNumber = Int32.Parse(textBox4.Text),
                                JoinDate = (DateTime)dateTimePicker1.Value,
                                ExpiryDate = new DateTime(dateTimePicker1.Value.Year+1,dateTimePicker1.Value.Month,dateTimePicker1.Value.Day)

                            };
                            le2.MembersTbls.Add(mtbl);
                            le2.SaveChanges();
                        }
                        else
                        {
                            MembersTbl mtbl = le2.MembersTbls.Where(x => x.ID == this.ID).FirstOrDefault();
                            if (mtbl != null)
                            {
                                mtbl.FullName = textBox1.Text;
                                mtbl.City = textBox2.Text;
                                mtbl.Address = textBox3.Text;
                                mtbl.PhoneNumber = Int32.Parse(textBox4.Text);
                                mtbl.JoinDate = (DateTime)dateTimePicker1.Value;
                                mtbl.ExpiryDate = new DateTime(dateTimePicker1.Value.Year + 1, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day);

                                le2.SaveChanges();
                            }
                        }

                        this.Close();

                    }
                }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
