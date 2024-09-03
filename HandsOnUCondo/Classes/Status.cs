using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HandsOnUCondo.Classes
{
    public class Status
    {
        private int idStatus;
        private string statusName;

        public int IdStatus { get => idStatus; set => idStatus = value; }
        public string StatusName { get => statusName; set => statusName = value; }

        public List<Status> GetAllStatus()
        {
            List<Status> statusList = new List<Status>();

            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Status");
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = sqlConnection;

                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Status status = new Status();
                    status.IdStatus = Convert.ToInt32(reader["Id"]);
                    status.StatusName = reader["Status"].ToString();
                    statusList.Add(status);
                }

                reader.Close();
            }

            return statusList;
        }
    }
}