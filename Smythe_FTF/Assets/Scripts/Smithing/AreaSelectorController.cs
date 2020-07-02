using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaSelectorController : MonoBehaviour
{

    public UnitMetal unit;

    public int col;
    public int ePos;

    // Start is called before the first frame update
    void Start()
    {
        col = 0;
        ePos = 0;
        UpdateAreaSelector();
    }

    public int SelectorControl()
    {
        //UP
        if (Input.GetKeyDown(KeyCode.W))
            nextBone();
        //Down
        if (Input.GetKeyDown(KeyCode.S))
            prevBone();
        //Left
        if (Input.GetKeyDown(KeyCode.A))
            leftBone();
        //Right
        if (Input.GetKeyDown(KeyCode.D))
            rightBone();

        UpdateAreaSelector();

        if (Input.GetKeyUp(KeyCode.Return))
            return 1;

        if (Input.GetKeyUp(KeyCode.Escape))
            return -1;
        else
            return 0;
    }

    // Updates Area Selector
    public void UpdateAreaSelector()
    {
        //Updates EditPoint position
        switch (col)
        {
            case 0:
                transform.position = unit.spine[ePos].transform.position;
                break;
            case 1:
                transform.position = unit.rightEdge[ePos].transform.position;
                break;
            case -1:
                transform.position = unit.leftEdge[ePos].transform.position;
                break;

        }

    }

    // Goes to next bone; loops back around if at end
    public void nextBone()
    {
        switch (col)
        {
            case 0:
                if (ePos + 1 >= unit.spine.Length)
                {
                    ePos = 1;
                    transform.position = unit.spine[ePos].transform.position;
                }
                else
                    transform.position = unit.spine[++ePos].transform.position;
                break;
            case -1:
                if (ePos + 1 >= unit.leftEdge.Length)
                {
                    ePos = 0;
                    transform.position = unit.leftEdge[ePos].transform.position;
                }
                else
                    transform.position = unit.leftEdge[++ePos].transform.position;
                break;
            case 1:
                if (ePos + 1 >= unit.rightEdge.Length)
                {
                    ePos = 0;
                    transform.position = unit.rightEdge[ePos].transform.position;
                }
                else
                    transform.position = unit.rightEdge[++ePos].transform.position;
                break;
        }
    }

    // Goes to prev bone; loops back around if at beginning
    public void prevBone()
    {
        switch (col)
        {
            case 0:
                if (ePos - 1 < 1)
                {
                    ePos = unit.spine.Length - 1;
                    transform.position = unit.spine[ePos].transform.position;
                }
                else
                    transform.position = unit.spine[--ePos].transform.position;
                break;
            case -1:
                if (ePos - 1 < 0)
                {
                    ePos = unit.leftEdge.Length - 1;
                    transform.position = unit.leftEdge[ePos].transform.position;
                }
                else
                    transform.position = unit.leftEdge[--ePos].transform.position;
                break;
            case 1:
                if (ePos - 1 < 0)
                {
                    ePos = unit.rightEdge.Length - 1;
                    transform.position = unit.rightEdge[ePos].transform.position;
                }
                else
                    transform.position = unit.rightEdge[--ePos].transform.position;
                break;
        }
    }

    // Goes to left bone group
    public void leftBone()
    {
        switch (col)
        {
            case 0:
                transform.position = unit.leftEdge[--ePos].transform.position;
                --col;
                break;
            case 1:
                transform.position = unit.spine[++ePos].transform.position;
                --col;
                break;
            default:
                break;
        }
    }

    // Goes to left bone group
    public void rightBone()
    {
        switch (col)
        {
            case 0:
                transform.position = unit.rightEdge[--ePos].transform.position;
                ++col;
                break;
            case -1:
                transform.position = unit.spine[++ePos].transform.position;
                ++col;
                break;
            default:
                break;
        }
    }
}
