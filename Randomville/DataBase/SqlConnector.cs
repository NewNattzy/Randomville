using System;
using Microsoft.Data.SqlClient;


namespace DataBase
{

    public static class SqlConnector
    {

        private static readonly string connectionString = "Server=NATTZY\\SQLEXPRESS;Database=Randomville;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True";

        public static List<object> GetCollection(string sqlExpression)
        {

            List<object> gameObject = new List<object>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                SqlCommand sqlCommand = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = sqlCommand.ExecuteReader();


                if (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        gameObject.Add(reader.GetValue(i));
                    }
                }


                connection.Close();

            }

            return gameObject;
        }

    }

}