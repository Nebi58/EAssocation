using EAssociation.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAssociation.Business
{
    public class Show_Month
    {
        public OleDbDataReader Month()
        {
            Connection connection=new Connection();
            OleDbCommand command = new OleDbCommand("Select Month_Name as 'Month' ,Month_Price as 'Price' from Tbl_Month",connection.connection());
            OleDbDataReader reader = command.ExecuteReader();
            connection.connection().Close();
            return reader;
        }
    }
}
