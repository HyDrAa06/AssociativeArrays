using System;

namespace StudentAcademy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Number of commands:");
            int n = int.Parse(Console.ReadLine());

            string name;
            double grade;
            


            var finalGrade = new Dictionary<string, double>();
            var temp = new Dictionary<string, double>();
            var averageGrade = new Dictionary<string, double>();
            

            for(int i = 0; i < n; i++)
            {
                Console.WriteLine("Name:");
                name = Console.ReadLine();

                Console.WriteLine("Grade:");
                grade = double.Parse(Console.ReadLine());

                if (finalGrade.ContainsKey(name))
                {
                    finalGrade[name]= finalGrade[name] + grade;
                    temp[name]++;
                }

                else
                {
                    finalGrade.Add(name, grade);
                    temp.Add(name, 1);
                    averageGrade.Add(name, grade);
                }


            }

            foreach(var m in temp)
            {
                finalGrade[m.Key] = finalGrade[m.Key] / m.Value;
            }

            foreach(var f in finalGrade)
            {
                if (finalGrade[f.Key] >= 4.50)
                {
                    Console.WriteLine($"{f.Key} -> {String.Format("{0:0.00}", f.Value)}");
                }
                
            }
                    
        }
    }
}
