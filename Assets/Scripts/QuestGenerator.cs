using System.Collections;
using System.Collections.Generic;
using UnityEngine;

struct Quest
{
    public string enemy;
    public string questType;
}

public class QuestGenerator : MonoBehaviour
{
    public Classes classes;

    Quest CreateQuest()
    {
        Quest newQuest = new Quest();

        newQuest.enemy = classes.enemies[Random.Range(0, 14)];
        newQuest.questType = classes.questTypes[Random.Range(0, 8)];

        return newQuest;
    }
}
