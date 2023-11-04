using _01.InitialSetup;
using Microsoft.Data.SqlClient;
using System;
using System.Text;

namespace _06.RemoveVillain
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            int targetVillainId = int.Parse(Console.ReadLine());
            StringBuilder outputMessage = new StringBuilder();

            using SqlConnection sqlConnection = new SqlConnection(Configuration.ConnectionString);
            sqlConnection.Open();

            SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

            try
            {
                string villainName = GetVillainName(sqlConnection, sqlTransaction, targetVillainId);
                CheckTheVillainName(villainName, outputMessage, sqlConnection, sqlTransaction, targetVillainId);
            }
            catch (Exception ex)
            {
                outputMessage.AppendLine(ex.Message);

                try
                {
                    sqlTransaction.Rollback();
                }
                catch (Exception exRollback)
                {
                    outputMessage.AppendLine(exRollback.Message);
                }
            }


            Console.WriteLine(outputMessage.ToString().TrimEnd());
        }

        private static void CheckTheVillainName(string villainName, StringBuilder outputMessage, SqlConnection sqlConnection, SqlTransaction sqlTransaction, int targetVillainId)
        {
            if (villainName == null)
            {
                outputMessage.AppendLine("No such villain was found.");
            }
            else
            {
                DeleteVillain(sqlConnection, sqlTransaction, targetVillainId, villainName, outputMessage);
            }
        }

        private static void DeleteVillain(SqlConnection sqlConnection, SqlTransaction sqlTransaction, int targetVillainId, string villainName, StringBuilder outputMessage)
        {
            int deletedMinions = DeleteFromMappingTable(sqlConnection, sqlTransaction, targetVillainId);

            DeleteFromVillainTable(sqlConnection, sqlTransaction, targetVillainId);

            outputMessage.AppendLine($"{villainName} was deleted.");
            outputMessage.AppendLine($"{deletedMinions} minions were released.");

            sqlTransaction.Commit();
        }

        private static int DeleteFromMappingTable(SqlConnection sqlConnection, SqlTransaction sqlTransaction, int targetVillainId)
        {
            string deleteVillainFromMappingTableQuery = @"DELETE FROM MinionsVillains 
                                                                   WHERE VillainId = @villainId;";

            using SqlCommand deleteVillainFromMappingTableCommand =
                new SqlCommand(deleteVillainFromMappingTableQuery, sqlConnection);
            deleteVillainFromMappingTableCommand.Parameters.AddWithValue("@villainId", targetVillainId);
            deleteVillainFromMappingTableCommand.Transaction = sqlTransaction;
            int deletedMinions = deleteVillainFromMappingTableCommand.ExecuteNonQuery();

            return deletedMinions;
        }

        private static void DeleteFromVillainTable(SqlConnection sqlConnection, SqlTransaction sqlTransaction, int targetVillainId)
        {
            string deleteVillainQuery = @"DELETE FROM Villains
                                                   WHERE Id = @villainId;";

            using SqlCommand deleteVillainCommand = new SqlCommand(deleteVillainQuery, sqlConnection);
            deleteVillainCommand.Parameters.AddWithValue("@villainId", targetVillainId);
            deleteVillainCommand.Transaction = sqlTransaction;
            deleteVillainCommand.ExecuteNonQuery();
        }

        private static string GetVillainName(SqlConnection sqlConnection, SqlTransaction sqlTransaction, int targetVillainId)
        {
            string getVillainIdQuery = @"SELECT [Name] 
	                                        FROM Villains 
		                                        WHERE Id = @villainId;";

            using SqlCommand getVillainIdCommand = new SqlCommand(getVillainIdQuery, sqlConnection);
            getVillainIdCommand.Parameters.AddWithValue("@villainId", targetVillainId);
            getVillainIdCommand.Transaction = sqlTransaction;

            string villainName = (string)getVillainIdCommand.ExecuteScalar();

            return villainName;
        }
    }
}
