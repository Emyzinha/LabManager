// See https://aka.ms/new-console-template for more information
using Microsoft.Data.Sqlite;
using LabManager.Database;
using LabManager.Repositories;
using LabManager.Models;

var databaseConfig = new DatabaseConfig();
new DatabaseSetup(databaseConfig);

var computerRepository = new ComputerRepository(databaseConfig);

//Routing - rotiamente 

var modelName = args[0];
var modelAction = args[1];

if(modelName =="Computer"){
    if(modelAction == "List"){

        Console.WriteLine("computer list");
        foreach(var computer in computerRepository.GetAll())
        {
            Console.WriteLine("{0}, {1}, {2}", computer.Id, computer.Ram, computer.Procesador );
        }
    }
    if(modelAction =="New"){
      
        Console.WriteLine("New computer");
        int id = Convert.ToInt32(args[2]);
        string ram = args [3];
        string processor = args [4];


        var computer = new Computer(id, ram, processor);
        computerRepository.Save(computer);

       



    }
}

