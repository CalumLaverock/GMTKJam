using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class QuestList : MonoBehaviour
{
    public int numQuests;

    [SerializeField]
    private GameObject questPrefab;

    private Vector3 startPos;

    public EventSystem eventSystem;
    private GraphicRaycaster gr;
    private PointerEventData pointerEventData;

    private Transform selectedQuest;

    public bool showList;

    [SerializeField]
    private CharacterManager charManager;
    [SerializeField]
    private QuestManager questManager;

    private int numTurnedAway;

    private void Start()
    {
        pointerEventData = new PointerEventData(eventSystem);
        gr = GetComponentInParent<GraphicRaycaster>();

        startPos = transform.position;
        showList = false;
        numTurnedAway = 0;

        GenerateQuestList();
    }

    private void Update()
    {
        // setup raycast
        pointerEventData.position = Input.mousePosition;
        List<RaycastResult> results = new List<RaycastResult>();
        gr.Raycast(pointerEventData, results);

        if (results.Count > 0 && Input.GetMouseButtonDown(0))
        {
            // find if raycast hits a CharacterCell and set raycastCharacter
            RaycastResult questRay = results.Find(obj => obj.gameObject.name.Contains("QuestPrefab"));
            Transform raycastQuest = questRay.isValid ? questRay.gameObject.transform : null;

            if (raycastQuest != null)
            {
                Color selectedColor = raycastQuest.GetComponent<Image>().color;
                if (selectedQuest != null)
                {
                    selectedColor.a = 0; // make it transparent
                    selectedQuest.GetComponent<Image>().color = selectedColor; // disabled the current selection before doing another one
                }

                selectedQuest = raycastQuest;
                selectedColor.a = 0.33f; // make it transluscent
                selectedQuest.GetComponent<Image>().color = selectedColor;
            }
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            showList = !showList;
        }

        GetComponentInParent<Canvas>().enabled = showList;
    }

    private void GenerateQuestList()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject); // clear out the last quest list
        }

        transform.position = startPos; // undo any scrolling that has happened

        for (int i = 0; i < numQuests; i++)
        {
            GameObject questCell = Instantiate(questPrefab, transform);
            Quest quest = QuestGenerator.CreateQuest();

            questCell.transform.Find("Enemy Label/Enemy").GetComponent<TextMeshProUGUI>().text = quest.enemy;
            questCell.transform.Find("Level Label/Level").GetComponent<TextMeshProUGUI>().text = quest.level.ToString();
            questCell.transform.Find("Type Label/Type").GetComponent<TextMeshProUGUI>().text = quest.questType;
            questCell.GetComponent<QuestStore>().storedQuest = quest;
        }
    }

    public void SubmitQuest()
    {
        if(selectedQuest != null)
        {
            questManager.CalculateReputation(selectedQuest.GetComponent<QuestStore>().storedQuest);

            numTurnedAway = 0;

            Destroy(selectedQuest.gameObject); // remove the submitted quest
            selectedQuest = null;

            if(transform.childCount == 1) // the game object technically doesn't get destroyed until later so the childCount will be 1 when the last quest is removed
            {
                // change this to be whatever happens for getting a new "level"
                Debug.Log("no quests here mate");
                GenerateQuestList();
            }

            charManager.GenerateCharacter();
        }
    }

    public void NoQuest()
    {
        // new character
        charManager.GenerateCharacter();

        numTurnedAway++;
        if(numTurnedAway >= 5)
        {
            // reset the level after turning away too many?
            numTurnedAway = 0;
            charManager.GenerateCharacter();
            GenerateQuestList();
        }
    }
}
