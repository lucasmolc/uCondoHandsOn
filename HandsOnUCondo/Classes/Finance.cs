using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HandsOnUCondo.Classes
{
    public class Finance
    {
        private int financeId;
        private int idStatus;
        private string description;
        private decimal financeValue;
        private string expiration;
        private int period;
        private int type;
        private string creation;

        public int FinanceId { get => financeId; set => financeId = value; }
        public int IdStatus { get => idStatus; set => idStatus = value; }
        public string Description { get => description; set => description = value; }
        public decimal FinanceValue { get => financeValue; set => financeValue = value; }
        public string Expiration { get => expiration; set => expiration = value; }
        public int Period { get => period; set => period = value; }
        public int Type { get => type; set => type = value; }
        public string Creation { get => creation; set => creation = value; }

        public int Add()
        {
            // Add finance to database
            try
            {
                SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                SqlCommand cmd = new SqlCommand("FinanceAdd");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = sqlConnection;

                cmd.Parameters.AddWithValue("@IdStatus", IdStatus);
                cmd.Parameters.AddWithValue("@Description", Description);
                cmd.Parameters.AddWithValue("@FinanceValue", FinanceValue);
                cmd.Parameters.AddWithValue("@Expiration", Expiration);
                cmd.Parameters.AddWithValue("@Period", Period);
                cmd.Parameters.AddWithValue("@Type", Type);
                cmd.Parameters.AddWithValue("@Creation", DateTime.Now);

                sqlConnection.Open();
                FinanceId = Convert.ToInt32(cmd.ExecuteScalar());
                sqlConnection.Close();

                return FinanceId;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public void Update()
        {
            // Update finance in database
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("FinanceUpdate");
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Connection = sqlConnection;

            cmd.Parameters.AddWithValue("@FinanceId", FinanceId);
            cmd.Parameters.AddWithValue("@IdStatus", IdStatus);
            cmd.Parameters.AddWithValue("@Description", Description);
            cmd.Parameters.AddWithValue("@FinanceValue", FinanceValue);
            cmd.Parameters.AddWithValue("@Expiration", Expiration);
            cmd.Parameters.AddWithValue("@Period", Period);
            cmd.Parameters.AddWithValue("@Type", Type);

            sqlConnection.Open();
            cmd.ExecuteScalar();
            sqlConnection.Close();
        }

        public void Delete()
        {
            // Delete finance from database
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("FinanceDelete");
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Connection = sqlConnection;

            cmd.Parameters.AddWithValue("@FinanceId", FinanceId);

            sqlConnection.Open();
            cmd.ExecuteScalar();
            sqlConnection.Close();
        }

        public void Get(int _financeId)
        {
            // Get finance from database
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("FinanceGet");
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@FinanceId", _financeId);
            cmd.Connection = sqlConnection;
            sqlConnection.Open();


            SqlDataReader varData = cmd.ExecuteReader();

            while (varData.Read())
            {
                FinanceId = Convert.ToInt32(varData["Id"].ToString());
                IdStatus = Convert.ToInt32(varData["IdStatus"].ToString());
                Description = Convert.ToString(varData["Description"].ToString());
                FinanceValue = Convert.ToDecimal(varData["FinanceValue"].ToString());
                Expiration = varData["ExpirationDate"].ToString();
                Period = Convert.ToInt32(varData["FinancePeriod"].ToString());
                Type = Convert.ToInt32(varData["FinanceType"].ToString());
                Creation = varData["CreationDate"].ToString();
            }

            cmd.Dispose();
            sqlConnection.Close();
        }
    }
}