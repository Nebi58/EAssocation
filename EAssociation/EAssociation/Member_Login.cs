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
    public partial class Member_Login : Form
    {
        public Member_Login()
        {
            InitializeComponent();
        }

        private void lnkUyeOl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Member_SignUp signUp = new Member_SignUp();
            signUp.Show();
            this.Hide();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string tc = mskTC.Text;
            string password = mskPassword.Text;
            Login login = new Login();
            OleDbDataReader reader = login.LogIn(tc, password);
            if (reader.Read())
            {
                Member_MainPage main = new Member_MainPage();
                main.tc = mskTC.Text;
                main.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("You have entered wrong password or TC.\n Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskTC.Clear();
                mskPassword.Clear();
                mskTC.Focus();
            }
            }

        private void closeMemberlogAppbtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMbrlogInBack_Click(object sender, EventArgs e)
        {
            IBUN iBun = new IBUN();
            this.Hide();
            iBun.Show();
        }
    }
    }

