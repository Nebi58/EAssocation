using EAssociation.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAssociation.Business
{
    public class Due_Update
    {
        public void Due_Updated(int money,string month)
        {
            Connection connection = new Connection();
            OleDbCommand command = new OleDbCommand("Update Tbl_Month set Month_Price=@p1 where Month_Name=@p2",connection.connection());
            command.Parameters.AddWithValue("@p1", money);
            command.Parameters.AddWithValue("@p2", month);
            command.ExecuteNonQuery();
            connection.connection().Close();
        }
        public void Due_Borc_Guncelleme()
        {
            Connection connection = new Connection();

            // Tbl_Month tablosundan tüm ayları al
            OleDbCommand selectMonthsCommand = new OleDbCommand("SELECT Month_Id, Month_Price FROM Tbl_Month", connection.connection());
            OleDbDataReader monthsReader = selectMonthsCommand.ExecuteReader();

            while (monthsReader.Read())
            {
                int monthId = Convert.ToInt32(monthsReader["Month_Id"]);
                int monthPrice = Convert.ToInt32(monthsReader["Month_Price"]);

                // Tbl_Member tablosundan tüm üyeleri al
                OleDbCommand selectMembersCommand = new OleDbCommand("SELECT Member_TC FROM Tbl_Member", connection.connection());
                OleDbDataReader membersReader = selectMembersCommand.ExecuteReader();

                while (membersReader.Read())
                {
                    string memberTC = membersReader["Member_TC"].ToString();

                    // Tbl_Payment tablosuna yeni kayıt ekle
                    OleDbCommand insertPaymentCommand = new OleDbCommand("INSERT INTO Tbl_Payment (Kimlik, OdemeDurumu, OdemeMiktarı, BorcMiktarı, Month_Id, Member_TC) VALUES (@p1, 'Hayır', 0, @p2, @p3, @p4)", connection.connection());
                    insertPaymentCommand.Parameters.AddWithValue("@p1", Guid.NewGuid().ToString()); // Unique kimlik oluştur
                    insertPaymentCommand.Parameters.AddWithValue("@p2", monthPrice);
                    insertPaymentCommand.Parameters.AddWithValue("@p3", monthId);
                    insertPaymentCommand.Parameters.AddWithValue("@p4", memberTC);

                    insertPaymentCommand.ExecuteNonQuery();
                }

                membersReader.Close();
            }

            monthsReader.Close();
            connection.connection().Close();
        }

        public void Due_Borc_Guncelleme(int money, string month)
        {
            Connection connection = new Connection();
            OleDbCommand command = new OleDbCommand("Update Tbl_Payment set OdemeDurum=false, OdemeMiktar=0, BorcMiktar = @p1 where Month_Name=@p2", connection.connection());
            command.Parameters.AddWithValue("@p1", money);
            command.Parameters.AddWithValue("@p2", month);
            command.ExecuteNonQuery();
            connection.connection().Close();
        }
    }
}
