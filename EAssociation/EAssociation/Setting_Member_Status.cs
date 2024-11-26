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

namespace EAssociation
{
    public partial class Setting_Member_Status : Form
    {
        public Setting_Member_Status()
        {
            InitializeComponent();
            cmbStatus.DataSource = status;
        }

        private List<string> status = new List<string>
        {
            "Active",
            "Passive"
        };

        private void Setting_Member_Status_Load(object sender, EventArgs e)
        {
            Member_Status member_Status=new Member_Status();
            dgwStatus.DataSource = member_Status.status();
        }

        private void cmbStatus_TextUpdate(object sender, EventArgs e)
        {
            string wanted = cmbStatus.Text.ToLower();
            var filtered = status.Where(status => status.ToLower().StartsWith(wanted)).ToList();
            cmbStatus.DataSource = filtered;
            cmbStatus.DroppedDown = true;
            cmbStatus.SelectionStart = wanted.Length;
            cmbStatus.SelectionLength = cmbStatus.Text.Length - wanted.Length;
        }

        private void dgwStatus_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int selected = dgwStatus.SelectedCells[0].RowIndex;
            mskTC.Text = dgwStatus.Rows[selected].Cells[0].Value.ToString();
            txtName.Text = dgwStatus.Rows[selected].Cells[1].Value.ToString();
            txtSurname.Text = dgwStatus.Rows[selected].Cells[2].Value.ToString();
            cmbStatus.Text = dgwStatus.Rows[selected].Cells[3].Value.ToString();
        }
        public void GetData()
        {
            Connection connection = new Connection();
            OleDbCommand command = new OleDbCommand("Select Member_TC,Member_Name,Member_Surname,Member_Status from Tbl_Member",connection.connection());
            OleDbDataAdapter adapter =new OleDbDataAdapter(command);
            DataTable data = new DataTable();
            adapter.Fill(data);
            dgwStatus.DataSource = data;
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Member member = new Member
            {
                Member_TC = mskTC.Text,
                Member_Name = txtName.Text,
                Member_Surname = txtSurname.Text,
                Member_Status = cmbStatus.Text
            };
            Status_Update status_Update = new Status_Update();
            status_Update.update(member);
            MessageBox.Show("Updated...");
            GetData();
        }

        private void closesecretersetstatAppbtn_Click(object sender, EventArgs e)
        {
            this.Hide();        }
    }
}
