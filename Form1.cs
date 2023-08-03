using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Diagnostics;

namespace DbAdapterAppHw
{
    public partial class Form1 : Form
    {
        private string? selectedTableName = string.Empty;
        private string connString = string.Empty;
        private SqlConnection? conn = null;
        private SqlDataAdapter adapter;
        private DataSet ds;
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
            try
            {
                dgv.DataSource = null;
                Update();

                string query = $"SELECT * FROM {selectedTableName}";

                adapter = new SqlDataAdapter(query, conn);
                ds = new DataSet();

                adapter.Fill(ds);
                dgv.DataSource = ds.Tables[0];
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

        private void Save_btn_Click(object sender, EventArgs e)
        {
            adapter.Update(ds.Tables[0]);
        }

        private void LoadTable()
        {
            try
            {
                string query = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'";

                adapter = new SqlDataAdapter(query, conn);
                ds = new DataSet { };
                adapter.Fill(ds);

                TableList.DataSource = ds.Tables[0];
                TableList.DisplayMember = "TABLE_NAME";
                TableList.ValueMember = "TABLE_NAME";
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

        private void TableList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TableList.SelectedItems is not null && TableList.SelectedItem is DataRowView selectedRow)
            {
                dgv.DataSource = null;
                Update();
                selectedTableName = selectedRow["TABLE_NAME"].ToString();
            }
        }
    }
}