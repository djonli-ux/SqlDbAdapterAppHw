using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Diagnostics;

namespace DbAdapterAppHw
{
    public partial class Form1 : Form
    {
        private string connString = string.Empty;
        private SqlConnection? conn = null;
        public Form1()
        {
            InitializeComponent();

            connString = ConfigurationManager
                .ConnectionStrings["express"]
                .ConnectionString;

            conn = new SqlConnection (connString);
        }

        private void Fill_btn_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                string query;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
            }
            finally 
            {
                if(conn is not null && conn.State == System.Data.ConnectionState.Open)
                    conn.Close ();
            }
        }

        private void Save_btn_Click(object sender, EventArgs e)
        {

        }
    }
}