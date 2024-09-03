using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace HandsOnUCondo.Classes
{
    public class User
    {
        private int userId;
        private string userName;
        private string userMail;
        private string userCPF;
        private string userPassword;

        public int UserId { get => userId; set => userId = value; }
        public string UserName { get => userName; set => userName = value; }
        public string UserMail { get => userMail; set => userMail = value; }
        public string UserCPF { get => userCPF; set => userCPF = value; }
        public string UserPassword { get => userPassword; set => userPassword = value; }

        public int Add()
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                SqlCommand cmd = new SqlCommand("UsuarioAdd");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = sqlConnection;

                cmd.Parameters.AddWithValue("@UserName", UserName);
                cmd.Parameters.AddWithValue("@UserMail", UserMail);
                cmd.Parameters.AddWithValue("@UserCPF", UserCPF);
                cmd.Parameters.AddWithValue("@UserPassword", Util.Md5("handsOn" + UserPassword + "2o!4"));

                sqlConnection.Open();
                UserId = Convert.ToInt32(cmd.ExecuteScalar());
                sqlConnection.Close();

                return UserId;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public void Delete()
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("UsuarioDelete");
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Connection = sqlConnection;

            cmd.Parameters.AddWithValue("@UserId", UserId);

            sqlConnection.Open();
            cmd.ExecuteScalar();
            sqlConnection.Close();
        }

        public void Get(int _userId)
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("UsuarioGet");
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@UserId", _userId);
            cmd.Connection = sqlConnection;
            sqlConnection.Open();


            SqlDataReader varData = cmd.ExecuteReader();

            while (varData.Read())
            {
                UserId = Convert.ToInt32(varData["Id"].ToString());
                UserName = Convert.ToString(varData["UserName"].ToString());
                UserMail = Convert.ToString(varData["UserMail"].ToString());
                UserCPF = Convert.ToString(varData["UserCPF"].ToString());
                UserPassword = Convert.ToString(varData["UserPassword"].ToString());
            }

            cmd.Dispose();
            sqlConnection.Close();
        }

        public void Update()
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("UsuarioUpdate");
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Connection = sqlConnection;

            cmd.Parameters.AddWithValue("@UserId", UserId);
            cmd.Parameters.AddWithValue("@UserName", UserName);
            cmd.Parameters.AddWithValue("@UserMail", UserMail);
            cmd.Parameters.AddWithValue("@UserCPF", UserCPF);

            sqlConnection.Open();
            cmd.ExecuteScalar();
            sqlConnection.Close();
        }

        public void UpdatePassword()
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("UsuarioUpdatePassword");
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Connection = sqlConnection;

            cmd.Parameters.AddWithValue("@UserId", UserId);
            cmd.Parameters.AddWithValue("@UserPassword", Util.Md5("handsOn" + UserPassword + "2o!4"));

            sqlConnection.Open();
            cmd.ExecuteScalar();
            sqlConnection.Close();
        }

        public static bool Login(string _userMail, string _userPassword)
        {
            try
            {
                if (_userMail.IsNullOrWhiteSpace() || _userPassword.IsNullOrWhiteSpace() || !Util.isMail(_userMail))
                {
                    return false;
                }

                // Password Decrypt
                _userPassword = Util.Md5("handsOn" + _userPassword + "2o!4");

                int _userId = 0;
                bool keepalive = false;

                // Verify if user exists
                SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                SqlCommand cmd = new SqlCommand();

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "SELECT * FROM Users WHERE UserMail = @UserMail AND UserPassword = @UserPassword";
                cmd.Parameters.AddWithValue("@UserMail", _userMail);
                cmd.Parameters.AddWithValue("@UserPassword", _userPassword);

                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader varData = cmd.ExecuteReader();

                int i = 0;
                while (varData.Read())
                {
                    // Count the number of users found
                    i++;

                    _userId = Convert.ToInt32(varData["Id"].ToString());
                }
                sqlConnection.Close();

                if (i != 1)
                {
                    return false;
                }

                // Create a cookie
                HttpContext.Current.Response.Cookies.Add(new HttpCookie("UserId", _userId.ToString()));
                HttpContext.Current.Response.Cookies.Add(new HttpCookie("KeepAlive", keepalive.ToString()));

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static void Logout()
        {
            if (HttpContext.Current != null)
            {
                int cookieCount = HttpContext.Current.Request.Cookies.Count;
                for (var i = 0; i < cookieCount; i++)
                {
                    var cookie = HttpContext.Current.Request.Cookies[i];
                    if (cookie != null)
                    {
                        var expiredCookie = new HttpCookie(cookie.Name)
                        {
                            Expires = DateTime.Now.AddDays(-1),
                            Domain = cookie.Domain
                        };
                        HttpContext.Current.Response.Cookies.Add(expiredCookie); // overwrite it
                    }
                }

                // clear cookies server side
                HttpContext.Current.Request.Cookies.Clear();

                // redirec
                HttpContext.Current.Session.Abandon();

                // logout
                FormsAuthentication.SignOut();

                // Redirect
                HttpContext.Current.Response.Redirect("~/Login/");
            }
            else
            {
                //Redirect
                HttpContext.Current.Response.Redirect("~/Login/");
            }
        }
    }
}