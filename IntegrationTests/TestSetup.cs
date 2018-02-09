using System;
using System.Collections.Generic;
using NUnit.Framework;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using Company.Data.Migrations;
using System.Data.Entity;
using Company.Data;

namespace IntegrationTests
{
    [SetUpFixture]
    public class TestSetup
    {
        private const string DBNAME = "CompanyDB";
        private static string _fileName;
        private static string _masterDBConnectionStr;

        [OneTimeSetUp]
        public static void SetupDatabase()
        {
            DropDatabase();
            CreateDatabase();
        }

        private static void CreateDatabase()
        {
            ExecuteSQLCommand(
                            MasterDBConnectionStr,
                            $"CREATE DATABASE [{DBNAME}] ON (NAME='{DBNAME}', FILENAME='{FileName}')");

            var migration = new MigrateDatabaseToLatestVersion<CompanyDBContext, CompanyDBConfiguration>();
            migration.InitializeDatabase(new CompanyDBContext());
        }

        [OneTimeTearDown]
        public void TeardownDatabase()
        {
            DropDatabase();
        }

        private static void DropDatabase()
        {
            var fileNames = ExecuteSQLQuery(
                            MasterDBConnectionStr,
                            $"SELECT [physical_name] FROM [sys].[master_files] " +
                            $"WHERE [database_id] = DB_ID('{DBNAME}')",
                            reader => (string)reader["physical_name"]);

            if (fileNames.Count > 0)
            {
                ExecuteSQLCommand(MasterDBConnectionStr, $"EXEC sp_detach_db '{DBNAME}'");

                fileNames.ForEach(File.Delete);
            }
        }

        private static void ExecuteSQLCommand(string connectionString, string commandText)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (var command = new SqlCommand(commandText, conn))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        private static List<T> ExecuteSQLQuery<T>(string connectionString, string commandText,
            Func<SqlDataReader, T> read)
        {
            var result = new List<T>();
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (var command = new SqlCommand(commandText, conn))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(read(reader));
                        }
                    }
                }
            }
            return result;
        }

        private static string FileName
        {
            get
            {
                if(String.IsNullOrEmpty(_fileName))
                {
                    _fileName = Path.Combine(
                            Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                            $"{DBNAME}.mdf"
                        );
                }
                return _fileName;
            }
        }

        private static string MasterDBConnectionStr
        {
            get
            {
                if (String.IsNullOrEmpty(_masterDBConnectionStr))
                {
                    var connectionStringBuilder = new SqlConnectionStringBuilder
                    {
                        DataSource = "(LocalDb)\\MSSQLLocalDB",
                        InitialCatalog = "master",
                        IntegratedSecurity = true
                    };
                    _masterDBConnectionStr = connectionStringBuilder.ConnectionString;
                }
                return _masterDBConnectionStr;
            }
        }

    }
}
