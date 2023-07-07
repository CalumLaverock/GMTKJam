using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct HeroClass
{
    public string name;
    public string group;
    public Dictionary<string, int> enemyStrengths;
    public Dictionary<string, int> questStrengths;
}

public class Classes : MonoBehaviour
{
    public List<HeroClass> classes = new List<HeroClass>();

    public string[] names = {
        "Mage",
        "Shaman",
        "Priest",
        "Barbarian",
        "Paladin",
        "Druid",
        "Rogue",
        "Knight",
        "Ranger"
    };

    public string[] enemies = {
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

    public string[] questTypes = {
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

    void Start()
    {
        string[] groups = {
            "Magic",
            "Brawler",
            "Damage"
        };

        string[] enemyStrengths = {
            "132131232122331",
            "321321113233221",
            "213211233321123",
            "121133322112332",
            "312322132113213",
            "123132311223312",
            "332213223311121",
            "211323111232233",
            "233212321331112"
        };

        string[] questStrengths = {
            "312133221",
            "231321312",
            "123212133"
        };

        for (int i = 0; i < 9; i++)
        {
            HeroClass hero = new HeroClass();
            hero.name = names[i];
            hero.group = groups[i / 3];

            hero.enemyStrengths = new Dictionary<string, int> { };
            hero.questStrengths = new Dictionary<string, int> { };

            for (int j = 0; j < 15; j++)
                hero.enemyStrengths[enemies[j]] = enemyStrengths[i][j] - '0';

            for (int j = 0; j < 9; j++)
                hero.questStrengths[questTypes[j]] = questStrengths[i / 3][j];

            classes.Add(hero);
        }
    }
}
