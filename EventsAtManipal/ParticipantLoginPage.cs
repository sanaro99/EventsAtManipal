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
    public partial class ParticipantLoginPage : Form
    {
        OracleConnection connection;
        OracleCommand command2;
        OracleCommand command;
        DataSet dataset;
        DataRow datarow;
        DataTable datatable;
        OracleDataAdapter dataadapter;
        int i = 0;
        

        private void DB_Connect()
        {
            String ConnectionString = "DATA SOURCE=127.0.0.1:1521/ORCL;PERSIST SECURITY INFO=True;USER ID=HR;PASSWORD=password";
            connection = new OracleConnection(ConnectionString);
            connection.Open();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string name = NameTextBox.Text;
            string password = PasswordTextBox.Text;
            string college = CollegeComboBox.SelectedItem.ToString();
            string arrivaldate = ArrivalDatePicker.Text;
            string returndate = ReturnDatePicker.Text;
            int block = int.Parse(HostelComboBox.SelectedItem.ToString());
            char gender = 'G';
            if (FemaleRadioButton.Checked)
                gender = 'F';
            else
            if (MaleRadioButton.Checked)
                gender = 'M';
            DB_Connect();
            command = new OracleCommand();
            command.Connection = connection;
            command.CommandText = "select * from participant";
            command.CommandType = CommandType.Text;
            dataset = new DataSet();
            dataadapter = new OracleDataAdapter(command.CommandText, connection);
            dataadapter.Fill(dataset, "participant");
            datatable = dataset.Tables["participant"];
            int id = datatable.Rows.Count;
            id = id + 1001;
                 
            try
            {
                command2 = new OracleCommand();
                command2.Connection = connection;
                command2.CommandText = "insert into PARTICIPANT values ( " + id + " , '" + name + "' , to_date('" + arrivaldate + "', 'dd-mm-yyyy') , to_date('" + returndate + "', 'dd-mm-yyyy') , " + block + ", '" + gender + "' , '" + college + "' , '" + password +"' )";
                command2.CommandType = CommandType.Text;
                command2.ExecuteNonQuery();
                MessageBox.Show("Registered! Your ID is " + id.ToString());
                connection.Close();
            }
            catch (Exception e1) {
                MessageBox.Show(e1.ToString());
            }
        }

        private void ParticipantLoginPage_Load(object sender, EventArgs e)
        {
            ArrivalDatePicker.Format = DateTimePickerFormat.Custom;
            ArrivalDatePicker.CustomFormat = "dd-MM-yyyy";
            ReturnDatePicker.Format = DateTimePickerFormat.Custom;
            ReturnDatePicker.CustomFormat = "dd-MM-yyyy";

            string[] colleges = {"MIT Manipal", "MIT Sikkim", "ISM Dhanbad", "SRM Amaravati", "VIT Chennai", "MIT Jaipur", "IIT Delhi", "BITS Pilani"};
            CollegeComboBox.DataSource = colleges;
        }

        private void ArrivalDatePicker_ValueChanged(object sender, EventArgs e)
        {
        }

        private void FemaleRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            string[] boyshostels = { "5", "6", "8", "9", "10", "14", "15", "16", "17", "18", "19" };
            string[] girlshostels= { "1", "2", "3", "4", "7", "11", "12", "13", "20", "21", "22" };
            if (FemaleRadioButton.Checked)
                HostelComboBox.DataSource = girlshostels;
            else
                HostelComboBox.DataSource = boyshostels;
        }
    }
}
