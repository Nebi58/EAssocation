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
    public partial class Secreter_Login : Form
    {
        public Secreter_Login()
        {
            InitializeComponent();
        }

        private void closeSecreterlogAppbtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnScrtlogInBack_Click(object sender, EventArgs e)
        {
            IBUN iBUN = new IBUN();
            this.Hide();
            iBUN.Show();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string tc = mskTC.Text;
            string password = mskPassword.Text;
            Secreter_Log secreter_Log = new Secreter_Log();
            OleDbDataReader reader = secreter_Log.LogIn(tc, password);
            if (reader.Read())
            {
                Secreter_MainPage secreter_MainPage = new Secreter_MainPage();
                secreter_MainPage.tc = mskTC.Text;
                secreter_MainPage.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("You have entered wrong password or TC.\n Please try again.","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                mskTC.Clear();
                mskPassword.Clear();
                mskTC.Focus();
            }
        }
    }
}
