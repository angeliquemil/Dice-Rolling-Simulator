using System;

namespace DiceRollingSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the dice throwing simulator!");

            Console.Write("How many dice rolls would you like to simulate? ");
            int totalRolls;
            while (!int.TryParse(Console.ReadLine(), out totalRolls) || totalRolls <= 0)
            {
                Console.Write("Please enter a positive integer: ");
            }

            DiceSimulator simulator = new DiceSimulator();
            int[] rollResults = simulator.RollDice(totalRolls);

            Console.WriteLine("\nDICE ROLLING SIMULATION RESULTS");
            Console.WriteLine("Each \"*\" represents 1% of the total number of rolls.");
            Console.WriteLine($"Total number of rolls = {totalRolls}.");

            for (int sum = 2; sum <= 12; sum++)
            {
                double percentage = ((double)rollResults[sum] / totalRolls) * 100;
                int stars = (int)Math.Round(percentage);

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

        public int[] RollDice(int numberOfRolls)
        {
            int[] results = new int[13]; // Index 0 and 1 not used

            for (int i = 0; i < numberOfRolls; i++)
            {
                int die1 = random.Next(1, 7);
                int die2 = random.Next(1, 7);
                results[die1 + die2]++;
            }

            return results;
        }
    }
}
