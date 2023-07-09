using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.UI;
using UnityEngine.UI;

public struct Character
{
    public int charClassIndex;
    public HeroClass charClass;
    public int charLevel;

    public List<string> charQuestStrengths;
    public List<string> charQuestWeaknesses;
}

public class CharacterManager : MonoBehaviour
{
    [SerializeField]
    private GameObject characterInfoSheet;

    public Character character;

    [SerializeField]
    private GameObject adventurer;

    private AdventurerAnimation anim;

    private void Start()
    {
        anim = adventurer.GetComponent<AdventurerAnimation>();
        anim.SetState(true);

        character.charQuestStrengths = new List<string>();
        character.charQuestWeaknesses = new List<string>();

        GenerateCharacter();
    }

    private void FixedUpdate()
    {
    }

    public void GenerateCharacter()
    {
        character.charQuestStrengths.Clear();
        character.charQuestWeaknesses.Clear();

        character.charLevel = Random.Range(1, 21);
        character.charClassIndex = Random.Range(0, Classes.classes.Count);
        character.charClass = Classes.classes[character.charClassIndex];

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

        var infoSheet = characterInfoSheet.transform;
        infoSheet.Find("Class Label/Class").GetComponent<TextMeshProUGUI>().text = character.charClass.name;
        infoSheet.Find("Level Label/Level").GetComponent<TextMeshProUGUI>().text = character.charLevel.ToString();
        infoSheet.Find("Strengths Label/Strengths").GetComponent<TextMeshProUGUI>().text = character.charQuestStrengths[0] + ",\n" + character.charQuestStrengths[1];
        infoSheet.Find("Weaknesses Label/Weaknesses").GetComponent<TextMeshProUGUI>().text = character.charQuestWeaknesses[0] + ",\n" + character.charQuestWeaknesses[1];

        anim.animChar = character;
        anim.SetCharacterAnim();
    }
}
