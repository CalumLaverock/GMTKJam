using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ReputationManager : MonoBehaviour
{
    [SerializeField]
    GameObject rep;

    [SerializeField]
    GameObject levelManager;

    public void Start()
    {
        reputation = 0;
    }

    static private float reputation = 0;

    static public float GetReputation() { return reputation; }

    static public void AddReputation(float addRep) 
    { 
        reputation += addRep;
    }

    private void Update()
    {
        var info = rep.transform;

        info.Find("Reputation Label").Find("Reputation").GetComponent<TextMeshProUGUI>().text = GetReputation().ToString("F2");

        if (GetReputation() < -40)
        {
            levelManager.GetComponent<LevelManager>().Lose();
        }
        else if (GetReputation() > 40) 
        {
            levelManager.GetComponent<LevelManager>().Win();
        }
    }
}
