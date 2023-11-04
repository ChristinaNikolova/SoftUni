using _01.InitialSetup;
using Microsoft.Data.SqlClient;
using System;
using System.Linq;
using System.Text;

namespace _04.AddMinion
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            string[] minionInfo = Console.ReadLine()
                .Split(" ")
                .ToArray();

            string minionName = minionInfo[1];
            int minionAge = int.Parse(minionInfo[2]);
            string minionTown = minionInfo[3];

            string[] villainInfo = Console.ReadLine()
                .Split(" ")
                .ToArray();

            string villainName = villainInfo[1];

            StringBuilder outputMessage = new StringBuilder();

            using SqlConnection sqlConnection = new SqlConnection(Configuration.ConnectionString);
            sqlConnection.Open();

            int? townId = GetTownId(sqlConnection, minionTown, outputMessage);
            int? villainId = GetVillainId(sqlConnection, villainName, outputMessage);

            AddMinionToDB(minionName, minionAge, sqlConnection, townId);

            int minionId = GetMinionId(sqlConnection, minionName);

            AddMinionToVillain(minionName, villainName, outputMessage, sqlConnection, villainId, minionId);

            Console.WriteLine(outputMessage.ToString().TrimEnd());
        }

        private static void AddMinionToVillain(string minionName, string villainName, StringBuilder outputMessage, SqlConnection sqlConnection, int? villainId, int minionId)
        {
            string addMinionToVillainQuery = @"INSERT INTO MinionsVillains (MinionId, VillainId) 
                                                VALUES 
                                                    (@villainId, @minionId);";

            using SqlCommand addMinionToVillainCommand = new SqlCommand(addMinionToVillainQuery, sqlConnection);
            addMinionToVillainCommand.Parameters.AddWithValue("@villainId", villainId);
            addMinionToVillainCommand.Parameters.AddWithValue("@minionId", minionId);
            addMinionToVillainCommand.ExecuteNonQuery();

            outputMessage.AppendLine($"Successfully added {minionName} to be minion of {villainName}.");
        }

        private static int GetMinionId(SqlConnection sqlConnection, string minionName)
        {
            string getMinionIdQuery = @"SELECT Id 
                                            FROM Minions 
                                                WHERE [Name] = @Name;";

            using SqlCommand getMinionIdCommand = new SqlCommand(getMinionIdQuery, sqlConnection);
            getMinionIdCommand.Parameters.AddWithValue("@Name", minionName);
            int minionId = (int)getMinionIdCommand.ExecuteScalar();

            return minionId;
        }

        private static void AddMinionToDB(string minionName, int minionAge, SqlConnection sqlConnection, int? townId)
        {
            string addMinionQuery = @"INSERT INTO Minions ([Name], Age, TownId) 
                                        VALUES 
                                            (@name, @age, @townId);";

            using SqlCommand addMinionCommand = new SqlCommand(addMinionQuery, sqlConnection);
            addMinionCommand.Parameters.AddWithValue("@name", minionName);
            addMinionCommand.Parameters.AddWithValue("@age", minionAge);
            addMinionCommand.Parameters.AddWithValue("@townId", townId);
            addMinionCommand.ExecuteNonQuery();
        }

        private static int? GetVillainId(SqlConnection sqlConnection, string villainName, StringBuilder outputMessage)
        {
            string getVillainIdQuery = @"SELECT Id 
                                            FROM Villains 
                                                WHERE [Name] = @Name;";

            using SqlCommand getVillainIdCommand = new SqlCommand(getVillainIdQuery, sqlConnection);
            getVillainIdCommand.Parameters.AddWithValue("@Name", villainName);
            int? villainId = (int?)getVillainIdCommand.ExecuteScalar();

            if (villainId == null)
            {
                AddVillainToDB(sqlConnection, villainName);
                outputMessage.AppendLine($"Villain {villainName} was added to the database.");
                villainId = (int?)getVillainIdCommand.ExecuteScalar();
            }

            return villainId;
        }

        private static void AddVillainToDB(SqlConnection sqlConnection, string villainName)
        {
            string insertVillainQuety = @"INSERT INTO Villains ([Name], EvilnessFactorId)  
                                                VALUES 
                                                    (@villainName, 4);";

            using SqlCommand insertVillainCommand = new SqlCommand(insertVillainQuety, sqlConnection);
            insertVillainCommand.Parameters.AddWithValue("@villainName", villainName);
            insertVillainCommand.ExecuteNonQuery();
        }

        private static int? GetTownId(SqlConnection sqlConnection, string minionTown, StringBuilder outputMessage)
        {
            string getTownIdQuery = @"SELECT Id 
                                        FROM Towns 
                                            WHERE [Name] = @townName;";

            using SqlCommand getTownIdCommand = new SqlCommand(getTownIdQuery, sqlConnection);
            getTownIdCommand.Parameters.AddWithValue("@townName", minionTown);
            int? townId = (int?)getTownIdCommand.ExecuteScalar();

            if (townId == null)
            {
                AddTownToDB(sqlConnection, minionTown);
                outputMessage.AppendLine($"Town {minionTown} was added to the database.");
                townId = (int?)getTownIdCommand.ExecuteScalar();
            }

            return townId;
        }

        private static void AddTownToDB(SqlConnection sqlConnection, string minionTown)
        {
            string insertTownQuery = @"INSERT INTO Towns ([Name]) 
                                                VALUES 
                                                    (@townName);";

            using SqlCommand insertTownCommand = new SqlCommand(insertTownQuery, sqlConnection);
            insertTownCommand.Parameters.AddWithValue("@townName", minionTown);
            insertTownCommand.ExecuteNonQuery();
        }
    }
}
