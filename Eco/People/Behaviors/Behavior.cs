using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco.People.Behaviors;

internal abstract class Behavior
{
    public abstract void Act(Person person);
}
