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
    public class Secreter_Info
    {
        public OleDbDataReader secreterinfo(string tc)
        {
            Connection connection = new Connection();
            OleDbCommand command = new OleDbCommand("Select Secreter_Name,Secreter_Surname from Tbl_Secreter where Secreter_TC=@p1", connection.connection());
            command.Parameters.AddWithValue("@p1", tc);
            OleDbDataReader reader = command.ExecuteReader();
            connection.connection().Close();
            return reader;
        }
    }
}
