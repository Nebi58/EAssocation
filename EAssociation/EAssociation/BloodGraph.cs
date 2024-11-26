using EAssociation.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace EAssociation
{
    public partial class BloodGraph : Form
    {
        Connection connection = new Connection();
        public BloodGraph()
        {
            InitializeComponent();
            CreateMemberBloodTypeGraph();
        }

        private void closeSecretecgraphbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void BloodGraph_Load(object sender, EventArgs e)
        {
            connection.connection();
        }
        private void CreateMemberBloodTypeGraph()
        {
            // ZedGraphControl'dan bir GraphPane al
            GraphPane graphPane = zedGraphControl2.GraphPane;
            graphPane.Title.Text = "Member Blood Type Graph";
            graphPane.XAxis.Title.Text = "Blood Type";
            graphPane.YAxis.Title.Text = "Member Count";

            // Şehir bazında üye sayılarını al
            PointPairList pointPairList = GetMemberCountByBloodType();

            // Çubuk grafik oluştur
            BarItem barItem = graphPane.AddBar("Member", pointPairList, Color.Black);

            // Grafik özelliklerini özelleştir
            graphPane.BarSettings.ClusterScaleWidth = 0.6; // Cluster'lar arası boşluk
            graphPane.BarSettings.Type = BarType.Cluster; // Çubuk tipini belirt

            // X ekseni tipini metin olarak ayarla
            graphPane.XAxis.Type = AxisType.Text;

            // X ekseni üzerindeki şehir isimlerini ayarla
            string[] bloodTypes = GetBloodTypes(); // Bu fonksiyonu oluşturmanız gerekiyor
            graphPane.XAxis.Scale.TextLabels = bloodTypes;

            // Grafik güncellensin
            zedGraphControl2.AxisChange();
            zedGraphControl2.Invalidate();
        }
        private string[] GetBloodTypes()
        {
            try
            {
                string query = "SELECT DISTINCT Member_BloodType FROM Tbl_Member";
                OleDbCommand command = new OleDbCommand(query, connection.connection());
                OleDbDataReader reader = command.ExecuteReader();

                List<string> bloodTypes = new List<string>();

                while (reader.Read())
                {
                    string blood = reader["Member_BloodType"].ToString();
                    bloodTypes.Add(blood);
                }

                reader.Close();

                return bloodTypes.ToArray();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is an error while collecting blood type data " + ex.Message);
                return new string[0];
            }
        }
        private PointPairList GetMemberCountByBloodType()
        {
            PointPairList pointPairList = new PointPairList();

            try
            {
                string query = "SELECT Member_BloodType, COUNT(*) AS MemberCount FROM Tbl_Member GROUP BY Member_BloodType";
                OleDbCommand command = new OleDbCommand(query, connection.connection());
                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string blood = reader["Member_BloodType"].ToString();
                    double memberCount = Convert.ToDouble(reader["MemberCount"]);

                    pointPairList.Add(pointPairList.Count + 1, memberCount); 
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Üye sayıları alınırken hata oluştu: " + ex.Message);
            }

            return pointPairList;
        }

        private void BloodGraph_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (connection != null && connection.connection().State == System.Data.ConnectionState.Open)
            {
                connection.connection().Close();
            }
        }
    }
}
