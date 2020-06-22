using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OldMenuButton : MonoBehaviour
{
    public OldMenuController menuController;
    public Animator anim;
    //[SerializeField] AnimatorFunctions animatorFunctions;
    public int thisIndex;

    public Text buttonText;
    UnitMetal unit;

    void Start()
    {
        unit = GameObject.FindGameObjectWithTag("UnitInfo").GetComponent<UnitMetal>();
    }

    // Update is called once per frame
    void Update()
    {
        if (menuController.index == thisIndex)
        {
            anim.SetBool("selected", true);
            if (Input.GetAxis("Submit") == 1)
            {
                anim.SetBool("pressed", true);
                pressedAction();
            }
            else if (anim.GetBool("pressed"))
                anim.SetBool("pressed", false);
        }
        else
            anim.SetBool("selected", false);
    }

    void pressedAction()
    {
        switch(buttonText.text)
        {
            case "H I T":
                //unit.Consolidation(0.1f, 0.05f);
                anim.SetBool("selected", false);
                break;
        }
    }
}
