using _01.InitialSetup;
using Microsoft.Data.SqlClient;
using System;
using System.Text;

namespace _09.IncreaseAgeStoredProcedure
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            int targetMinionId = int.Parse(Console.ReadLine());
            StringBuilder outputMessage = new StringBuilder();

            using SqlConnection sqlConnection = new SqlConnection(Configuration.ConnectionString);
            sqlConnection.Open();

            IncreaseMinionaAge(sqlConnection, targetMinionId);
            GetMinionsInfo(sqlConnection, targetMinionId, outputMessage);

            Console.WriteLine(outputMessage.ToString().TrimEnd());
        }

        private static void GetMinionsInfo(SqlConnection sqlConnection, int targetMinionId, StringBuilder outputMessage)
        {
            string getMinionQuery = @"SELECT [Name], Age 
	                                    FROM Minions 
                                            WHERE Id = @Id;";

            using SqlCommand getMinionCommand = new SqlCommand(getMinionQuery, sqlConnection);
            getMinionCommand.Parameters.AddWithValue("@Id", targetMinionId);

            using SqlDataReader reader = getMinionCommand.ExecuteReader();

            while (reader.Read())
            {
                string minionName = (string)reader["Name"];
                int minionAge = (int)reader["Age"];

                outputMessage.AppendLine($"{minionName} - {minionAge} years old");
            }
        }

        private static void IncreaseMinionaAge(SqlConnection sqlConnection, int targetMinionId)
        {
            string increaseAgeQuery = @"usp_GetOlder @id";

            using SqlCommand increaseAgeCommand = new SqlCommand(increaseAgeQuery, sqlConnection);
            increaseAgeCommand.Parameters.AddWithValue("@id", targetMinionId);
            increaseAgeCommand.ExecuteNonQuery();
        }
    }
}
