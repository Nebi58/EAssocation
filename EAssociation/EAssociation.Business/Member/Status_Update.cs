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
    public class Status_Update
    {
        public void update(Member member)
        {
            Connection connection = new Connection();
            OleDbCommand command = new OleDbCommand("Update Tbl_Member SET Member_Status=@p1 where Member_TC=@p2", connection.connection());
            command.Parameters.AddWithValue("@p1",member.Member_Status);
            command.Parameters.AddWithValue("@p2", member.Member_TC);
            command.ExecuteNonQuery();
            connection.connection().Close();
            
        }
    }
}
