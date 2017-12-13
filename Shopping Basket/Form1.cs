using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shopping_Basket
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public int newtotal = 0;
        public int c;
        public int counting = 0;
        public int allcount;

        public void button1_Click(object sender, EventArgs e)
        {
            //Checking for Validation before adding item
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please complete all fields");
            }
            else if (string.IsNullOrWhiteSpace(textBox5.Text))
            {
                MessageBox.Show("Please complete all fields");

            }
            else if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Please complete all fields");
            }
            else
            {
                BasketItem item = new BasketItem(textBox1.Text, Convert.ToInt32(textBox5.Text), Convert.ToDouble(textBox2.Text));
                listBox1.Items.Add(item);
            }

            //Adding total price + quantity 
            int c;
            bool isCValid = int.TryParse(textBox5.Text, out c);

            if (isCValid)
            {
                allcount = c;
            }
            counting += allcount;
            textBox3.Text = counting.ToString();

            int a, b;
            bool isAValid = int.TryParse(textBox5.Text, out a);
            bool isBValid = int.TryParse(textBox2.Text, out b);

            if (isAValid && isBValid)
            {
                c = (a * b);
            }
            newtotal += c;
            textBox4.Text = newtotal.ToString();
        }

        public void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Remove(listBox1.SelectedItem);
        }

        public void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validation for numbers only
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
                MessageBox.Show("Please enter a correct value");
            }
        }

        public void button4_Click(object sender, EventArgs e)
        {
            //Removing all items and refreshing total price & total quantity
            listBox1.Items.Clear();
            newtotal = 0;
            textBox4.Text = newtotal.ToString();
            counting = 0;
            textBox3.Text = counting.ToString();
        }

        public void button6_Click(object sender, EventArgs e)
        {
            Form1.ActiveForm.Close();
        }

        public void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validation for numbers only
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
                MessageBox.Show("Please enter a correct value");
            }
        }

        public void button5_Click(object sender, EventArgs e)
        {
            //Checking if item is selected
            if (listBox1.Items.Count <= 0)
            {
                MessageBox.Show("You have no items in your shopping basket!");
            }
            else
            {
                //Formatting the item basket into the text doc
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Text File|*.txt";
                sfd.FileName = "Shopping Basket";
                sfd.Title = "Save Text File";
                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string path = sfd.FileName;
                    StreamWriter bw = new StreamWriter(File.Create(path));
                    bw.WriteLine("[Name]                       [Quantity]                  [Price]");
                    foreach (var item in listBox1.Items)
                    {
                        bw.WriteLine(item.ToString());
                    }
                    bw.WriteLine("No. of Items:");
                    bw.WriteLine(textBox3.Text);
                    bw.WriteLine("Total Price:");
                    bw.WriteLine(textBox4.Text);
                    bw.Close();
                    bw.Dispose();
                }
            }
        }

        public void button3_Click(object sender, EventArgs e)
        {
            //Checking is item is selected and launching the edit form
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a basket item");
            }
            else
            {
                BasketItem item = (BasketItem)listBox1.SelectedItem;
                Edit form2 = new Edit();
                form2.basketitem = item;
                form2.ShowDialog();
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            //Validating user input
            if (textBox1.TextLength < 4)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure this is a valid product item?", "Product Item", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    return;
                }
                else if (dialogResult == DialogResult.No)
                {
                    textBox1.ResetText();
                }
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            //Validating user input
            if (textBox2.TextLength > 4)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure this is a price p/item?", "Product Item", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    return;
                }
                else if (dialogResult == DialogResult.No)
                {
                    textBox2.ResetText();
                }
            }
        }
    }
}
