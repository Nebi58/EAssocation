using EAssociation.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAssociation.Business
{
    public class User_Info
    {
        public OleDbDataReader userinfo(string tc)
        {
            Connection connection = new Connection();
            OleDbCommand command = new OleDbCommand("Select Member_Name,Member_Surname from Tbl_Member where Member_TC=@p1", connection.connection());
            command.Parameters.AddWithValue("@p1", tc);
            OleDbDataReader reader = command.ExecuteReader();
            connection.connection().Close();
            return reader;
        }
    }
}
