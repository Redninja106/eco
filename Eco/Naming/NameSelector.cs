using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Eco.Naming;

internal class NameSelector
{
    private const int BEGIN_YEAR = 1880;
    private const int END_YEAR = 2020;

    private Random random;
    private (List<(string value, int occurances)> names, int totalOccurances)[] Names;

    public NameSelector(int randomSeed)
    {
        random = new Random(randomSeed);
        Load();
    }

    public string GetRandomName(int year)
    {
        year = Math.Clamp(year, BEGIN_YEAR, END_YEAR);
        year -= BEGIN_YEAR;

        var yearData = Names[year];

        var randomValue = random.Next(0, yearData.totalOccurances);

        for (int i = 0; i < yearData.names.Count; i++)
        {
            if (randomValue < yearData.names[i].occurances)
                return yearData.names[i].value;

            randomValue -= yearData.names[i].occurances;
        }

        throw new Exception();
    }

    private void Load()
    {
        var assembly = Assembly.GetExecutingAssembly();

        Names = new (List<(string, int)>, int)[END_YEAR - BEGIN_YEAR];

        for (int i = 0; i < END_YEAR - BEGIN_YEAR; i++)
        {
            Names[i] = new(new(), 0);
            int totalOccurances = 0;

            var resourceName = $"Eco.Naming.Data.yob{i+BEGIN_YEAR}.txt";
            using var resourceStream = assembly.GetManifestResourceStream(resourceName);

            if (resourceStream is null)
                throw new Exception();
            
            using var reader = new StreamReader(resourceStream);

            while (!reader.EndOfStream)
            {
                // each line is in the format of: [name],[m/f],[occurances]
                var line = reader.ReadLine();
                var parts = line.Split(",");
                var name = parts[0];
                var occurances = int.Parse(parts[2]);
                Names[i].names.Add((name, occurances));
                totalOccurances += occurances;
            }

            Names[i] = (Names[i].names, totalOccurances);
        }
    }
}
