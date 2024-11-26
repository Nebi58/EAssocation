using EAssociation;
using EAssociation.Business;
using EAssociation.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace EAssociation
{
    public partial class Member_SignUp : Form
    {
        public Member_SignUp()
        {
            InitializeComponent();
            cmbCity.DataSource = city;
            cmbBloodType.DataSource = bloodtype;
        }
            Sign_Up sign=new Sign_Up();
        private void btnSignUp_Click(object sender, EventArgs e)
        {
            string tc = mskTC.Text;
            try
            {
                sign.AddMember(new Member
                {
                    Member_TC = mskTC.Text,
                    Member_Name = txtName.Text,
                    Member_Surname = txtSurname.Text,
                    Member_Password = mskPassword.Text,
                    Member_Phone = mskPhone.Text,
                    Member_BloodType = cmbBloodType.Text,
                    Member_City = cmbCity.Text,
                    Member_Email = txtEmail.Text,
                    Member_Status = cmbStatus.Text
                });
                Member_MainPage member_MainPage = new Member_MainPage();
                MessageBox.Show("Welcome to IBUN Association.\n You can log in now.");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
   

private List<string> city = new List<string>
        {
            "Adana",
            "Adıyaman",
            "Afyonkarahisar",
            "Ağrı",
            "Aksaray",
            "Amasya",
            "Ankara",
            "Antalya",
            "Ardahan",
            "Artvin",
            "Aydın",
            "Balıkesir",
            "Bartın",
            "Batman",
            "Bayburt",
            "Bilecik",
            "Bingöl",
            "Bitlis",
            "Bolu",
            "Burdur",
            "Bursa",
            "Çanakkale",
            "Çankırı",
            "Çorum",
            "Denizli",
            "Diyarbakır",
            "Düzce",
            "Edirne",
            "Elazığ",
            "Erzincan",
            "Erzurum",
            "Eskişehir",
            "Gaziantep",
            "Giresun",
            "Gümüşhane",
            "Hakkâri",
            "Hatay",
            "Iğdır",
            "Isparta",
            "İstanbul",
            "İzmir",
            "Kahramanmaraş",
            "Karabük",
            "Karaman",
            "Kars",
            "Kastamonu",
            "Kayseri",
            "Kilis",
            "Kırıkkale",
            "Kırklareli",
            "Kırşehir",
            "Kocaeli",
            "Konya",
            "Kütahya",
            "Malatya",
            "Manisa",
            "Mardin",
            "Mersin",
            "Muğla",
            "Muş",
            "Nevşehir",
            "Niğde",
            "Ordu",
            "Osmaniye",
            "Rize",
            "Sakarya",
            "Samsun",
            "Şanlıurfa",
            "Siirt",
            "Sinop",
            "Sivas",
            "Şırnak",
            "Tekirdağ",
            "Tokat",
            "Trabzon",
            "Tunceli",
            "Uşak",
            "Van",
            "Yalova",
            "Yozgat",
            "Zonguldak"
        };
        
        
        private List<string> bloodtype = new List<string>
        {
            "0 RH+",
            "0 RH-",
            "A RH+",
            "A RH-",
            "B RH+",
            "B RH-",
            "AB RH+",
            "AB RH-"
        };

        private void cmbCity_TextUpdate(object sender, EventArgs e)
        {
            string wanted = cmbCity.Text.ToLower();
            var filtered = city.Where(city => city.ToLower().StartsWith(wanted)).ToList();
            cmbCity.DataSource = filtered;
            cmbCity.DroppedDown = true;
            cmbCity.SelectionStart = wanted.Length;
            cmbCity.SelectionLength = cmbCity.Text.Length - wanted.Length;
        }

        private void cmbBloodType_TextUpdate(object sender, EventArgs e)
        {
            string wanted = cmbBloodType.Text.ToLower();
            var filtered = bloodtype.Where(bloodtype => bloodtype.ToLower().StartsWith(wanted)).ToList();
            cmbBloodType.DataSource = filtered;
            cmbBloodType.DroppedDown = true;
            cmbBloodType.SelectionStart = wanted.Length;
            cmbBloodType.SelectionLength = cmbBloodType.Text.Length - wanted.Length;
        }

        private void closeMembersignAppbtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void closeMembersignAppbtn_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMbrsignUpBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Member_Login member = new Member_Login();
            member.Show();
        }
    }
}
