using EAssociation.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAssociation.Business
{
    public class List_Blood
    {
        public OleDbDataReader List(string bloodtype)
        {
            Connection connection=new Connection();
            OleDbCommand command = new OleDbCommand("Select Member_TC,Member_Name,Member_Surname,Member_Phone,Member_BloodType,Member_City,Member_Email,Member_Status from Tbl_Member where Member_BloodType=@p1", connection.connection());
            command.Parameters.AddWithValue("@p1", bloodtype);
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
