using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data;
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

            conn = new SqlConnection(connString);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadTable();
        }

        private void Fill_btn_Click(object sender, EventArgs e)
        {
            using (conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    string query = $"SELECT * FROM users";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    using SqlDataReader reader = cmd.ExecuteReader();
                    DataTable dt = new DataTable();

                    dt.Load(reader);

                    dgv.DataSource = dt;

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERROR: {ex.Message}");
                }
                finally
                {
                    if (conn is not null && conn.State == System.Data.ConnectionState.Open)
                        conn.Close();
                }
            }
        }

        private void Save_btn_Click(object sender, EventArgs e)
        {

        }

        private void LoadTable()
        {
            try
            {
                using (conn = new SqlConnection(connString))
                {
                    conn.Open();

                    string query = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    using SqlDataReader reader = cmd.ExecuteReader();
                    DataTable dt = new DataTable();

                    dt.Load(reader);

                    TableList.DataSource = dt;
                    TableList.DisplayMember = "TABLE_NAME";
                    TableList.ValueMember = "TABLE_NAME";
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                if (conn is not null && conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }
    }
}