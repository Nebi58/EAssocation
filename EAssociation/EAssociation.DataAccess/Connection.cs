using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAssociation.DataAccess
{
    public class Connection
    {
        public OleDbConnection connection()
        {
            OleDbConnection oleDbConnection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\ucarn\OneDrive\Belgeler\EAssociation.accdb");
            OleDbConnection connection = oleDbConnection;
            connection.Open();
            return connection;
        }
    }
}
