using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene("CharacterTest");
    }

    public void OptionsButton()
    {
        SceneManager.LoadScene("OptionsMenu");
    }

    public void QuitButton()
    {
        Application.Quit(); 
    }
}
