using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Dash.Models
{
    public class UserAdoRepository : IUserDAO
    {
        bool IUserDAO.Authenticate(LoginViewModel user)
        {
            string conString = ConfigurationManager.ConnectionStrings["ConDB"].ConnectionString;
            SqlConnection con = new SqlConnection(conString);
            string sqlQuery = String.Format("Select ID from Users Where UserID='{0}'AND Password='{1}'",user.UserID,user.Password);
            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            Boolean found = dr.HasRows;
            con.Close();
            return found;
            //throw new NotImplementedException();
        }

        void IDAO<RegisterUserViewModel>.Delete(int id)
        {
            throw new NotImplementedException();
        }

        object IDAO<RegisterUserViewModel>.insert(RegisterUserViewModel t)
        {
            string conString = ConfigurationManager.ConnectionStrings["ConDB"].ConnectionString;
            SqlConnection con = new SqlConnection(conString);
            //string sqlQuery = String.Format( "Insert into Users(FirstName,LastName,Password) values('{0}','{1}','{2}')",t.FirstName,t.LastName,t.Password);
            String sqlQuery = "spInsertUser";
            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@firstname", t.FirstName);
            cmd.Parameters.AddWithValue("@lastname", t.LastName);
            cmd.Parameters.AddWithValue("@password", t.Password);


            con.Open();
            String UserID = cmd.ExecuteScalar().ToString();
            con.Close();//throw new NotImplementedException();
            return UserID; 
        }

        RegisterUserViewModel IDAO<RegisterUserViewModel>.Select(int id)
        {
            throw new NotImplementedException();
        }

        List<RegisterUserViewModel> IDAO<RegisterUserViewModel>.Select()
        {
            throw new NotImplementedException();
        }

        void IDAO<RegisterUserViewModel>.Update(RegisterUserViewModel t)
        {
            throw new NotImplementedException();
        }
    }
}