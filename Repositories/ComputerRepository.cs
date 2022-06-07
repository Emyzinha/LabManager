
using LabManager.Database;
using LabManager.Models;
using Microsoft.Data.Sqlite;

namespace LabManager.Repositories;

class ComputerRepository{

    private DatabaseConfig databaseConfig;

    public ComputerRepository(DatabaseConfig databaseConfig)
    {
        this.databaseConfig = databaseConfig;
    }

    public List<Computer>GetAll()
    {
        var conection = new SqliteConnection(databaseConfig.ConnectionString);
        conection.Open();
        var command = conection.CreateCommand();
        command.CommandText = "SELECT * FROM Computers";
       
       var reader = command.ExecuteReader();


       var computers = new List<Computer>();

       while(reader.Read())
       {
         
      var computer = readerToComputer(reader);
      computers.Add(computer);
              
       }

       conection.Close();

       return computers;

    }
    
    public Computer Save (Computer computer)
    {
    var conection = new SqliteConnection(databaseConfig.ConnectionString);
   
    conection.Open();
        

    var command = conection.CreateCommand();
    command.CommandText = "INSERT INTO Computers VALUES($id, $ram, $processor)";
    command.Parameters.AddWithValue( "$id", computer.Id);
    command.Parameters.AddWithValue( "$ram", computer.Ram);
    command.Parameters.AddWithValue( "$processor", computer.Procesador);

    command.ExecuteNonQuery();
    conection.Close();

    return computer;

    }


    public Computer GetById(int id)
    {
   var conection = new SqliteConnection(databaseConfig.ConnectionString);

    conection.Open();    
    var command = conection.CreateCommand();

    command.CommandText = "SELECT * FROM computers WHERE id = $id";
    command.Parameters.AddWithValue("$id", id);

    var reader = command.ExecuteReader();
    reader.Read(); // quer uma linha 

    var computer = new Computer(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));

    conection.Close();
    return computer;
    }

    public Computer Update(Computer computer)
    {
    using var conection = new SqliteConnection(databaseConfig.ConnectionString);

    conection.Open();
    var command = conection.CreateCommand();

    command.CommandText= "UPDATE Computer SET ram = $ram, processsor = $processor WHERE id = %id";
    command.Parameters.AddWithValue( "$id", computer.Id);
    command.Parameters.AddWithValue( "$ram", computer.Ram);
    command.Parameters.AddWithValue( "$processor", computer.Procesador);

    command.ExecuteNonQuery();
    conection.Close();

    return computer;

    }

    void Delete(int id)
    {
   using var conection = new SqliteConnection(databaseConfig.ConnectionString);
    conection.Open();

    var command = conection.CreateCommand();      

    command.CommandText = "DELETE FROM Computers WHERE id = $id";
    command.Parameters.AddWithValue("$id", id);
    command.ExecuteNonQuery();
   
    conection.Close();
    }

    public bool existsById(int id )
    {
        return false;
    }

    private Computer readerToComputer(SqliteDataReader reader)
    {
        return new Computer(
            reader.GetInt32(0),reader.GetString(1), reader.GetString(2)
        );
    }
}
