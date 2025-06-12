
using System;

using System.Collections.Generic;
using System.Linq;

namespace DictionaryExample
{
    class Program
    {
        static Dictionary<string, List<string>> natureDictionary = new Dictionary<string, List<string>>();

        static void Main(string[] args)
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n--- Nature Dictionary Menu ---");
                Console.WriteLine("a - Populate the Dictionary");
                Console.WriteLine("b - Display Dictionary Contents");
                Console.WriteLine("c - Remove a Key");
                Console.WriteLine("d - Add a New Key and Value");
                Console.WriteLine("e - Add a Value to an Existing Key");
                Console.WriteLine("f - Sort the Keys");
                Console.WriteLine("x - Exit");
                Console.Write("Select an option: ");
                string choice = Console.ReadLine().ToLower();

                switch (choice)
                {
                    case "a":
                        PopulateDictionary();
                        break;
                    case "b":
                        DisplayDictionary();
                        break;
                    case "c":
                        RemoveKey();
                        break;
                    case "d":
                        AddNewKeyValue();
                        break;
                    case "e":
                        AddValueToExistingKey();
                        break;
                    case "f":
                        SortKeys();
                        break;
                    case "x":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }
            }
        }

        static void PopulateDictionary()
        {
            natureDictionary.Clear();
            natureDictionary.Add("Forest", new List<string> { "Trees", "Wildlife", "Moss" });
            natureDictionary.Add("Ocean", new List<string> { "Waves", "Coral", "Fish" });
            natureDictionary.Add("Mountain", new List<string> { "Rocks", "Snow", "Eagles" });
            Console.WriteLine("Dictionary populated with nature-themed entries.");
        }

        static void DisplayDictionary()
        {
            if (natureDictionary.Count == 0)
            {
                Console.WriteLine("Dictionary is empty.");
                return;
            }

            Console.WriteLine("\nCurrent contents of the dictionary:");
            foreach (var kvp in natureDictionary)
            {
                Console.WriteLine($"Key: {kvp.Key} -> Values: {string.Join(", ", kvp.Value)}");
            }
        }

        static void RemoveKey()
        {
            Console.Write("Enter the key you want to remove: ");
            string key = Console.ReadLine();

            if (natureDictionary.Remove(key))
            {
                Console.WriteLine($"Key '{key}' removed successfully.");
            }
            else
            {
                Console.WriteLine($"Key '{key}' not found.");
            }
        }

        static void AddNewKeyValue()
        {
            Console.Write("Enter the new key to add: ");
            string key = Console.ReadLine();

            if (natureDictionary.ContainsKey(key))
            {
                Console.WriteLine("Key already exists. Use option 'e' to add values.");
                return;
            }

            Console.Write("Enter the value for this key: ");
            string value = Console.ReadLine();

            natureDictionary.Add(key, new List<string> { value });
            Console.WriteLine($"Added key '{key}' with value '{value}'.");
        }

        static void AddValueToExistingKey()
        {
            Console.Write("Enter the key to add a value to: ");
            string key = Console.ReadLine();

            if (!natureDictionary.ContainsKey(key))
            {
                Console.WriteLine("Key does not exist. Use option 'd' to add new key.");
                return;
            }

            Console.Write("Enter the value to add: ");
            string value = Console.ReadLine();

            natureDictionary[key].Add(value);
            Console.WriteLine($"Added value '{value}' to key '{key}'.");
        }

        static void SortKeys()
        {
            if (natureDictionary.Count == 0)
            {
                Console.WriteLine("Dictionary is empty, nothing to sort.");
                return;
            }

            var sortedKeys = natureDictionary.Keys.OrderBy(k => k).ToList();

            Console.WriteLine("Sorted Keys:");
            foreach (var key in sortedKeys)
            {
                Console.WriteLine(key);
            }
        }
    }
}
