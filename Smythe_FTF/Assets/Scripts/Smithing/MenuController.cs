using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    UnitMetal unit;
    GameObject nextMenu;

    public bool ptrActive;

    // Start is called before the first frame update
    void Start()
    {
        unit = GameObject.FindGameObjectWithTag("UnitInfo").GetComponent<UnitMetal>();

    }

    // Update is called once per frame
    void Update()
    {
        if (ptrActive)
        {
            if (Input.GetKeyDown(KeyCode.W))
                unit.nextBone();
            if (Input.GetKeyDown(KeyCode.S))
                unit.prevBone();
            if (Input.GetKeyDown(KeyCode.A))
                unit.leftBone();
            if (Input.GetKeyDown(KeyCode.D))
                unit.rightBone();
            if (Input.GetKeyDown(KeyCode.F))
            {
                nextMenu.transform.position = unit.editPoint.transform.position;
                nextMenu.SetActive(true);
                togglePtr();
            }
        }

    }

    public void togglePtr()
    {
        ptrActive = !ptrActive;
    }

    public void setSubMenu(GameObject menu)
    {
        nextMenu = menu;
    }

    /*
        public void toggleMenu()
        {
            if(ptrActive)
            {


            }
            else
            {

            }

        }
        */
}
