using Eco;

class Program
{
    private static void Main()
    {
        var world = new World();
        world.people.Add(new Eco.People.Person(world));

        while (Console.ReadLine().ToUpper() != "STOP")
        {
            world.Step();
            world.Think();
            world.Act();
        }
    }
}