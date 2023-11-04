using _01.InitialSetup;
using Microsoft.Data.SqlClient;
using System;
using System.Text;
using System.Threading;

namespace _02.VillainNames
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            using SqlConnection sqlConnection = new SqlConnection(Configuration.ConnectionString);
            sqlConnection.Open();

            string outputMessage = GetVillainsAndMinionsCount(sqlConnection);

            Console.WriteLine(outputMessage.TrimEnd());
        }

        private static string GetVillainsAndMinionsCount(SqlConnection sqlConnection)
        {
            string getVillainQuery = @"SELECT v.[Name], 
                                              COUNT(mv.VillainId) AS MinionsCount  
                                                    FROM Villains AS v 
	                                                	JOIN MinionsVillains AS mv 
	                                                	ON v.Id = mv.VillainId 
	                                                		GROUP BY v.Id, 
	                                                		         v.[Name]
	                                                			HAVING COUNT(mv.VillainId) > 3
	                                                				ORDER BY COUNT(mv.VillainId) DESC;";

            using SqlCommand getVillainCommand = new SqlCommand(getVillainQuery, sqlConnection);
            using SqlDataReader reader = getVillainCommand.ExecuteReader();

            StringBuilder outputMessage = new StringBuilder();

            while (reader.Read())
            {
                string villainName = (string)reader["Name"];
                int minionsCount = (int)reader["MinionsCount"];

                outputMessage.AppendLine($"{villainName} - {minionsCount}");
            }

            return outputMessage.ToString();
        }
    }
}
