using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EAssociation
{
    public partial class IBUN : Form
    {
        public IBUN()

        {
            InitializeComponent();
        }

        private void closeAppbtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void logInimagebtn_Click(object sender, EventArgs e)
        {
            Member_Login member = new Member_Login();
            member.Show();
            this.Hide();
        }

        private void signupButton_Click(object sender, EventArgs e)
        {
            Member_SignUp member = new Member_SignUp();
            member.Show();
            this.Hide();
        }

        private void logInSecreterbtn_Click(object sender, EventArgs e)
        {
            Secreter_Login secreter = new Secreter_Login();
            secreter.Show();
            this.Hide();
        }
    }
}
