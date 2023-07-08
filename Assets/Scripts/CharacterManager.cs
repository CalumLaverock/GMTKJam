using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public struct Character
{
    public Sprite charImage;

    public HeroClass charClass;
    public int charLevel;

    public List<string> charQuestStrengths;
    public List<string> charQuestWeaknesses;
}

public class CharacterManager : MonoBehaviour
{
    [SerializeField]
    GameObject characterInfoSheet;

    public Character character;

    [SerializeField]
    Sprite aragorn;

    private void Start()
    {
        character.charQuestStrengths = new List<string>();
        character.charQuestWeaknesses = new List<string>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.B))
        {
            GenerateCharacter();

            var infoSheet = characterInfoSheet.transform;
            infoSheet.Find("Class Label").Find("Class").GetComponent<TextMeshProUGUI>().text = character.charClass.name;
            infoSheet.Find("Level Label").Find("Level").GetComponent<TextMeshProUGUI>().text = character.charLevel.ToString();
            infoSheet.Find("Strengths Label").Find("Strengths").GetComponent<TextMeshProUGUI>().text = character.charQuestStrengths[0] + ", " + character.charQuestStrengths[1];
            infoSheet.Find("Weaknesses Label").Find("Weaknesses").GetComponent<TextMeshProUGUI>().text = character.charQuestWeaknesses[0] + ", " + character.charQuestWeaknesses[1];
            infoSheet.Find("Image").GetComponent<Image>().sprite = character.charImage;
        }
    }

    public void GenerateCharacter()
    {
        character.charQuestStrengths.Clear();
        character.charQuestWeaknesses.Clear();
        character.charImage = aragorn;

        character.charLevel = Random.Range(1, 20);
        character.charClass = Classes.classes[Random.Range(0, Classes.classes.Count - 1)];

        List<string> questList = Classes.questTypes.ToList();
        for(int i = 0; i < 2; i++)
        {
            var rand = Random.Range(0, questList.Count - 1);
            character.charQuestStrengths.Add(questList[rand]);
            questList.Remove(questList[rand]);

            rand = Random.Range(0, questList.Count - 1);
            character.charQuestWeaknesses.Add(questList[rand]);
            questList.Remove(questList[rand]);
        }
    }
}
