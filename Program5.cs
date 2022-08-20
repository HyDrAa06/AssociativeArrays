using System;
using System.Data;

namespace Courses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            string[] command;

            var data = new Dictionary<string, List<string>>();

            while (true)
            {
                Console.WriteLine("Command:");
                command = Console.ReadLine().Split(" : ").ToArray();
                string course = command[0];
                if(course == "end")
                {
                    break;
                }

                string name = command[1];

                if (!data.ContainsKey(course))
                {
                    data.Add(course, new List<string>());
                    data[course].Add(name);

                }

                if (data.ContainsKey(course))
                {
                    if (data[course].Contains(name) == false)
                    {
                        data[course].Add(name);
                    }
                }

            }

            foreach(var d in data)
            {
                Console.WriteLine($"{d.Key}: {d.Value.Count}");
                for(int i = 0; i < d.Value.Count; i++)
                {
                    Console.WriteLine($"-- {d.Value[i]}");
                }
            }
        }
    }
}
