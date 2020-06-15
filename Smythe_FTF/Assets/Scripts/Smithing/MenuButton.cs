using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
    [SerializeField] MenuController menuController;
    [SerializeField] Animator anim;
    //[SerializeField] AnimatorFunctions animatorFunctions;
    [SerializeField] int thisIndex;

    // Update is called once per frame
    void Update()
    {
        if (menuController.index == thisIndex)
        {
            anim.SetBool("selected", true);
            if (Input.GetAxis("Submit") == 1)
                anim.SetBool("pressed", true);
            else if (anim.GetBool("pressed"))
                anim.SetBool("pressed", false);
        }
        else
            anim.SetBool("selected", false);
    }
}
