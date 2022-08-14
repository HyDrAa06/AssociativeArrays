using System;

namespace AMinerTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var array = new Dictionary<string, int>();

            while (true) 
            {
                Console.WriteLine("Material and amount:");
                string material = Console.ReadLine();
                if (material == "stop")
                {
                    break;
                }
                int value = int.Parse(Console.ReadLine());
                if (array.ContainsKey(material))
                {
                    array[material] +=value;
                }
                else
                {
                    array.Add(material, value);
                }          
            }

            foreach(var item in array)
            {
                Console.WriteLine($"{item.Key} --> {item.Value}");
            }

        }
    }
}