using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;
using System.Threading;
using EAssociation.DataAccess;
using System.Data.OleDb;

namespace EAssociation
{
    public partial class Form1 : Form
    {
        Connection connection=new Connection();
        public Form1()
        {
            InitializeComponent();
            CreateMemberDistributionGraph();
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            connection.connection();
        }
        private void CreateMemberDistributionGraph()
        {
            // ZedGraphControl'dan bir GraphPane al
            GraphPane graphPane = zedGraphControl1.GraphPane;
            graphPane.Title.Text = "Üye Dağılım Grafiği";
            graphPane.XAxis.Title.Text = "Şehir";
            graphPane.YAxis.Title.Text = "Üye Sayısı";

            // Şehir bazında üye sayılarını al
            PointPairList pointPairList = GetMemberCountByCity();

            // Çubuk grafik oluştur
            BarItem barItem = graphPane.AddBar("Üye Sayısı", pointPairList, Color.Blue);

            // Grafik özelliklerini özelleştir
            graphPane.BarSettings.ClusterScaleWidth = 0.6; // Cluster'lar arası boşluk
            graphPane.BarSettings.Type = BarType.Cluster; // Çubuk tipini belirt

            // X ekseni tipini metin olarak ayarla
            graphPane.XAxis.Type = AxisType.Text;

            // X ekseni üzerindeki şehir isimlerini ayarla
            string[] cityNames = GetCityNames(); // Bu fonksiyonu oluşturmanız gerekiyor
            graphPane.XAxis.Scale.TextLabels = cityNames;

            // Grafik güncellensin
            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
        }

        private string[] GetCityNames()
        {
            try
            {
                string query = "SELECT DISTINCT Member_City FROM Tbl_Member";
                OleDbCommand command = new OleDbCommand(query, connection.connection());
                OleDbDataReader reader = command.ExecuteReader();

                List<string> cityNames = new List<string>();

                while (reader.Read())
                {
                    string city = reader["Member_City"].ToString();
                    cityNames.Add(city);
                }

                reader.Close();

                return cityNames.ToArray();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Şehir isimleri alınırken hata oluştu: " + ex.Message);
                return new string[0];
            }
        }
        private PointPairList GetMemberCountByCity()
        {
            PointPairList pointPairList = new PointPairList();

            try
            {
                string query = "SELECT Member_City, COUNT(*) AS MemberCount FROM Tbl_Member GROUP BY Member_City";
                OleDbCommand command = new OleDbCommand(query, connection.connection());
                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string city = reader["Member_City"].ToString();
                    double memberCount = Convert.ToDouble(reader["MemberCount"]);

                    // Yeni bir PointPair ekleyerek grafiğe değerleri ekleyin
                    pointPairList.Add(pointPairList.Count + 1, memberCount); // X değeri olarak sıralı bir sayı eklenir.
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Üye sayıları alınırken hata oluştu: " + ex.Message);
            }

            return pointPairList;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (connection != null && connection.connection().State == System.Data.ConnectionState.Open)
            {
                connection.connection().Close();
            }
        }

        private void closeSecretecgraphbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
