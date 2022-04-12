using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco.People.Behaviors;
internal class HungryBehavior : Behavior
{
    public override string ToString()
    {
        return "Getting food!";
    }

    public override void Act(Person person)
    {
        Console.WriteLine(person.ToString() + " is eating...");
        person.Hunger.Change(1f);
    }
}
