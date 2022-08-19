using System;

namespace Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Order:");

            string[] order;
            string name;
            double price;
            double quantity;

            var finalOrder = new Dictionary<string, double>();
            var tempPrice = new Dictionary<string, double>();
            var tempQuantity = new Dictionary<string, double>();

            while (true)
            {
                order = Console.ReadLine().Split(" ").ToArray();

                if (order[0] == "buy")
                {
                    break;
                }


                name = order[0];
                price = double.Parse(order[1]);
                quantity = double.Parse(order[2]);
                double finalPrice;             

                
                if (finalOrder.ContainsKey(name))
                {
                    
                    if(price != tempPrice[name])
                    {                        
                        quantity = quantity+ tempQuantity[name];
                        finalPrice = price * quantity;
                        finalOrder[name] = finalPrice;
                    }
                    if(price == tempPrice[name])
                    {
                        quantity = quantity + tempQuantity[name];
                        finalPrice = price * quantity;
                        finalOrder[name] = finalPrice;
                    }
                }

                else
                {
                    tempPrice.Add(name, price);
                    tempQuantity.Add(name, quantity);

                    finalPrice = price * quantity;
                    finalOrder.Add(name, finalPrice);
                }                
            }

            foreach(var o in finalOrder)
            {
                Console.WriteLine($"{o.Key} --> {String.Format("{0:0.00}", o.Value)}");
            }
        }
    }
}