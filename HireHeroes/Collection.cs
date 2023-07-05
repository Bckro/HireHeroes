using System.Collections.Generic;
using System;

internal class Collection : Hero
{
    public List<Assistant> assistantList = new List<Assistant>();
    public List<Hero> heroList = new List<Hero>();

    public void Display()
    {
        Console.WriteLine();
        Console.WriteLine("Available assistants:");
        foreach (var person in assistantList)
        {
            Console.WriteLine("Assistant: " + person.name + " (" + person.level + "lvl)");
        }

        Console.WriteLine();
        Console.WriteLine("Available heroes:");
        foreach (var person in heroList)
        {
            if (person.available)
            {
                Console.WriteLine("Hero: " + person.profession + " " + person.name + " (" + person.level + "lvl)");
            }
        }
    }

    public void RentHero()
    {
        Console.WriteLine();
        Console.WriteLine("Which hero would you like to rent?");
        Console.WriteLine("Available heroes are: ");
        int i = 0;
        int j;
        List<Hero> AvailableHeroes = new List<Hero>();
        foreach (var hero in heroList)
        {
            if (hero.available)
            {
                i++;
                Console.WriteLine(i + ". " + hero.profession + " " + hero.name + " " + hero.level + "lvl");
                AvailableHeroes.Add(hero);
            }
        }
        if (AvailableHeroes.Count == 0)
        {
            Console.WriteLine("No available heroes.");
            return;
        }

        j = int.Parse(Console.ReadLine());

        if (j < 1 || j > AvailableHeroes.Count)
        {
            Console.WriteLine("Invalid hero number. Returning to menu...");
            return;
        }

        AvailableHeroes[j - 1].available = false;
        Console.WriteLine("Thank you! The hero will join your team soon.");
    }

    public void ReleaseHero()
    {
        Console.WriteLine();
        Console.WriteLine("Which hero would you like to release?");
        int i = 0;
        int j;
        List<Hero> UnavailableHeroes = new List<Hero>();
        foreach (var hero in heroList)
        {
            if (!hero.available)
            {
                i++;
                Console.WriteLine(i + ". " + hero.profession + " " + hero.name + " " + hero.level + "lvl");
                UnavailableHeroes.Add(hero);
            }
        }

        if (UnavailableHeroes.Count == 0)
        {
            Console.WriteLine("No unavailable heroes.");
            return;
        }

        j = int.Parse(Console.ReadLine());

        if (j < 1 || j > UnavailableHeroes.Count)
        {
            Console.WriteLine("Invalid hero number. Returning to menu...");
            return;
        }

        UnavailableHeroes[j - 1].available = true;
        Console.WriteLine("The hero has been released and is now available again.");
    }
}