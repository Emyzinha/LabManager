// See https://aka.ms/new-console-template for more information
// dotnet restore
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
            Console.WriteLine($"{computer.Id}, {computer.Ram}, {computer.Processor}");
        }
    }
    
    if(modelAction =="New"){
       
        int id = Convert.ToInt32(args[2]);
        string ram = args [3];
        string processor = args [4];

        var computer = new Computer(id, ram, processor);
        computerRepository.Save(computer);
    }
    
    if(modelAction == "Show")
    {
        var id = Convert.ToInt32(args[2]);

        if(computerRepository.ExitsById(id))
        {
            var computer = computerRepository.GetById(id);
            Console.WriteLine($"{computer.Id}, {computer.Ram}, {computer.Processor}");
        } 
        else 
        {
            Console.WriteLine($"O computador com Id {id} não existe.");
        }
    }
    
    if(modelAction == "Update")
    {
        var id = Convert.ToInt32(args[2]);
        if(computerRepository.ExitsById(id))
        {
            string ram = args[3];
            string processor = args[4];
            var computer = new Computer(id, ram, processor);
            computerRepository.Update(computer);
        }
        else
        {
            Console.WriteLine($"O computador com Id {id} não existe.");
        }
    }

     if(modelAction == "Delete")
    {
        var id = Convert.ToInt32(args[2]);
        if(computerRepository.ExitsById(id))
        {
            computerRepository.Delete(id);
        }
        else
        {
            Console.WriteLine($"O computador com Id {id} não existe.");
        }        
    }
}

