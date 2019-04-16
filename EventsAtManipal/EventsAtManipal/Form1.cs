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
        DatabaseConnection dbc = new DatabaseConnection();
        String user = null;
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
            user = userTextBox.Text;
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
                dbc.DB_Connect();
                dbc.cmd = new OracleCommand();
                dbc.cmd.CommandText = c;
                dbc.cmd.CommandType = CommandType.Text;
                dbc.ds = new DataSet();
                dbc.da = new OracleDataAdapter(dbc.cmd.CommandText, dbc.conn);
                dbc.da.Fill(dbc.ds, "Tbl_ccmembers");
                dbc.dt = dbc.ds.Tables["Tbl_ccmembers"];
                int t = dbc.dt.Rows.Count;
                dbc.dr = dbc.dt.Rows[0];
                String opass = dbc.dr["password"].ToString();
                if (opass.Equals(pass))
                {
                    MessageBox.Show("Login Successful");
                    switch (comboBox1.SelectedIndex)
                    {
                        case 0:
                            CCMembers_form cf = new CCMembers_form();
                            cf.Show();
                            this.Hide();
                            break;
                        case 1:
                            EventHome eh = new EventHome(user);
                            eh.Show();
                            this.Hide();
                            break;
                        case 2:
                            c = "select password from EVENT_HEADS where HEAD_ID = " + user;
                            break;
                        case 3:
                            JudgesForm jf = new JudgesForm();
                            jf.Show();
                            this.Hide();
                            break;
                    }
                }
                else
                    MessageBox.Show("Login Unsuccessful");
            }
            catch(Exception)
            {
                MessageBox.Show("Login Unsuccessful");
            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            ParticipantLoginPage plp = new ParticipantLoginPage();
            plp.Show();
        }
    }
}
