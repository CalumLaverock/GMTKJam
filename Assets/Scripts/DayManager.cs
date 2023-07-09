using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayManager : MonoBehaviour
{
    [SerializeField]
    GameObject DaySpace;

    [SerializeField]
    GameObject NightSpace;

    [SerializeField]
    GameObject Quest;

    [SerializeField]
    GameObject Guidebook;

    public bool dayTime;

    // Start is called before the first frame update
    void Start()
    {
        dayTime = true;
        DaySpace.SetActive(true);
        NightSpace.SetActive(false);
    }

    void Update()
    {
        if(Quest.transform.childCount == 0)
        {
            dayTime = false;
            DaySpace.SetActive(false);
            NightSpace.SetActive(true);
        }
    }

    public void NextDay()
    {
        dayTime = true;
        DaySpace.SetActive(true);
        NightSpace.SetActive(false);

        Quest.GetComponent<QuestList>().GenerateQuestList();

        Guidebook.GetComponent<GuidebookManager>().open = false;
        Quest.GetComponent<QuestList>().showList = false;
    }
}
