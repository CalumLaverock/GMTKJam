using System.Collections;
using System.Collections.Generic;
using UnityEngine;

struct Quest
{
    public int level;
    public string enemy;
    public string questType;
}

public class QuestGenerator : MonoBehaviour
{
    public Classes classes;

    Quest CreateQuest()
    {
        Quest newQuest = new Quest();

        newQuest.level = Random.Range(1, 100);
        newQuest.enemy = classes.enemies[Random.Range(0, 14)];
        newQuest.questType = classes.questTypes[Random.Range(0, 8)];

        return newQuest;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Quest newQuest = CreateQuest();

            Debug.Log(newQuest.level);
            Debug.Log(newQuest.enemy);
            Debug.Log(newQuest.questType);
        }
    }
}
