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
    public class Member_Status
    {
        public DataTable status()
        {
            Connection connection = new Connection();
            OleDbCommand command = new OleDbCommand("Select Member_TC,Member_Name,Member_Surname,Member_Status from Tbl_Member", connection.connection());
            OleDbDataReader reader = command.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            reader.Close();
            connection.connection().Close();
            return table;
        }
    }
}
