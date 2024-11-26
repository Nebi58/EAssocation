using EAssociation.Business;
using EAssociation.DataAccess;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EAssociation
{
    public partial class Secreter_MainPage : Form
    {
        public Secreter_MainPage()
        {
            InitializeComponent();
        }
        public string tc;
        private void Secreter_MainPage_Load(object sender, EventArgs e)
        {
            lblTC.Text = tc;
            Secreter_Info secreter_Info = new Secreter_Info();
            OleDbDataReader reader = secreter_Info.secreterinfo(tc);
            while (reader.Read())
            {
                lblName.Text = reader[0] + " ";
                lblSurname.Text = reader[1] + " ";
            }
            Member_List member_List = new Member_List();
            dgwMembers.DataSource = member_List.select();
            dgwMembers.Columns["Member_TC"].HeaderText = "TC";
            dgwMembers.Columns["Member_Name"].HeaderText = "Name";
            dgwMembers.Columns["Member_Surname"].HeaderText = "Surname";
            dgwMembers.Columns["Member_Phone"].HeaderText = "Phone Number";
            dgwMembers.Columns["Member_BloodType"].HeaderText = "Blood Type";
            dgwMembers.Columns["Member_City"].HeaderText = "City";
            dgwMembers.Columns["Member_Email"].HeaderText = "Email";
            dgwMembers.Columns["Member_Status"].HeaderText = "Status";
        }
        public void GetData2()
        {
            Connection connection = new Connection();
            OleDbCommand command = new OleDbCommand("Select Member_TC,Member_Name,Member_Surname,Member_Phone,Member_BloodType,Member_City,Member_Email,Member_Status from Tbl_Member", connection.connection());
            OleDbDataAdapter adapter = new OleDbDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dgwMembers.DataSource = dataTable;
        }

        private void closeSecreterMainbtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnBloodType_Click(object sender, EventArgs e)
        {
            List_BloodType list_BloodType = new List_BloodType();
            list_BloodType.Show();
        }

        private void btnCity_Click(object sender, EventArgs e)
        {
            List_City list_City = new List_City();
            list_City.Show();
        }

        private void btnStatus_Click(object sender, EventArgs e)
        {
            List_Status list_Status = new List_Status();
            list_Status.Show();
        }

        private void btncitygraph_Click(object sender, EventArgs e)
        {
            Form1 form1= new Form1();
            form1.Show();
        }

        private void btnSettingStatus_Click(object sender, EventArgs e)
        {
            Setting_Member_Status status = new Setting_Member_Status();
            status.Owner = this;
            status.Show();
        }

        private void btnDues_Click(object sender, EventArgs e)
        {
            Setting_Dues setting_Dues = new Setting_Dues();
            setting_Dues.Show();
        }


        private void Pdfdownloadbtn_Click(object sender, EventArgs e)
        {
            if (dgwMembers.Rows.Count > 0)
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "PDF(.pdf|.pdf";
                save.FileName = "MemberList.pdf";
                bool ErrorMessage = false;
                if (save.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(save.FileName))
                    {
                        try
                        {
                            File.Delete(save.FileName);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Couldn't write on disk" + ex.Message);
                        }
                    }
                    if (!ErrorMessage)
                    {
                        try
                        {
                            PdfPTable pdftable = new PdfPTable(dgwMembers.Columns.Count);
                            pdftable.DefaultCell.Padding = 2;
                            pdftable.WidthPercentage = 100;
                            pdftable.HorizontalAlignment = Element.ALIGN_LEFT;

                            foreach (DataGridViewColumn col in dgwMembers.Columns)
                            {
                                PdfPCell pdfcell = new PdfPCell(new Phrase(col.HeaderText));
                                pdftable.AddCell(pdfcell);
                            }
                            foreach (DataGridViewRow viewRow in dgwMembers.Rows)
                            {
                                foreach (DataGridViewCell dgwCell in viewRow.Cells)
                                {
                                    pdftable.AddCell(dgwCell.Value.ToString());
                                }
                            }
                            using (FileStream fileStream = new FileStream(save.FileName, FileMode.Create))
                            {
                                using (Document document = new Document(PageSize.A4, 8f, 16f, 16f, 8f))
                                {
                                    PdfWriter.GetInstance(document, fileStream);

                                    document.Open();
                                    document.Add(pdftable);
                                    document.Close();
                                }

                                fileStream.Close();
                            }
                            MessageBox.Show("Member List saved in Pdf format", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("There is an error while converting Pdf format", "Error" + ex.Message);
                        }
                    }
                }
            }
            else 
            {
                MessageBox.Show("Couldn't find data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            GetData2();
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
