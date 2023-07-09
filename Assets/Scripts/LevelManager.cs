using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public QuestList questList;
    public GuidebookManager guidebookManager;

    [SerializeField]
    GameObject DayManager;

    public void QuitGame()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void SpriteButtonClick(string buttonType)
    {
        if (DayManager.GetComponent<DayManager>().dayTime == true)
        {
            if (buttonType.Contains("Guidebook"))
                guidebookManager.open = true;
            else if (buttonType.Contains("Questlist"))
                questList.showList = true;
        }
    }

    public bool IsSpriteButtonOpen(string buttonType)
    {
        if (DayManager.GetComponent<DayManager>().dayTime == true)
        {
            if (buttonType.Contains("Guidebook"))
                return guidebookManager.open;
            else if (buttonType.Contains("Questlist"))
                return questList.showList;
            else
                return true;
        }
        else return true;
    }

    public void Win()
    {
        SceneManager.LoadScene("Win");
    }

    public void Lose()
    {
        SceneManager.LoadScene("Lose");
    }
}
