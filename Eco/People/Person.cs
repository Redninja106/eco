using Eco.Naming;
using Eco.People.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco.People;
internal class Person
{
    private static NameSelector NameSelector;
    private static Random nameRandom;

    public string FirstName { get; private set; }
    public string LastName { get; private set; }

    public Feeling Hunger = new("Hunger", 1);

    private Behavior state = new IdleBehavior();

    private World world;

    public Person(World world)
    {
        NameSelector ??= new(world.RandomSeed);
        this.FirstName = NameSelector.GetRandomName(2004);
        this.world = world;
        Console.WriteLine("New person: " + this.ToString());
    }

    public void Step()
    {
        Hunger.Change(-1f/24f); // 1 full day to starve

        if (this.Hunger.Value == 0)
        {
            this.Kill("starvation");
        }
    }

    public void Act()
    {
        state.Act(this);
    }

    public void Think()
    {   
        // the max hunger level a person to be hungry
        const float hungerLevel = 1f - (5f / 24f);
        
        if (Hunger.Value <= hungerLevel)
        {
            Console.WriteLine(ToString() + " is now hungry...");
            this.state = new HungryBehavior();
        }
        else
        {
            Console.WriteLine(ToString() + " is now idle");
            this.state = new IdleBehavior();
        }
    }

    void Display()
    {
        Console.WriteLine(
$@"{this}:
    Hunger: {Hunger.Value}
    Current Behavior: {state}
");
    }

    void Kill(string source)
    {
        world.people.Remove(this);
        Console.WriteLine(this.ToString() + " was killed by " + source);
    }

    public override string ToString()
    {
        return FirstName + " " + LastName;
    }
}
