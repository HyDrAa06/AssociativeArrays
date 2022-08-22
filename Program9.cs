using System;

namespace SnowWhite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input;

            var dwarfs = new Dictionary<string, Dictionary<string, int>>();

            while (true)
            {
                input = Console.ReadLine().Split(" <:> ").ToArray();
                if (input[0]=="Once upon a time")
                {
                    break;
                }

                string name = input[0];
                string hat = input[1];
                int physics = int.Parse(input[2]);

                if (!dwarfs.ContainsKey(name))
                {
                    dwarfs.Add(name, new Dictionary<string, int>());
                    dwarfs[name].Add(hat, physics);
                }
                if (dwarfs.ContainsKey(name))
                {
                    if (!dwarfs[name].ContainsKey(hat))
                    {
                        dwarfs[name].Add(hat, physics);
                    }
                    if (dwarfs[name].ContainsKey(hat))
                    {
                        if (dwarfs[name][hat] < physics)
                        {
                            dwarfs[name][hat] = physics;
                        }
                        
                    }

                }

            }

            // командите на следващия ред ги видях в интернет
            foreach(var dwarf in dwarfs.OrderByDescending(x => x.Value.Values.Max()).ThenByDescending(x => x.Value.Count()))
            {
                var sorted = dwarf.Value;
                foreach (var c in sorted)
                {
                    Console.WriteLine($"({c.Key}) {dwarf.Key} <-> {c.Value}");
                }
            }
        }
    }
}