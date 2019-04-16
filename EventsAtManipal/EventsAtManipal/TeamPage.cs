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
    public partial class TeamPage : Form
    {
        OracleConnection connection;
        OracleCommand command2;
        OracleCommand command;
        DataSet dataset;
        DataRow datarow;
        DataTable datatable;
        OracleDataAdapter dataadapter;
        int i = 0;
        int teamid;
        String user;
        String eventname;

        public TeamPage(String user,String eventname)
        {
            InitializeComponent();
            this.user = user;
            this.eventname = eventname;
        }

        private void DB_Connect()
        {
            String ConnectionString = "DATA SOURCE=127.0.0.1:1521/ORCL;PERSIST SECURITY INFO=True;USER ID=HR;PASSWORD=password";
            connection = new OracleConnection(ConnectionString);
            connection.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DB_Connect();
            command = new OracleCommand();
            command.Connection = connection;
            command.CommandText = "select * from team";
            command.CommandType = CommandType.Text;
            dataset = new DataSet();
            dataadapter = new OracleDataAdapter(command.CommandText, connection);
            dataadapter.Fill(dataset, "team");
            datatable = dataset.Tables["team"];
            teamid = datatable.Rows.Count;
            teamid = teamid + 101;
            team.Text = teamid.ToString();
            team.ReadOnly = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DB_Connect();
            command = new OracleCommand();
            command.Connection = connection;
            command.CommandText = "insert into TEAM values (" + teamid + ", '" + eventname +"')";
            command.CommandType = CommandType.Text;
            command.ExecuteNonQuery();
            command2 = new OracleCommand();
            command2.Connection = connection;
            command2.CommandText = "insert into TEAM_MEMBERS values (" + teamid + ", " + int.Parse(user) + ")";
            command2.CommandType = CommandType.Text;
            command2.ExecuteNonQuery();
            string msg = "Your Team ID for the " + eventname + " is " + teamid.ToString();
            MessageBox.Show(msg);
        }

        private void TeamPage_Load(object sender, EventArgs e)
        {
            ParticipantIDLabel.Text = user;
            EventNameLabel.Text = eventname;
        }
    }
}
