using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/*
 * MenuController: Template Menu controller
*/

public class MenuController : MonoBehaviour
{
    public GameObject[] MenuObjects;
    //public TextMeshProUGUI[] MenuTexts;
    public int currPosition;

    //public bool VerticalMenuToggle;
    //public bool CircularMenuToggle;

    // Start is called before the first frame update
    void Start()
    {
        Setup();
    }

    // Update is called once per frame

    void Setup()
    {
        currPosition = 0;
        for (int pos = 0; pos < MenuObjects.Length; ++pos)
        {
            optionDeselection(pos);
        }

        optionSelection(currPosition);
    }

    //For menus that are striclly vertical
    public void VerticalMenuControl()
    {
        //Down
        if (Input.GetKeyDown(KeyCode.S))
        {
            optionDeselection(currPosition);
            ++currPosition;

            if (currPosition > (MenuObjects.Length - 1))
                currPosition = MenuObjects.Length - 1;
            optionSelection(currPosition);
        }
        //UP
        if(Input.GetKeyDown(KeyCode.W))
        {
            optionDeselection(currPosition);
            --currPosition;
            if (currPosition < 0)
                currPosition = 0;
            optionSelection(currPosition);
        }
    }

    //For menus that are striclly circular
    public void CircularMenuControl()
    {
        switch(currPosition)
        {
            case 0:
                if(Input.GetKeyDown(KeyCode.S))
                {
                    optionDeselection(currPosition);
                    currPosition = 2;
                    optionSelection(currPosition);
                }
                if (Input.GetKeyDown(KeyCode.A))
                {
                    optionDeselection(currPosition);
                    currPosition = 1;
                    optionSelection(currPosition);
                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    optionDeselection(currPosition);
                    currPosition = 3;
                    optionSelection(currPosition);
                }
                break;
            case 1:
                if (Input.GetKeyDown(KeyCode.S))
                {
                    optionDeselection(currPosition);
                    currPosition = 2;
                    optionSelection(currPosition);
                }
                if (Input.GetKeyDown(KeyCode.W))
                {
                    optionDeselection(currPosition);
                    currPosition = 0;
                    optionSelection(currPosition);
                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    optionDeselection(currPosition);
                    currPosition = 3;
                    optionSelection(currPosition);
                }
                break;
            case 2:
                if (Input.GetKeyDown(KeyCode.W))
                {
                    optionDeselection(currPosition);
                    currPosition = 0;
                    optionSelection(currPosition);
                }
                if (Input.GetKeyDown(KeyCode.A))
                {
                    optionDeselection(currPosition);
                    currPosition = 1;
                    optionSelection(currPosition);
                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    optionDeselection(currPosition);
                    currPosition = 3;
                    optionSelection(currPosition);
                }
                break;
            case 3:
                if (Input.GetKeyDown(KeyCode.S))
                {
                    optionDeselection(currPosition);
                    currPosition = 2;
                    optionSelection(currPosition);
                }
                if (Input.GetKeyDown(KeyCode.A))
                {
                    optionDeselection(currPosition);
                    currPosition = 1;
                    optionSelection(currPosition);
                }
                if (Input.GetKeyDown(KeyCode.W))
                {
                    optionDeselection(currPosition);
                    currPosition = 0;
                    optionSelection(currPosition);
                }
                break;
        }
        //Down
        if (Input.GetKeyDown(KeyCode.S))
        {
            optionDeselection(currPosition);
            ++currPosition;

            if (currPosition > (MenuObjects.Length - 1))
                currPosition = MenuObjects.Length - 1;
            optionSelection(currPosition);
        }
        //UP
        if (Input.GetKeyDown(KeyCode.W))
        {
            optionDeselection(currPosition);
            --currPosition;
            if (currPosition < 0)
                currPosition = 0;
            optionSelection(currPosition);
        }
    }

    //How the Selection looks
    void optionSelection(int position)
    {
        MenuObjects[position].transform.localScale = new Vector3(1.2f, 1.2f, 1f);
        MenuObjects[position].GetComponent<TextMeshProUGUI>().color = new Color32(255, 255, 255, 255);
    }

    //How the Selection looks
    void optionDeselection(int position)
    {
        MenuObjects[position].transform.localScale = new Vector3(1f, 1f, 1f);
        MenuObjects[position].GetComponent<TextMeshProUGUI>().color = new Color32(200, 200, 200, 175);
    }
}
