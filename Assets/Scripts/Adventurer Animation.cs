using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class AdventurerAnimation : MonoBehaviour
{
    [SerializeField]
    Animator anim;

    [DoNotSerialize]
    public Character animChar;
    [DoNotSerialize]
    public Sprite[] animSprites;

    public void SetState(bool state)
    {
        anim.SetBool("IDLE", state);
        anim.SetBool("TALK", !state);
    }

    public void SetCharacter(string character)
    {
        anim.SetTrigger(character);
    }

    public void SetEnter(bool enter)
    {
        if (enter)
            anim.SetTrigger("ENTER");
        else
            anim.SetTrigger("EXIT");
    }

    public void SetCharacterSprite()
    {
        GetComponent<SpriteRenderer>().sprite = animSprites[animChar.charClassIndex];
    }

    public void SetCharacterAnim()
    {
        SetState(false);
        SetCharacter(animChar.charClass.name);
    }
}
