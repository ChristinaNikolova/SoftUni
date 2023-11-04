using _01.InitialSetup;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07.PrintAllMinionNames
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            using SqlConnection sqlConnection = new SqlConnection(Configuration.ConnectionString);
            sqlConnection.Open();

            StringBuilder outputMessage = new StringBuilder();

            GetMinionNames(sqlConnection, outputMessage);

            Console.WriteLine(outputMessage.ToString().TrimEnd());
        }

        private static void GetMinionNames(SqlConnection sqlConnection, StringBuilder outputMessage)
        {
            string getMinionNamesQuery = @"SELECT [Name] 
                                                FROM Minions;";

            using SqlCommand getMinionNamesCommand = new SqlCommand(getMinionNamesQuery, sqlConnection);
            using SqlDataReader reader = getMinionNamesCommand.ExecuteReader();

            List<string> minionNames = new List<string>();

            while (reader.Read())
            {
                string currentMinionName = (string)reader["Name"];
                minionNames.Add(currentMinionName);
            }

            OrderMinionNames(minionNames, outputMessage);
        }

        private static void OrderMinionNames(List<string> minionNames, StringBuilder outputMessage)
        {
            for (int i = 0; i < minionNames.Count / 2; i++)
            {
                outputMessage.AppendLine(minionNames[i]);
                outputMessage.AppendLine(minionNames[minionNames.Count - 1 - i]);
            }

            if (minionNames.Count % 2 != 0)
            {
                outputMessage.AppendLine(minionNames[minionNames.Count / 2]);
            }
        }
    }
}
