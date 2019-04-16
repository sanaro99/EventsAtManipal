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
        }

        public void populateTable()
        {
            dbc.DB_Connect();
            dbc.cmd = new OracleCommand();
            dbc.cmd.CommandText = "select * from ccmembers";
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
    }
        //select team_id from team t, judge j where t.event_name = j.event_name;

        //select team_id from qualified q, judge j where q.event_name = j.event_name and round=< ROUND >;

        //insert into qualified values(event_name, round+1, team_id);
}
