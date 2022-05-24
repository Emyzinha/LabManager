using Microsoft.Data.Sqlite;

namespace LabManager.Database;

class DatabaseSetup
{
    private DatabaseConfig databaseConfig;

    public DatabaseSetup(DatabaseConfig databaseConfig)
    {
        this.databaseConfig = databaseConfig;
        CreateCommputerTable();
    }

    public void CreateCommputerTable()
    {
        var conection = new SqliteConnection(databaseConfig.ConnectionString);

        conection.Open();

        var command = conection.CreateCommand();
        command.CommandText = @";

        CREATE TABLE IF NOT EXISTS Computers(
            id int not null primary key,
            ram varchar(100) not null,
            processor varchar(100) not null
        );
        ";

        command.ExecuteNonQuery();

        conection.Close();
    }
}