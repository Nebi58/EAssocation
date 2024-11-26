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
    public class Sign_Up
    {
        public void AddMember(Member member)
        {
            Connection connection=new Connection();
            OleDbCommand command = new OleDbCommand("INSERT INTO Tbl_Member values (@Member_TC,@Member_Name,@Member_Surname,@Member_Password,@Member_Phone,@Member_BloodType,@Member_City,@Member_Email,@Member_Status)", connection.connection());
            command.Parameters.AddWithValue("@Member_TC", member.Member_TC);
            command.Parameters.AddWithValue("@Member_Name", member.Member_Name);
            command.Parameters.AddWithValue("@Member_Surname", member.Member_Surname);
            command.Parameters.AddWithValue("@Member_Password", member.Member_Password);
            command.Parameters.AddWithValue("@Member_Phone", member.Member_Phone);
            command.Parameters.AddWithValue("@Member_BloodType", member.Member_BloodType);
            command.Parameters.AddWithValue("@Member_City", member.Member_City);
            command.Parameters.AddWithValue("@Member_Email", member.Member_Email);
            command.Parameters.AddWithValue("@Member_Status", member.Member_Status);
            command.ExecuteNonQuery();
            connection.connection().Close();
        }
    }
}
