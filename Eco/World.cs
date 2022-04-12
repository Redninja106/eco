using Eco.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco;
internal class World
{
    internal List<Person> people = new();

    // used for random events... here so that everything that happens in the world can reoccur given the same seed
    // don't actually store a random here to force induvidual system to make their own. That way the random output
    // of one system doesn't effect another.
    public int RandomSeed;

    public World()
    {
    }

    public void Step()
    {
        people.ForEach(person => person.Step());
    }

    public void Think()
    {
        people.ForEach(person => person.Think());
    }

    public void Act()
    {
        people.ForEach(person => person.Act());
    }
}
