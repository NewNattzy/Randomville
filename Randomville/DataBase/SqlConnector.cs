using System;
using Microsoft.Data.SqlClient;


namespace DataBase
{

    public static class SqlConnector
    {

        private static readonly string connectionString = "Server=NATTZY\\SQLEXPRESS;Database=Randomville;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True";

        /* Крайне хреново, но обращаться к методу я планирую не часто. В будущем переделаю.
           Пока что бороться с 100-ней запросов не буду, выполняется 0.5 секунд вместо 0.02 */ 
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

            }

            return gameObject;

        }

    }

}