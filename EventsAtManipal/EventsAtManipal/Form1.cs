using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;


namespace EventsAtManipal
{
    public partial class Form1 : Form
    {
        OracleConnection conn;
        OracleDataAdapter da;
        DataRow dr;
        DataTable dt;
        DataSet ds;
        OracleCommand cmd;

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
            String c = "";
            switch(comboBox1.SelectedIndex)
            {
                case 0: c = "select password from CCMEMBERS where MEMBER_ID = " + user;
                    break;
                case 1:
                    c = "select password from PARTICIPANT where PARTICIPANT_ID = " + user;
                    break;
                case 2:
                    c = "select password from EVENT_HEADS where HEAD_ID = " + user;
                    break;
                case 3:
                    c = "select password from JUDGES where JUDGE_ID = " + user;
                    break;
            }
            try
            {
                DB_Connect();
                cmd = new OracleCommand();
                cmd.CommandText = c;
                cmd.CommandType = CommandType.Text;
                ds = new DataSet();
                da = new OracleDataAdapter(cmd.CommandText, conn);
                da.Fill(ds, "Tbl_ccmembers");
                dt = ds.Tables["Tbl_ccmembers"];
                int t = dt.Rows.Count;
                dr = dt.Rows[0];
                String opass = dr["password"].ToString();
                if (opass.Equals(pass))
                {
                    MessageBox.Show("Login Successful");
                }
                else
                    MessageBox.Show("Login Unsuccessful");
            }
            catch(Exception e1)
            {
                MessageBox.Show("Login Unsuccessful");
            }
        }

        private void DB_Connect()
        {
            String oradb = "DATA SOURCE=127.0.0.1:1521/ORCL;PERSIST SECURITY INFO=True;USER ID=HR;PASSWORD=password";
            conn = new OracleConnection(oradb);
            conn.Open();
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
