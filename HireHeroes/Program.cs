using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace RentHeroes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Creating instance of the collection
            Collection c1 = new Collection();

            // Adding sample heroes and assistants to the collection
            c1.assistantList.Add(new Assistant()
            {
                name = "Beel",
                level = 10,
                available = true
            });
            c1.heroList.Add(new Hero()
            {
                name = "Zelda",
                level = 25,
                profession = "Warrior",
                available = true
            });
            c1.heroList.Add(new Hero()
            {
                name = "Sophie",
                level = 20,
                profession = "Wizard",
                available = true
            });
            c1.heroList.Add(new Hero()
            {
                name = "Enanniel",
                level = 30,
                profession = "Ranger",
                available = true
            });
            c1.heroList.Add(new Hero()
            {
                name = "Ophelia",
                level = 15,
                profession = "Cleric",
                available = true
            });

            do
            {
                Console.WriteLine();
                Console.WriteLine("1. Save a hero or assistant to the collection");
                Console.WriteLine("2. Display available heroes and assistants");
                Console.WriteLine("3. Rent a hero");
                Console.WriteLine("4. Release a hero");
                Console.WriteLine("5. Exit");
                Console.WriteLine();

                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("No valid option entered. Returning to menu...");
                    continue;
                }

                if (!int.TryParse(input, out int choice))
                {
                    Console.WriteLine("No valid option entered. Returning to menu...");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Do you want to save an assistant or a hero?");
                        Console.WriteLine("1 - Assistant\t2 - Hero");
                        string option = Console.ReadLine();

                        if (string.IsNullOrEmpty(option))
                        {
                            Console.WriteLine("No valid option entered. Returning to menu...");
                            break;
                        }

                        if (!int.TryParse(option, out int assistantOrHero))
                        {
                            Console.WriteLine("No valid option entered. Returning to menu...");
                            break;
                        }

                        if (assistantOrHero == 1)
                        {
                            Console.WriteLine("Enter the name and level of the assistant:");
                            string name = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(name))
                            {
                                Console.WriteLine("No name entered. Returning to menu...");
                                break;
                            }

                            int level;
                            if (!int.TryParse(Console.ReadLine(), out level))
                            {
                                Console.WriteLine("No valid level entered. Returning to menu...");
                                break;
                            }

                            c1.assistantList.Add(new Assistant()
                            {
                                name = name,
                                level = level,
                                available = true
                            });

                            Console.WriteLine("Assistant has been saved to the collection.");
                        }
                        else if (assistantOrHero == 2)
                        {
                            Console.WriteLine("Enter the name, level, profession, and availability of the hero:");
                            string name = Console.ReadLine();
                            string levelString = Console.ReadLine();
                            string profession = Console.ReadLine();
                            string availabilityString = Console.ReadLine();

                            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(levelString) || string.IsNullOrWhiteSpace(profession) || string.IsNullOrWhiteSpace(availabilityString))
                            {
                                Console.WriteLine("No valid data entered. Returning to menu...");
                                break;
                            }

                            if (!int.TryParse(levelString, out int level) || !bool.TryParse(availabilityString, out bool availability))
                            {
                                Console.WriteLine("No valid data entered. Returning to menu...");
                                break;
                            }

                            c1.heroList.Add(new Hero()
                            {
                                name = name,
                                level = level,
                                profession = profession,
                                available = availability
                            });

                            Console.WriteLine("Hero has been saved to the collection.");
                        }
                        else
                        {
                            Console.WriteLine("No valid option entered. Returning to menu...");
                        }
                        break;

                    case 2:
                        c1.Display();
                        break;

                    case 3:
                        c1.RentHero();
                        break;

                    case 4:
                        c1.ReleaseHero();
                        break;

                    case 5:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("No valid option entered. Returning to menu...");
                        break;
                }

            } while (true);
        }
    }
}