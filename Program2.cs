using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
namespace practice7_2
{
    class info
    {
        private double amount;
        private double price;

        public double Amount { get { return amount; } set { amount = value; } }
        public double Price { get { return price * amount; } set { price = value; } }
        public info(double amount, double price)
        {
            this.amount = amount;
            this.price = price;
        }
        public info(double price)
        {
            this.price = price;
        }
    }


    class A
    {
        private Dictionary<string, info> component = new Dictionary<string, info>();
        public A() { }
        public void Price(string path)
        {
            try
            {
                using (var sr = new StreamReader(path))
                {
                    string[] str = sr.ReadToEnd().Split('\n');

                    for (int i = 0; i < str.Length; i++)
                    {
                        string[] temp = str[i].Split(' ');
                        component.Add(temp[0], new info(Convert.ToDouble(temp[1])));
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Menu(string path)
        {
            try
            {
                using (var sr = new StreamReader(path))
                {
                    string[] str = sr.ReadToEnd().Split("\n\n");
                    foreach (var t in str)
                    {
                        string[] temp = t.Split('\n');
                        for (int i = 1; i < temp.Length; i++)
                        {
                            string[] Temp = temp[i].Split(' ');
                            if (component.ContainsKey(Temp[0]))
                            {
                                component[Temp[0]].Amount += Convert.ToDouble(Temp[1]);
                            }


                        }
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Output()
        {
            foreach (var t in component)
            {
                Console.WriteLine(t.Key + " " + t.Value.Amount.ToString() +" " + t.Value.Price.ToString());
            }
        }
    }




    class Program
    {
        static void Main(string[] args)
        {
            A T = new A();
            Console.WriteLine("Enter path to file with price:");
            string path;
            path = Console.ReadLine();
            T.Price(path);
            Console.WriteLine("Enter path to file with menu:");
            path = Console.ReadLine();
            T.Menu(path);
            T.Output();
        }
    }
}

