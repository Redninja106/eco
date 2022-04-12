using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco.People.Behaviors;

internal class IdleBehavior : Behavior
{
    public override string ToString()
    {
        return "Idle...";
    }

    public override void Act(Person person)
    {
        Console.WriteLine(person.ToString() + " is idle...");
    }
}
