using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SmithDialogueController : MonoBehaviour
{
    public TextMeshProUGUI dialogue;
    public float letterPerSecond;
/*
    private void Start()
    {
        dialogue = GetComponent<TextMeshProUGUI>();
    }
    */
    public void SetDialogue(string newDialogue)
    {
        dialogue.text = newDialogue;
    }

    public IEnumerator TypeDialogue(string newDialogue)
    {
        dialogue.text = "";
        foreach(var letter in newDialogue.ToCharArray())
        {
            dialogue.text += letter;
            yield return new WaitForSeconds(1f / letterPerSecond);
        }
    }

}
