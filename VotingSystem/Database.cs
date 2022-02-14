using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using System.Data.SQLite;

namespace VotingSystem
{
    public class Database
    {
        public static SQLiteConnection GetDatabaseConnection()
        {
            string connectionString = $"URI=file:{Directory.GetCurrentDirectory()}\\Database.db";
            string stm = "SELECT SQLITE_VERSION()";
            SQLiteConnection conn = new SQLiteConnection(connectionString);
            return conn;
        }


        public static void InitialiseDatabase()
        {
            using (SQLiteConnection conn = GetDatabaseConnection())
            {
                conn.Open();
                SQLiteCommand cmd = conn.CreateCommand();

                // Create the required tables if they don't already exist
                cmd.CommandText = "CREATE TABLE IF NOT EXISTS tblVoter(Username VARCHAR(50) NOT NULL UNIQUE PRIMARY KEY, Password VARCHAR(50) NOT NULL, HasVoted BOOLEAN)";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "CREATE TABLE IF NOT EXISTS tblAdmin(Username VARCHAR(50) NOT NULL UNIQUE PRIMARY KEY, Password VARCHAR(50) NOT NULL)";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "CREATE TABLE IF NOT EXISTS tblAuditor(Username VARCHAR(50) NOT NULL UNIQUE PRIMARY KEY, Password VARCHAR(50) NOT NULL)";
                cmd.ExecuteNonQuery();

                // Create a default administrator
                cmd.CommandText = "SELECT * FROM tblAdmin WHERE Username = 'Admin'";
                if (cmd.ExecuteScalar() == null)
                {
                    cmd.CommandText = "INSERT INTO tblAdmin VALUES ('Admin', 'Password')";
                    cmd.ExecuteNonQuery();
                }

                // Create a default auditor
                cmd.CommandText = "SELECT * FROM tblAuditor WHERE Username = 'Auditor'";
                if (cmd.ExecuteScalar() == null)
                {
                    cmd.CommandText = "INSERT INTO tblAuditor VALUES ('Auditor', 'Password')";
                    cmd.ExecuteNonQuery();
                }


                cmd.CommandText = "CREATE TABLE IF NOT EXISTS tblVoteOptions(Name VARCHAR(50) NOT NULL UNIQUE, Description VARCHAR(50), Count INT NOT NULL)";
                cmd.ExecuteNonQuery();

                conn.Close();
            }
        }

        public static void AddVoter(string username, string password) // Add a new voter to the database
        {
            using (SQLiteConnection conn = GetDatabaseConnection())
            {
                conn.Open();
                SQLiteCommand cmd = conn.CreateCommand();

                try
                {
                    cmd.CommandText = $"INSERT INTO tblVoter VALUES ('{username}', '{password}', FALSE)";
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                { }

                conn.Close();
            }
        }

        public static Voter GetVoter(string username) // Get a specific voter from the database
        {
            Voter voter = null;
            using (SQLiteConnection conn = GetDatabaseConnection())
            {
                conn.Open();
                SQLiteCommand cmd = conn.CreateCommand();

                cmd.CommandText = $"SELECT * FROM tblVoter WHERE Username = '{username}'";
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    voter = new Voter(reader.GetString(0), reader.GetString(1));
                    voter.hasVoted = reader.GetBoolean(2);
                    break;
                }
                reader.Close();

                conn.Close();
            }

            return voter;
        }

        public static void SetVoterVoted(Voter voter) // Set a voter's HasVoted to true
        {
            using (SQLiteConnection conn = GetDatabaseConnection())
            {
                conn.Close();
                conn.Open();
                SQLiteCommand cmd = conn.CreateCommand();

                try
                {
                    cmd.CommandText = $"UPDATE tblVoter SET HasVoted = TRUE WHERE Username = '{voter.name}'";
                    cmd.ExecuteNonQuery();
                }
                    catch (Exception ex)
                { }

            conn.Close();
            }
        }

        public static Administrator GetAdmin(string username) // Get a specific admin from the database
        {
            Administrator administrator = null;
            using (SQLiteConnection conn = GetDatabaseConnection())
            {
                conn.Open();
                SQLiteCommand cmd = conn.CreateCommand();

                cmd.CommandText = $"SELECT * FROM tblAdmin WHERE Username = '{username}'";
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    administrator = new Administrator(reader.GetString(0), reader.GetString(1));
                    break;
                }
                reader.Close();

                conn.Close();
            }

            return administrator;
        }

        public static Auditor GetAuditor(string username) // Get a specific auditor from the database
        {
            Auditor auditor = null;
            using (SQLiteConnection conn = GetDatabaseConnection())
            {
                conn.Open();
                SQLiteCommand cmd = conn.CreateCommand();

                cmd.CommandText = $"SELECT * FROM tblAuditor WHERE Username = '{username}'";
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    auditor = new Auditor(reader.GetString(0), reader.GetString(1));
                    break;
                }
                reader.Close();

                conn.Close();
            }

            return auditor;
        }

        public static void AddVoteOption(string name, string description) // Add a vote option to the database
        {
            using (SQLiteConnection conn = GetDatabaseConnection())
            {
                conn.Open();
                SQLiteCommand cmd = conn.CreateCommand();

                try
                {
                    cmd.CommandText = $"INSERT INTO tblVoteOptions VALUES ('{name}', '{description}', 0)";
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                { }

                conn.Close();
            }
        }

        public static VoteOption GetVoteOption(string name) // Get a specific vote option from the database
        {
            VoteOption voteOption = null;
            using (SQLiteConnection conn = GetDatabaseConnection())
            {
                conn.Open();
                SQLiteCommand cmd = conn.CreateCommand();

                cmd.CommandText = $"SELECT * FROM tblVoteOptions WHERE Name = '{name}'";
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    voteOption = new VoteOption(reader.GetString(0), reader.GetString(1));
                    voteOption.count = reader.GetInt32(2);
                    break;
                }
                reader.Close();

                conn.Close();
            }

            return voteOption;
        }

        public static IEnumerable<VoteOption> GetVoteOptions() // Get all vote options from the database
        {
            List<VoteOption> voteOptions = new List<VoteOption>();
            using (SQLiteConnection conn = GetDatabaseConnection())
            {
                conn.Open();
                SQLiteCommand cmd = conn.CreateCommand();

                cmd.CommandText = $"SELECT * FROM tblVoteOptions";
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    VoteOption voteOption = new VoteOption(reader.GetString(0), reader.GetString(1));
                    voteOption.count = reader.GetInt32(2);
                    voteOptions.Add(voteOption);
                }
                reader.Close();

                conn.Close();
            }

            return voteOptions;
        }

        public static void UpdateVoteOptionCount(string name, int count) // Update the count on a vote option in the database
        {
            using (SQLiteConnection conn = GetDatabaseConnection())
            {
                conn.Close();
                conn.Open();
                SQLiteCommand cmd = conn.CreateCommand();

                try
                {
                    cmd.CommandText = $"UPDATE tblVoteOptions SET Count = {count} WHERE Name = '{name}'";
                    cmd.ExecuteNonQuery();
                }
                    catch (Exception ex)
                { }

            conn.Close();
            }
        }
    }
}
