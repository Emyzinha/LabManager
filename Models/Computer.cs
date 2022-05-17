namespace LabManager.Models;

class Computer{
    public int Id { get; set; }
    public string Ram { get; set; }
    public string Procesador { get; set; }

    public Computer(int id, string ram, string procesador)
    {
        Id = id;
        Ram = ram;
        Procesador = procesador;
    }
    

}

