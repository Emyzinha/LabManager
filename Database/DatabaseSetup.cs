using Microsoft.Data.Sqlite;

namespace LabManager.Database;

class DatabaseSetup
{
    private DatabaseConfig databaseConfig;

    public DatabaseSetup(DatabaseConfig databaseConfig)
    {
        this.databaseConfig = databaseConfig;
        CreateCommputerTable();
        CreateLabTable();
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


     public void CreateLabTable()
    {
        var conection = new SqliteConnection(databaseConfig.ConnectionString);

        conection.Open();

        var command = conection.CreateCommand();
        command.CommandText = @";

        CREATE TABLE IF NOT EXISTS Labs(
            id int not null primary key,
            number int not null,
            name varchar(100) not null
            block varchar(100) not null
        );
        ";

        command.ExecuteNonQuery();

        conection.Close();
    }
}