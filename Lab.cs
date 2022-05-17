using Microsoft.Data.Sqlite;


Console.WriteLine(args);

foreach (var arg in args)
{
    Console.WriteLine(arg);
}

var conection = new SqliteConnection("Data Source=database.db");

conection.Open();

var command = conection.CreateCommand();
command.CommandText = @";

CREATE TABLE IF NOT EXISTS Lab(
    id int not null primary key,
    number int not null primary key,
    name varchar(100) not null
    block varchar(100) not null
    );
";

command.ExecuteNonQuery();

conection.Close();

var modelName = args[0];
var modelAction = args[1];

if(modelName == "Lab"){
    if(modelAction == "list")
    conection = new SqliteConnection("Data Source=database.db");
    conection.Open();
        command = conection.CreateCommand();
        command.CommandText = "SELECT *FROM Lab";

        var reader = command.ExecuteReader();

       while(reader.Read())
       {
         
           Console.WriteLine("{0}, {1}, {2}, {3}", reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetString(3));
          
       }

       reader.Close();
       conection.Close();
        
    }


     if(modelAction =="New"){ conection = new SqliteConnection("Data Source=database.db");
        conection.Open();
        
        Console.WriteLine("New Lab");
        int id = Convert.ToInt32(args[2]);
        int number = Convert.ToInt32(args[3]);
        string name = args [4];
        string block =args [5];


    command = conection.CreateCommand();
    command.CommandText = "INSERT INTO Lab VALUES($id, $number, $name, $block)";
    command.Parameters.AddWithValue( "$id", id);
    command.Parameters.AddWithValue( "$number", number);
    command.Parameters.AddWithValue( "$name", nome);
    command.Parameters.AddWithValue( "$block", block);

    command.ExecuteNonQuery();
    conection.Close();
        Console.WriteLine("{0}, {1}, {2}, {4}", id, number, name,block);

    }
}
