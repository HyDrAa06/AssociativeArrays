using System;
using System.Diagnostics.CodeAnalysis;

namespace CountCharsInString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Word/s:");
            string[] words = Console.ReadLine().Split(" ").ToArray();
            List<char> characters = new List<char>();
            List<char> temp = new List<char>();

            for (int i = 0; i < words.Length; i++)
            {
                for(int j = 0; j < words[i].Length; j++)
                {
                    temp = words[i].ToList();
                    characters.Add(temp[j]);
                }
                
            }

            var count = new Dictionary<char, int>();

            foreach(char c in characters)
            {
                if (count.ContainsKey(c))
                {
                    count[c]++;
                }
                else
                {
                    count[c] = 1;
                }
            }
            foreach(var v in count)
            {
                Console.WriteLine($"{v.Key} ->{v.Value}");
            }
        }
    }
}