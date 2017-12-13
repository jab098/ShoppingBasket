using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shopping_Basket
{
    public partial class Edit : Form
    {
        public BasketItem basketitem { get; set; }

        public Edit()
        {
            InitializeComponent();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating user input
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
                MessageBox.Show("Please enter a correct value");
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validating user input
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
                MessageBox.Show("Please enter a correct value");
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Edit.ActiveForm.Close();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            //Validating and entering the information
            Form1 otherform = new Form1();
            otherform.listBox1.Items.Remove(otherform.listBox1.SelectedItem);
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please complete all fields");
            }
            else if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Please complete all fields");

            }
            else if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Please complete all fields");
            }
            else
            {
                foreach (var item in otherform.listBox1.Items)
                {
                    otherform.listBox1.Items.Add(item);
                }
                BasketItem newItem = new BasketItem(textBox1.Text, Convert.ToInt32(textBox2.Text), Convert.ToDouble(textBox3.Text));
                otherform.listBox1.Items.Add(newItem);
                this.Close();
            }
            otherform.Show();
        }

        private void Edit_Load(object sender, EventArgs e)
        {
            //Adding the selected item information
            textBox1.Text = basketitem.Name;
            textBox2.Text = basketitem.Quantity.ToString();
            textBox3.Text = basketitem.Price.ToString();
        }
    }
}
