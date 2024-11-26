using EAssociation.Business;
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
    public partial class List_Status : Form
    {
        public List_Status()
        {
            InitializeComponent();
            cmbStatus.DataSource = status;
        }

        private List<string> status = new List<string>
        {
            "Active",
            "Passive"
        };

        private void cmbStatus_TextUpdate(object sender, EventArgs e)
        {
            string wanted = cmbStatus.Text.ToLower();
            var filtered = status.Where(status => status.ToLower().StartsWith(wanted)).ToList();
            cmbStatus.DataSource = filtered;
            cmbStatus.DroppedDown = true;
            cmbStatus.SelectionStart = wanted.Length;
            cmbStatus.SelectionLength = cmbStatus.Text.Length - wanted.Length;
        }

        private void closesecreterstatAppbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            string status = cmbStatus.Text;
            List_State list_State = new List_State();
            OleDbDataReader reader = list_State.List(status);
            DataTable table = list_State.table(reader);
            dgwList.DataSource = table;
            dgwList.Columns["Member_TC"].HeaderText = "TC";
            dgwList.Columns["Member_Name"].HeaderText = "Name";
            dgwList.Columns["Member_Surname"].HeaderText = "Surname";
            dgwList.Columns["Member_Phone"].HeaderText = "Phone Number";
            dgwList.Columns["Member_BloodType"].HeaderText = "Blood Type";
            dgwList.Columns["Member_City"].HeaderText = "City";
            dgwList.Columns["Member_Email"].HeaderText = "Email";
            dgwList.Columns["Member_Status"].HeaderText = "Status";
        }

        private void Pdfdownloadbtn_Click(object sender, EventArgs e)
        {
            if (dgwList.Rows.Count > 0)
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "PDF(.pdf|.pdf";
                save.FileName = "MemberListbyCity.pdf";
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
                            PdfPTable pdftable = new PdfPTable(dgwList.Columns.Count);
                            pdftable.DefaultCell.Padding = 2;
                            pdftable.WidthPercentage = 100;
                            pdftable.HorizontalAlignment = Element.ALIGN_LEFT;

                            foreach (DataGridViewColumn col in dgwList.Columns)
                            {
                                PdfPCell pdfcell = new PdfPCell(new Phrase(col.HeaderText));
                                pdftable.AddCell(pdfcell);
                            }
                            foreach (DataGridViewRow viewRow in dgwList.Rows)
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
    }
}
