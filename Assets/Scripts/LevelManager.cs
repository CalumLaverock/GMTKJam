using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public QuestList questList;
    public GuidebookManager guidebookManager;

    public void QuitGame()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void SpriteButtonClick(string buttonType)
    {
        if (buttonType == "Guidebook Image")
            guidebookManager.open = true;
        else if (buttonType == "Questlist Image")
            questList.showList = true;
    }

    public bool IsSpriteButtonOpen(string buttonType)
    {
        if (buttonType == "Guidebook Image")
            return guidebookManager.open;
        else if (buttonType == "Questlist Image")
            return questList.showList;
        else
            return true;
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
