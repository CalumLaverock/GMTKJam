using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GuidebookManager : MonoBehaviour
{
    [SerializeField]
    GameObject guidebook;

    struct Page
    {
        public string name;
        public List<string> goodMatchups;
        public List<string> badMatchups;
    }

    private int pageNum;
    private static List<Page> pages;

    private bool open;

    // Start is called before the first frame update
    void Start()
    {
        open = false;

        pageNum = 0;
        pages = new List<Page>();

        foreach(var enemy in Classes.enemies)
        {
            var page = new Page();

            page.name = enemy;

            page.goodMatchups = new List<string>();
            page.badMatchups = new List<string>();

            foreach (var classOverview in Classes.classes)
            {
                if (classOverview.enemyStrengths[enemy] == 3)
                    page.goodMatchups.Add(classOverview.name);
                else if (classOverview.enemyStrengths[enemy] == 1)
                    page.badMatchups.Add(classOverview.name);
            }

            pages.Add(page);
        }

        UpdatePage();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            open = !open;
        }

        guidebook.SetActive(open);

        if (open)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) && pageNum < 14)
            {
                pageNum++;

                UpdatePage();
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow) && pageNum > 0)
            {
                pageNum--;

                UpdatePage();
            }
        }
    }

    private void UpdatePage()
    {
        var info = guidebook.transform;

        info.Find("Creature Label").Find("Creature").GetComponent<TextMeshProUGUI>().text = pages[pageNum].name;

        info.Find("Strength Label").Find("Good").GetComponent<TextMeshProUGUI>().text = "";

        for(int i = 0; i < pages[pageNum].goodMatchups.Count; i++)
        {
            info.Find("Strength Label").Find("Good").GetComponent<TextMeshProUGUI>().text += pages[pageNum].goodMatchups[i];

            if (i < pages[pageNum].goodMatchups.Count - 1)
                info.Find("Strength Label").Find("Good").GetComponent<TextMeshProUGUI>().text += ", ";
        }

        info.Find("Weakness Label").Find("Bad").GetComponent<TextMeshProUGUI>().text = "";

        for (int i = 0; i < pages[pageNum].badMatchups.Count; i++)
        {
            info.Find("Weakness Label").Find("Bad").GetComponent<TextMeshProUGUI>().text += pages[pageNum].badMatchups[i];

            if (i < pages[pageNum].badMatchups.Count - 1)
                info.Find("Weakness Label").Find("Bad").GetComponent<TextMeshProUGUI>().text += ", ";
        }
    }
}
