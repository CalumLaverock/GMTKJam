using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct HeroClass
{
    public string name;
    public Dictionary<string, int> enemyStrengths;
}

public static class Classes
{
    public static List<HeroClass> classes = new List<HeroClass>();

    public static string[] names = {
        "Mage",
        "Bard",
        "Barbarian",
        "Knight",
        "Ranger"
    };

    public static string[] enemies = {
        "Orcs",
        "Goblins",
        "Giant Spiders",
        "Chimeras",
        "Lizardfolk",
        "Fairies",
        "Dire Wolves",
        "Demons",
        "Angels",
        "Zombies",
        "Slimes",
        "Giant Squids",
        "Elementals",
        "Bandits",
        "Dragons"
    };

    public static string[] questTypes = {
        "Dungeon",
        "Escort",
        "Assassination",
        "Delivery",
        "Exploration",
        "Diplomacy",
        "Defence",
        "Gather",
        "Cull"
    };

    static Classes()
    {
        string[] enemyStrengths = {
            "132131232122331",
            "321321113233221",
            "121133322112332",
            "211323111232233",
            "233212321331112"
        };

        for (int i = 0; i < 5; i++)
        {
            HeroClass hero = new HeroClass();
            hero.name = names[i];

            hero.enemyStrengths = new Dictionary<string, int> { };

            for (int j = 0; j < 15; j++)
                hero.enemyStrengths[enemies[j]] = enemyStrengths[i][j] - '0';

            classes.Add(hero);
        }
    }
}
