using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class QuestManager : MonoBehaviour
{
    [SerializeField]
    GameObject Quest;

    [SerializeField]
    GameObject Character;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            var questInfo = Quest.GetComponent<QuestMaker>().quest;
            var characterInfo = Character.GetComponent<CharacterManager>().character;

            double zeroPoint = 5; // Number of levels away from the quest level where you do not gain points any more
            double maxPoints = 5; // Number of points gained at the perfect level, number of points lost at double zeroPoint levels away from the quest

            double qLevel = questInfo.level;
            double cLevel = characterInfo.charLevel;

            float repGain = 0;

            if (cLevel - qLevel < zeroPoint * -1) // Below minimum to gain reputation
            {
                repGain = Convert.ToSingle(-maxPoints * Math.Pow(cLevel - qLevel + zeroPoint, 2) / Math.Pow(zeroPoint, 2));
            }
            else if(Math.Abs(cLevel - qLevel) < zeroPoint) // Within reputation gain bounds
            {
                repGain = Convert.ToSingle((maxPoints / 2) * Math.Sin(((cLevel - qLevel) * Math.PI) / zeroPoint + Math.PI / 2) + maxPoints / 2);
            }
            else // Above reputation gain bounds
            {
                repGain = Convert.ToSingle(-maxPoints * Math.Pow(cLevel - qLevel - zeroPoint, 2) / Math.Pow(zeroPoint, 2));
            }

            ReputationManager.AddReputation(repGain);
        }
    }
}