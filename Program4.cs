using System;

namespace CompanyUsers
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
                command =Console.ReadLine().Split(" -> ").ToArray();
                string company = command[0];
                if(company == "End")
                {
                    break;
                }

                string id = command[1];

                if (!data.ContainsKey(company))
                {
                    data.Add(company, new List<string>());
                    data[company].Add(id);
                }

                if (data.ContainsKey(company))
                {
                    if (data[company].Contains(id)==false)
                    {
                        data[company].Add(id);
                    }
                }
            }

            foreach(var d in data)
            {
                Console.WriteLine($"{d.Key}");
                for (int i = 0; i < d.Value.Count; i++)
                {
                    Console.WriteLine($"-- {d.Value[i]}");
                }
            }
        }
    }
}