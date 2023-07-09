using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.UI;

public class SpriteButton : MonoBehaviour
{
    public LevelManager levelManager;

    private void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    private void OnMouseOver()
    {
        if (!levelManager.IsSpriteButtonOpen(gameObject.name))
        {
            GetComponent<SpriteRenderer>().color = new Color(0.6f, 0.6f, 0.6f);

            if (Input.GetMouseButtonDown(0))
            {
                levelManager.SpriteButtonClick(gameObject.name);
            }
        }
    }
}
