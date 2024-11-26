using EAssociation.Business;
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
    public partial class Member_MainPage : Form
    {
        public Member_MainPage()
        {
            InitializeComponent();
        }
        public string tc;
        private void Member_MainPage_Load(object sender, EventArgs e)
        {
            lblTC.Text = tc;
            User_Info user_Info = new User_Info();
            OleDbDataReader reader = user_Info.userinfo(tc);
            while (reader.Read())
            {
                lblName.Text = reader[0] + " ";
                lblSurname.Text = reader[1] + " ";
            }
        }
      

        private void closeMemberMainbtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnPayDue_Click(object sender, EventArgs e)
        {
            Due_Payment due_Payment = new Due_Payment();
            due_Payment.Show();
            this.Hide();
        }

        private void logOutimagebtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure to log out?", "Log out", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                IBUN ibun = new IBUN();
                this.Hide();
                ibun.Show();
            }
            else
            {

            }
        }
    }
}
