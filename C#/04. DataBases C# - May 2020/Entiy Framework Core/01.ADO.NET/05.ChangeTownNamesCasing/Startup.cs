using _01.InitialSetup;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace _05.ChangeTownNamesCasing
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            string targetCountryName = Console.ReadLine();
            StringBuilder outputMessage = new StringBuilder();

            using SqlConnection sqlConnection = new SqlConnection(Configuration.ConnectionString);
            sqlConnection.Open();

            int affectedRows = UpdateTownNames(sqlConnection, targetCountryName);
            CheckTheResult(sqlConnection, affectedRows, outputMessage, targetCountryName);

            Console.WriteLine(outputMessage.ToString().TrimEnd());
        }

        private static void CheckTheResult(SqlConnection sqlConnection, int affectedRows, StringBuilder outputMessage, string targetCountryName)
        {
            if (affectedRows == 0)
            {
                outputMessage.AppendLine("No town names were affected.");
            }
            else
            {
                outputMessage.AppendLine($"{affectedRows} town names were affected.");
                GetTownNames(sqlConnection, targetCountryName, outputMessage);
            }
        }

        private static void GetTownNames(SqlConnection sqlConnection, string targetCountryName, StringBuilder outputMessage)
        {
            string getTownsQuery = @"SELECT t.[Name]
	                                        FROM Towns as t
		                                        JOIN Countries AS c 
		                                        ON c.Id = t.CountryCode
		                                        	WHERE c.Name = @countryName;";

            using SqlCommand getTownsCommand = new SqlCommand(getTownsQuery, sqlConnection);
            getTownsCommand.Parameters.AddWithValue("@countryName", targetCountryName);

            using SqlDataReader reader = getTownsCommand.ExecuteReader();

            List<string> townNames = new List<string>();

            while (reader.Read())
            {
                string currentTownName = (string)reader["Name"];
                townNames.Add(currentTownName);
            }

            outputMessage.AppendLine("[" + string.Join(", ", townNames) + "]");
        }

        private static int UpdateTownNames(SqlConnection sqlConnection, string targetCountryName)
        {
            string updateTownNamesQuery = @"UPDATE Towns
                                                SET [Name] = UPPER([Name])
		                                            WHERE CountryCode IN (SELECT c.Id 
									                                          FROM Countries AS c 
										                                           WHERE c.[Name] = @countryName);";

            using SqlCommand updateTownNamesCommand = new SqlCommand(updateTownNamesQuery, sqlConnection);
            updateTownNamesCommand.Parameters.AddWithValue("@countryName", targetCountryName);
            int affectedRows = updateTownNamesCommand.ExecuteNonQuery();

            return affectedRows;
        }
    }
}
