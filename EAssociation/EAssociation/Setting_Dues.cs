using EAssociation.Business;
using EAssociation.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace EAssociation
{
    public partial class Setting_Dues : Form
    {
        public Setting_Dues()
        {
            InitializeComponent();
            cmbMonth.DataSource = months;
        }
        private List<string> months = new List<string> {
            "January","February","March","April","May","June","July","August","September","October","November","December"
        };
        private void Setting_Dues_Load(object sender, EventArgs e)
        {
            Show_Month show_Month = new Show_Month();
            OleDbDataReader reader = show_Month.Month();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            reader.Close();
            dgwDues.DataSource = dataTable;
        }

        private void cmbMonth_TextUpdate(object sender, EventArgs e)
        {
            string selected = cmbMonth.Text.ToLower();
            var filtered = months.Where(months => months.ToLower().StartsWith(selected)).ToList();
            cmbMonth.DataSource = filtered;
            cmbMonth.DroppedDown = true;
            cmbMonth.SelectionStart = selected.Length;
            cmbMonth.SelectionLength = cmbMonth.Text.Length - selected.Length;
        }

        private void dgwDues_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int selected = dgwDues.SelectedCells[0].RowIndex;
            cmbMonth.Text = dgwDues.Rows[selected].Cells[0].Value.ToString();
            txtDue.Text = dgwDues.Rows[selected].Cells[1].Value.ToString();
        }
        public void GetData()
        {
            Connection connection = new Connection();
            OleDbCommand command = new OleDbCommand("Select Month_Name as 'Month',Month_Price as 'Price' from Tbl_Month", connection.connection());
            OleDbDataAdapter adapter = new OleDbDataAdapter(command);
            DataTable data = new DataTable();
            adapter.Fill(data);
            dgwDues.DataSource = data;
        }

        private void closesecretersetDueAppbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Due_Update due_Update = new Due_Update();
                due_Update.Due_Updated(Convert.ToInt32(txtDue.Text), cmbMonth.Text);
                due_Update.Due_Borc_Guncelleme();
                MessageBox.Show("Updated...");
                GetData();
            }
            catch
            {
                MessageBox.Show("Wrong money or month...");
            }
        }
    }
}
