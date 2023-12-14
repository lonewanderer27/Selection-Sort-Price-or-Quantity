using System;
using System.Collections.Generic;

namespace Selection_Sort_Price_or_Quantity
{
    internal abstract class Program
    {
        public static void Main(string[] args)
        {
            // Product data arrays
            string[] products = { "Avocado", "Broccoli", "Corn", "Dragon Fruit", "Eggplant", "Fries" };
            int[] prices = { 55, 10, 32, 12, 22, 18 };
            string[] descriptions = { "Lots of Vitamins", "Healthy", "Yellow", "Antioxidants", "A Fruit", "Cheesy" };
            int[] quantities = { 252, 101, 123, 300, 115, 188 };

            while (true)
            {
                // Display original array
                Console.WriteLine("\nOriginal");
                DisplayArray(products, prices, descriptions, quantities);

                // Let the user choose Price or Quantity
                Console.WriteLine("\nCHOOSE [PRICE] OR [QUANTITY]");
                Console.WriteLine("[1] Price");
                Console.WriteLine("[2] Quantity");
                Console.Write("Choose number | ");

                if (int.TryParse(Console.ReadLine(), out var numChoice))
                {
                    // Price or Quantity chosen
                    if (numChoice == 1 || numChoice == 2)
                    {
                        Console.WriteLine("\nCHOOSE [ASCENDING] OR [DESCENDING]");
                        Console.WriteLine("[1] Ascending");
                        Console.WriteLine("[2] Descending");
                        Console.Write("Choose number | ");

                        if (int.TryParse(Console.ReadLine(), out var orderChoice))
                        {
                            // Sort by Price or Quantity based on user's choice
                            if (numChoice == 1)
                            {
                                Console.WriteLine("\nSORTING BY PRICE");
                                SortByCriteria(products, prices, descriptions, quantities, orderChoice, ComparePrice);
                            }
                            else
                            {
                                Console.WriteLine("\nSORTING BY QUANTITY");
                                SortByCriteria(products, quantities, descriptions, prices, orderChoice, CompareQuantity);
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nOPTION INVALID. Closing program.");
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nOPTION INVALID. Closing program.");
                        break;
                    }
                }

                // Prompt the user to continue or quit
                Console.WriteLine("\nDo you want to continue?");
                Console.WriteLine("[1] Continue");
                Console.WriteLine("[2] Quit");
                Console.Write("Choose number | ");

                if (!int.TryParse(Console.ReadLine(), out var continueInput) || continueInput != 2) continue;
                Console.WriteLine("Closing program.");
                break;
            }
        }

        // Sorting by criteria (price or quantity)
        private static void SortByCriteria<T>(string[] products, T[] criteria, string[] descriptions, int[] otherCriteria, int order, Func<T, T, int, bool> comparison)
        {
            var n = criteria.Length;

            // Perform selection sort
            for (var i = 0; i < n - 1; i++)
            {
                for (var j = 0; j < n - i - 1; j++)
                {
                    // Compare and swap based on user's choice
                    if (comparison(criteria[j], criteria[j + 1], order))
                    {
                        Swap(products, j, j + 1);
                        Swap(criteria, j, j + 1);
                        Swap(descriptions, j, j + 1);
                        Swap(otherCriteria, j, j + 1);
                    }
                }
            }

            // Display sorted products
            Console.WriteLine("\nSorted Products:");
            Console.WriteLine("Product | Price | Description | Quantity");
            DisplayArray(products, criteria, descriptions, otherCriteria);
        }

        // Comparison functions
        private static bool ComparePrice(int a, int b, int order) => order == 1 ? a > b : a < b;
        private static bool CompareQuantity(int a, int b, int order) => order == 1 ? a > b : a < b;

        // For swapping
        private static void Swap<T>(IList<T> array, int i, int j)
        {
            (array[i], array[j]) = (array[j], array[i]);
        }

        // Displaying an array of any type
        private static void DisplayArray<T>(IReadOnlyList<string> products, IReadOnlyList<T> criteria, IReadOnlyList<string> descriptions, IReadOnlyList<int> otherCriteria)
        {
            Console.WriteLine("────────────────────────────────────────────────");
            for (var i = 0; i < products.Count; i++)
            {
                Console.WriteLine($"{products[i]} | {criteria[i]} | {descriptions[i]} | {otherCriteria[i]}");
            }
        }
    }
}
