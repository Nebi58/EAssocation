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
    public class Secreter_Log
    {
        public OleDbDataReader LogIn(string tc, string password)
        {
            Connection connection = new Connection();
            OleDbCommand command = new OleDbCommand("Select * from Tbl_Secreter where Secreter_TC=@p1 and Secreter_Password=@p2", connection.connection());
            command.Parameters.AddWithValue("@p1", tc);
            command.Parameters.AddWithValue("@p2", password);
            OleDbDataReader reader = command.ExecuteReader();
            connection.connection().Close();
            return reader;
        }
    }
}
