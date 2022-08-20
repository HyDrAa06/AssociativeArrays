using System;

namespace SoftUniParking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Numver of commands: ");
            int n=int.Parse(Console.ReadLine());

            var checks = new Dictionary<string, string>();

            for(int i=0; i<n; i++)
            {
                Console.WriteLine("Command:");
                string[] command = Console.ReadLine().Split(" ").ToArray();

                string name = command[1];
                

                if (command[0] == "register")
                {
                    string data = command[2];
                    if (checks.ContainsKey(name))
                    {
                        Console.WriteLine("ERROR: already registered with plate number {0}", checks[name]);
                    }

                    else 
                    {
                        checks.Add(name, data);
                        Console.WriteLine("{0} registered {1} successfully", name, data);
                    }
                }

                if (command[0] == "unregister")
                {
                    if (checks.ContainsKey(name))
                    {
                        Console.WriteLine("{0} unregistered successfully", name);
                        checks.Remove(name);
                    }

                    else
                    {
                        Console.WriteLine("ERROR: user {0} not found", name);
                    }
                }

            }

            foreach(var check in checks)
            {
                Console.WriteLine($"{check.Key} => {check.Value}");
            }
        }
    }
}