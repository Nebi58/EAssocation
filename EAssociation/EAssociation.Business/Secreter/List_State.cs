using EAssociation.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace EAssociation.Business
{
    public class List_State
    {
        public OleDbDataReader List(string member)
        {
            Connection connection = new Connection();
            OleDbCommand command = new OleDbCommand("Select Member_TC,Member_Name,Member_Surname,Member_Phone,Member_BloodType,Member_City,Member_Email,Member_Status from Tbl_Member where Member_Status=@p1", connection.connection());
            command.Parameters.AddWithValue("@p1", member);
            OleDbDataReader reader = command.ExecuteReader();
            connection.connection().Close();
            return reader;
        }
        public DataTable table(OleDbDataReader reader)
        {
            DataTable table = new DataTable();
            table.Load(reader);
            reader.Close();
            return table;
        }
    }
}
