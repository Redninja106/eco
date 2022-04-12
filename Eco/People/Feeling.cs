using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco.People;
internal class Feeling
{
    public string Name { get; }
    public float Value { get; private set; } // 0-1

    public Feeling(string name, float value)
    {
        this.Name = name;
        this.Change(value);
    }

    public void Change(float change)
    {
        Value += change;

        Value = Math.Clamp(Value, 0, 1);
    }
}