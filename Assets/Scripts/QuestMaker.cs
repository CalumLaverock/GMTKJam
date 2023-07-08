using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestMaker : MonoBehaviour
{
    [SerializeField]
    GameObject QuestInfo;

    public Quest quest;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            quest = QuestGenerator.CreateQuest();

            var info = QuestInfo.transform;

            info.Find("Enemy Label").Find("Enemy").GetComponent<TextMeshProUGUI>().text = quest.enemy;
            info.Find("Level Label").Find("Level").GetComponent<TextMeshProUGUI>().text = quest.level.ToString();
            info.Find("Quest Type Label").Find("Quest Type").GetComponent<TextMeshProUGUI>().text = quest.questType;
        }
    }
}
