using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace EventsAtManipal
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }


    public class DatabaseConnection
    {
        public OracleConnection conn;
        public OracleDataAdapter da;
        public DataRow dr;
        public DataTable dt;
        public DataSet ds;
        public OracleCommand cmd;

        public void DB_Connect()
        {
            String oradb = "DATA SOURCE=127.0.0.1:1521/ORCL;PERSIST SECURITY INFO=True;USER ID=HR;PASSWORD=password";
            conn = new OracleConnection(oradb);
            conn.Open();
        }
    }
}
