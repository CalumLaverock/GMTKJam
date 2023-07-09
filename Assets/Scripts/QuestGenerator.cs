using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Quest
{
    public int level;
    public string enemy;
    public string questType;
}

public static class QuestGenerator
{
    public static Quest CreateQuest()
    {
        Quest newQuest = new Quest();

        newQuest.level = Random.Range(1, 21);
        newQuest.enemy = Classes.enemies[Random.Range(0, 15)];
        newQuest.questType = Classes.questTypes[Random.Range(0, 9)];

        return newQuest;
    }
}
