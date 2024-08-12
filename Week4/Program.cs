using System;

namespace SydneyCoffee
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 2;
            string[] names = new string[n];
            int[] quantities = new int[n];
            string[] resellers = new string[n];
            double[] charges = new double[n];

            WelcomeMessage();

            for (int i = 0; i < n; i++)
            {
                names[i] = GetCustomerName();
                quantities[i] = GetQuantity();
                double price = CalculatePrice(quantities[i]);
                resellers[i] = GetResellerStatus();
                charges[i] = CalculateCharge(price, resellers[i]);
                DisplaySalesValue(names[i], charges[i]);
            }

            DisplaySummary(names, quantities, resellers, charges);
        }

        static void WelcomeMessage()
        {
            Console.WriteLine("\t\t\t\tWelcome to use Sydney Coffee Program\n");
        }

        static string GetCustomerName()
        {
            Console.Write("Enter customer name: ");
            return Console.ReadLine();
        }

        static int GetQuantity()
        {
            int quantity;
            do
            {
                Console.Write("Enter the number of coffee beans bags (bag/1kg): ");
                quantity = Convert.ToInt32(Console.ReadLine());

                if (quantity < 1 || quantity > 200)
                {
                    Console.WriteLine("Invalid Input!\nCoffee bags between 1 and 200 can be ordered.");
                }
            } while (quantity < 1 || quantity > 200);

            return quantity;
        }

        static double CalculatePrice(int quantity)
        {
            if (quantity <= 5)
                return 36 * quantity;
            else if (quantity <= 15)
                return 34.5 * quantity;
            else
                return 32.7 * quantity;
        }

        static string GetResellerStatus()
        {
            Console.Write("Enter yes/no to indicate whether you are a reseller: ");
            return Console.ReadLine();
        }

        static double CalculateCharge(double price, string reseller)
        {
            return reseller == "yes" ? price * 0.8 : price;
        }

        static void DisplaySalesValue(string name, double charge)
        {
            Console.WriteLine(String.Format("The total sales value from {0} is ${1}", name, charge));
            Console.WriteLine("-----------------------------------------------------------------------------");
        }

        static void DisplaySummary(string[] names, int[] quantities, string[] resellers, double[] charges)
        {
            double min = double.MaxValue, max = double.MinValue;
            string minName = "", maxName = "";

            Console.WriteLine("\t\t\t\t\tSummary of sales\n");
            Console.WriteLine("-----------------------------------------------------------------------------");
            Console.WriteLine(String.Format("{0,15}{1,10}{2,10}{3,10}", "Name", "Quantity", "Reseller", "Charge"));

            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine(String.Format("{0,15}{1,10}{2,10}{3,10}", names[i], quantities[i], resellers[i], charges[i]));

                if (charges[i] < min)
                {
                    min = charges[i];
                    minName = names[i];
                }

                if (charges[i] > max)
                {
                    max = charges[i];
                    maxName = names[i];
                }
            }

            Console.WriteLine("-----------------------------------------------------------------------------");
            Console.WriteLine(String.Format("The customer spending most is {0} ${1}", maxName, max));
            Console.WriteLine(String.Format("The customer spending least is {0} ${1}", minName, min));
        }
    }
}
