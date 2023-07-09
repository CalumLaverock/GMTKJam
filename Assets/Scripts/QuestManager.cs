using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class QuestManager : MonoBehaviour
{
    [SerializeField]
    GameObject Character;

    public void CalculateReputation(Quest selectedQuest)
    {
        var questInfo = selectedQuest;
        var characterInfo = Character.GetComponent<CharacterManager>().character;

        double zeroPoint = 5; // Number of levels away from the quest level where you do not gain points any more
        double maxPoints = 5; // Number of points gained at the perfect level, number of points lost at double zeroPoint levels away from the quest

        double qLevel = questInfo.level;
        double cLevel = characterInfo.charLevel;

        foreach (var classType in Classes.classes)
        {
            if (classType.name == characterInfo.charClass.name)
            {
                cLevel -= 2 - classType.enemyStrengths[questInfo.enemy];
                break;
            }
        }

        float repGain = 0;

        if (cLevel - qLevel < zeroPoint * -1) // Below minimum to gain reputation
        {
            repGain = Convert.ToSingle(-maxPoints * Math.Pow(cLevel - qLevel + zeroPoint, 2) / Math.Pow(zeroPoint, 2));
        }
        else if (Math.Abs(cLevel - qLevel) < zeroPoint) // Within reputation gain bounds
        {
            repGain = Convert.ToSingle((maxPoints / 2) * Math.Sin(((cLevel - qLevel) * Math.PI) / zeroPoint + Math.PI / 2) + maxPoints / 2);
        }
        else // Above reputation gain bounds
        {
            repGain = Convert.ToSingle(-maxPoints * Math.Pow(cLevel - qLevel - zeroPoint, 2) / Math.Pow(zeroPoint, 2));
        }

        float mod = 1;

        foreach (var strength in characterInfo.charQuestStrengths)
        {
            if (strength == questInfo.questType)
            {
                mod = 1.25f;
                break;
            }
        }

        if (mod == 1)
        {
            foreach (var weakness in characterInfo.charQuestWeaknesses)
            {
                if (weakness == questInfo.questType)
                {
                    mod = 0.75f;
                    break;
                }
            }
        }

        ReputationManager.AddReputation(repGain * mod);
    }
}