using _01.InitialSetup;
using Microsoft.Data.SqlClient;
using System;
using System.Text;

namespace _03.MinionNames
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            StringBuilder outputMessage = new StringBuilder();
            int targetVillainId = int.Parse(Console.ReadLine());

            using SqlConnection sqlConnection = new SqlConnection(Configuration.ConnectionString);
            sqlConnection.Open();

            bool isVillainFound = true;

            isVillainFound = GetVillainName(outputMessage, targetVillainId, sqlConnection);

            if (isVillainFound)
            {
                GetMinionsInfo(outputMessage, targetVillainId, sqlConnection);
            }

            Console.WriteLine(outputMessage.ToString().TrimEnd());
        }

        private static void GetMinionsInfo(StringBuilder outputMessage, int targetVillainId, SqlConnection sqlConnection)
        {
            string getMinionsQuery = @"SELECT ROW_NUMBER() OVER (ORDER BY m.Name) as RowNum,
                                              m.[Name], 
                                              m.Age
	                                      FROM MinionsVillains AS mv
	                                      	JOIN Minions As m 
	                                      	ON mv.MinionId = m.Id
	                                      		WHERE mv.VillainId = @Id
	                                      			ORDER BY m.[Name] ASC;";

            using SqlCommand getMinionsCommand = new SqlCommand(getMinionsQuery, sqlConnection);
            getMinionsCommand.Parameters.AddWithValue("@Id", targetVillainId);

            using SqlDataReader reader = getMinionsCommand.ExecuteReader();

            bool areMinions = false;

            while (reader.Read())
            {
                areMinions = true;
                long rowNumber = (long)reader["RowNum"];
                string minionName = (string)reader["Name"];
                int minionAge = (int)reader["Age"];

                outputMessage.AppendLine($"{rowNumber}. {minionName} {minionAge}");
            }

            if (!areMinions)
            {
                outputMessage.AppendLine("(no minions)");
                return;
            }
        }

        private static bool GetVillainName(StringBuilder outputMessage, int targetVillainId, SqlConnection sqlConnection)
        {
            string getVillainNameQuery = @"SELECT [Name]
	                                            FROM Villains 
	                                            	WHERE Id = @Id;";

            using SqlCommand getVillainNameCommand = new SqlCommand(getVillainNameQuery, sqlConnection);
            getVillainNameCommand.Parameters.AddWithValue("@Id", targetVillainId);
            string villainName = (string)getVillainNameCommand.ExecuteScalar();

            if (villainName == null)
            {
                outputMessage.AppendLine($"No villain with ID {targetVillainId} exists in the database.");
                return false;
            }

            outputMessage.AppendLine($"Villain: {villainName}");
            return true;
        }
    }
}
