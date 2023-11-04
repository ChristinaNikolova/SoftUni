using _01.InitialSetup;
using Microsoft.Data.SqlClient;
using System;
using System.Linq;
using System.Text;

namespace _08.IncreaseMinionAge
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            int[] minionIds = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            StringBuilder outputMessage = new StringBuilder();

            using SqlConnection sqlConnection = new SqlConnection(Configuration.ConnectionString);
            sqlConnection.Open();

            IncreaseMinionsAge(sqlConnection, minionIds);
            GetMinionsInfo(sqlConnection, outputMessage);

            Console.WriteLine(outputMessage.ToString().TrimEnd());
        }

        private static void GetMinionsInfo(SqlConnection sqlConnection, StringBuilder outputMessage)
        {
            string getMinionsQuery = @"SELECT [Name], Age 
	                                       FROM Minions;";

            using SqlCommand getMinionsCommand = new SqlCommand(getMinionsQuery, sqlConnection);
            using SqlDataReader reader = getMinionsCommand.ExecuteReader();

            while (reader.Read())
            {
                string minionName = (string)reader["Name"];
                int minionAge = (int)reader["Age"];

                outputMessage.AppendLine($"{minionName.TrimEnd()} {minionAge}");
            }
        }

        private static void IncreaseMinionsAge(SqlConnection sqlConnection, int[] minionIds)
        {
            string updateMinionsAgeQuery = @"UPDATE Minions
	                                            SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1
		                                            WHERE Id = @Id;";

            for (int i = 0; i < minionIds.Length; i++)
            {
                int currentId = minionIds[i];

                using SqlCommand updateMinionsAgeCommand = new SqlCommand(updateMinionsAgeQuery, sqlConnection);
                updateMinionsAgeCommand.Parameters.AddWithValue("@Id", currentId);
                updateMinionsAgeCommand.ExecuteNonQuery();
            }
        }
    }
}
