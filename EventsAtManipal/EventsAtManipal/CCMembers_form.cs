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
    public partial class CCMembers_form : Form
    {
        DatabaseConnection dbc = new DatabaseConnection();
        public CCMembers_form()
        {
            InitializeComponent();
            populateTable();
            populateComboBox();
        }

        private void populateComboBox()
        {
            dbc.DB_Connect();
            dbc.cmd = new OracleCommand();
            dbc.cmd.CommandText = " select * from volunteers where category_name is null";
            dbc.cmd.CommandType = CommandType.Text;
            dbc.ds = new DataSet();
            dbc.da = new OracleDataAdapter(dbc.cmd.CommandText, dbc.conn);
            dbc.da.Fill(dbc.ds, "Tbl_volunteers");
            dbc.dt = dbc.ds.Tables["Tbl_volunteers"];
            int t = dbc.dt.Rows.Count;
            dbc.dr = dbc.dt.Rows[0];
            comboBox1.DataSource = dbc.dt.DefaultView;
            comboBox1.DisplayMember = "VOLUNTEER_NAME";
            dbc.conn.Close();
        }

        public void populateTable()
        {
            dbc.DB_Connect();
            dbc.cmd = new OracleCommand();
            dbc.cmd.CommandText = " select * from volunteers where category_name is not null";
            dbc.cmd.CommandType = CommandType.Text;
            dbc.ds = new DataSet();
            dbc.da = new OracleDataAdapter(dbc.cmd.CommandText, dbc.conn);
            dbc.da.Fill(dbc.ds, "Tbl_volunteers");
            dbc.dt = dbc.ds.Tables["Tbl_volunteers"];
            int t = dbc.dt.Rows.Count;
            dbc.dr = dbc.dt.Rows[0];
            dataGridView1.DataSource = dbc.ds;
            dataGridView1.DataMember = "Tbl_volunteers";
            dbc.conn.Close();
        }
    }
}
