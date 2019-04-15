using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventsAtManipal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label2.BackColor = System.Drawing.Color.Transparent;
            label4.BackColor = System.Drawing.Color.Maroon;
            this.label2.Font = new Font("Calibri ", 40);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            String user = userTextBox.Text;
            String pass = textBox1.Text;
            String table="";
            switch(comboBox1.SelectedIndex)
            {
                case 0: table = "CCMEMBERS";
                    break;
                case 1: table = "PARTICIPANTS";
                    break;
                case 2: table = "EVENT_HEADS";
                    break;
                case 3: table = "JUDGES";
                    break;
            }
            String cmd = "select password from " + table + " where username=" + user;
            MessageBox.Show(cmd);
        }

        private void userTextBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void userTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            userTextBox.Clear();
            userTextBox.Font = new Font("Microsoft Sans Serif", 10);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Clear();
            textBox1.Font = new Font("Microsoft Sans Serif", 10);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
