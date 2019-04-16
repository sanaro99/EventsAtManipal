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
    public partial class EventHome : Form
    {
        OracleConnection connection;
        OracleCommand command2;
        OracleCommand command;
        DataSet dataset;
        DataRow datarow;
        DataTable datatable;
        OracleDataAdapter dataadapter;
        int i = 0;
        String user;

        public EventHome(string user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void DB_Connect()
        {
            String ConnectionString = "DATA SOURCE=127.0.0.1:1521/ORCL;PERSIST SECURITY INFO=True;USER ID=HR;PASSWORD=password";
            connection = new OracleConnection(ConnectionString);
            connection.Open();
        }

        private void EventHome_Load(object sender, EventArgs e)
        {
            DB_Connect();
            command = new OracleCommand();
            command.CommandText = "select event_name as Event, description as Description from EVENT";
            command.CommandType = CommandType.Text;
            dataset = new DataSet();
            dataadapter = new OracleDataAdapter(command.CommandText, connection);
            dataadapter.Fill(dataset, "event");
            datatable = dataset.Tables["event"];
            datarow = datatable.Rows[i];
            datagrid.DataSource = dataset;
            datagrid.DataMember = "event";
            connection.Close();
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            string eventname = datagrid.SelectedRows[0].Cells[0].Value.ToString();
            TeamPage tp = new TeamPage(user,eventname);
            this.Hide();
            tp.Show();
            MessageBox.Show(eventname);
        }
    }
}
