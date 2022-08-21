using System;
using System.Windows.Markup;

namespace Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] contestDataInput;
            var contestData = new Dictionary<string, string>(); 

            while (true)
            {
                Console.WriteLine("Contest and password");
                contestDataInput=Console.ReadLine().Split(":").ToArray();

                string contestName = contestDataInput[0];
                if(contestName == "end of contests")
                {
                    break;
                }

                string contestPassword = contestDataInput[1];

                if (!contestData.ContainsKey(contestName))
                {
                    contestData.Add(contestName, contestPassword);
                }

            }

            string[] playerInputData;
            var playerData = new Dictionary<string,Dictionary<string, int>>();


            while (true)
            {
                Console.WriteLine("Player data:");
                playerInputData = Console.ReadLine().Split("=>").ToArray();

                string contestNameCheck = playerInputData[0];
                if (contestNameCheck == "end of submissions")
                {
                    break;
                }

                string contestPasswordCheck = playerInputData[1];
                string username = playerInputData[2];
                int points = int.Parse(playerInputData[3]);

                if (!contestData.ContainsKey(contestNameCheck))
                {
                    continue;
                }
                if (contestData[contestNameCheck] == contestPasswordCheck)
                {
                    if (!playerData.ContainsKey(username))
                    {
                        playerData.Add(username, new Dictionary<string, int>());
                        playerData[username].Add(contestNameCheck, points);
                    }

                    if (!playerData[username].ContainsKey(contestNameCheck))
                    {
                        playerData[username].Add(contestNameCheck, points);
                    }

                    if (playerData[username][contestNameCheck] < points)
                    {
                        playerData[username][contestNameCheck] = points;
                    }
                }

            }

            var playerTotalPoints = new Dictionary<string, int>();

            foreach(var k in playerData)
            {
                playerTotalPoints[k.Key] =k.Value.Values.Sum();
            }

            var bestPlayer= new Dictionary<string, int>();

            bestPlayer.Add(playerTotalPoints.Keys.Max(), playerTotalPoints.Values.Max());
            
            foreach(var b in bestPlayer)
            {
                Console.WriteLine($"Best candidate is {b.Key} with total {b.Value} points.");
            }

            
            Console.WriteLine("Ranking:");

            foreach(var k in playerData)
            {
                Console.WriteLine(k.Key);
                foreach (var b in playerData[k.Key])
                {
                    Console.WriteLine($"#  {b.Key} -> {playerData[k.Key][b.Key]}");
                }
            }
        }
    }
}