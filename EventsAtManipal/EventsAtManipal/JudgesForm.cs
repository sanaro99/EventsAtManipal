using Oracle.ManagedDataAccess.Client;
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
    public partial class JudgesForm : Form
    {
        DatabaseConnection dbc = new DatabaseConnection();
        public JudgesForm()
        {
            InitializeComponent();
            populateTable();
            populateComboBox();
        }
        String part;

        public void populateTable()
        {
            dbc.DB_Connect();
            dbc.cmd = new OracleCommand();
            dbc.cmd.CommandText = "select * from participant";
            dbc.cmd.CommandType = CommandType.Text;
            dbc.ds = new DataSet();
            dbc.da = new OracleDataAdapter(dbc.cmd.CommandText, dbc.conn);
            dbc.da.Fill(dbc.ds, "Tbl_ccmembers");
            dbc.dt = dbc.ds.Tables["Tbl_ccmembers"];
            int t = dbc.dt.Rows.Count;
            dbc.dr = dbc.dt.Rows[0];
            dataGridView1.DataSource = dbc.ds;
            dataGridView1.DataMember = "Tbl_ccmembers";
            dbc.conn.Close();
        }

        private void populateComboBox()
        {
            dbc.DB_Connect();
            dbc.cmd = new OracleCommand();
            dbc.cmd.CommandText = " select event_name from event";
            dbc.cmd.CommandType = CommandType.Text;
            dbc.ds = new DataSet();
            dbc.da = new OracleDataAdapter(dbc.cmd.CommandText, dbc.conn);
            dbc.da.Fill(dbc.ds, "Tbl_volunteers");
            dbc.dt = dbc.ds.Tables["Tbl_volunteers"];
            int t = dbc.dt.Rows.Count;
            dbc.dr = dbc.dt.Rows[0];
            comboBox1.DataSource = dbc.dt.DefaultView;
            comboBox1.DisplayMember = "EVENT_NAME";
            dbc.conn.Close();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.part = dataGridView1[0, e.RowIndex].Value.ToString();
            //if (flag == 0)
            //{
            //    this.label5.Text = dataGridView1[0, e.RowIndex].Value.ToString();
            //    flag++;
            //}
            //if (flag == 1)
            //{
            //    this.label6.Text = dataGridView1[0, e.RowIndex].Value.ToString();
            //    flag--;
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.label5.Text = this.part;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.label6.Text = this.part;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DatabaseConnection dbc = new DatabaseConnection();
            dbc.DB_Connect();
            int id1 = int.Parse(this.label5.Text);
            int id2 = int.Parse(this.label6.Text);
            dbc.cmd = new OracleCommand();
            dbc.cmd.Connection = dbc.conn;
            dbc.cmd.CommandText = "insert into WINNERS values('DOTA 2',"+id1+","+id2+",300,200)";
            dbc.cmd.CommandType = CommandType.Text;
            //dbc.cmd.ExecuteNonQuery();
            MessageBox.Show("Inserted!");
            dbc.conn.Close();

        }
    }
        //select team_id from team t, judge j where t.event_name = j.event_name;

        //select team_id from qualified q, judge j where q.event_name = j.event_name and round=< ROUND >;

        //insert into qualified values(event_name, round+1, team_id);
}
