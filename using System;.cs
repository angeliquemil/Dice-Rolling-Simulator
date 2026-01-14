using System;

namespace DiceRollingSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the dice throwing simulator!");

            // Ask user how many times to roll the dice
            Console.Write("How many dice rolls would you like to simulate? ");
            int totalRolls;
            while (!int.TryParse(Console.ReadLine(), out totalRolls) || totalRolls <= 0)
            {
                Console.Write("Please enter a positive integer: ");
            }

            // Create an instance of DiceSimulator
            DiceSimulator simulator = new DiceSimulator();

            // Get results from simulator
            int[] rollResults = simulator.RollDice(totalRolls);

            // Print histogram
            Console.WriteLine("\nDICE ROLLING SIMULATION RESULTS");
            Console.WriteLine("Each \"*\" represents 1% of the total number of rolls.");
            Console.WriteLine($"Total number of rolls = {totalRolls}.");

            for (int sum = 2; sum <= 12; sum++)
            {
                // Calculate percentage of total rolls
                double percentage = ((double)rollResults[sum] / totalRolls) * 100;
                int stars = (int)Math.Round(percentage); // Round to nearest whole number

                Console.Write($"{sum}: ");
                for (int i = 0; i < stars; i++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }

            Console.WriteLine("\nThank you for using the dice throwing simulator. Goodbye!");
        }
    }

    class DiceSimulator
    {
        private Random random;

        public DiceSimulator()
        {
            random = new Random();
        }

        // Method to simulate dice rolls
        public int[] RollDice(int numberOfRolls)
        {
            int[] results = new int[13]; // Index 0 and 1 will not be used (we use 2-12)

            for (int i = 0; i < numberOfRolls; i++)
            {
                int die1 = random.Next(1, 7); // Random number between 1-6
                int die2 = random.Next(1, 7); // Random number between 1-6
                int sum = die1 + die2;
                results[sum]++;
            }

            return results;
        }
    }
}

