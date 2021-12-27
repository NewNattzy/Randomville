using Microsoft.Data.SqlClient;

namespace Storage
{
    public static class SqlConnector
    {

        // Нихрена пока не работает, не выкупаю в чем проблема
        private static string connectionString = "Server=NATTZY\\SQLEXPRESS;Database=Randomville;Trusted_Connection=True";

        public static void GetCollection()
        {

            string sqlExpression = "SELECT * FROM Enemies WHERE ID = 1";//command;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand sqlCommand = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = sqlCommand.ExecuteReader();


                if (reader.HasRows)
                {

                    object id = reader.GetValue(0);
                    object type = reader.GetValue(1);
                    object health = reader.GetValue(2);
                    object mana = reader.GetValue(3);
                    object damage = reader.GetValue(4);
                    object level = reader.GetValue(5);
                    object exp = reader.GetValue(6);
                    object gold = reader.GetValue(7);
                    object fraction = reader.GetValue(8);
                    object rank = reader.GetValue(9);


                    Console.WriteLine($"{type} \t{health} \t{mana}");

                }
                connection.Close();
            }

        }

    }
}