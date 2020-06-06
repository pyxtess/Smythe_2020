using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMetal : MonoBehaviour
{
    public string MetalName;

    //Bone Group
    public GameObject boneGroup;

    //Bones
    public GameObject[] spine;
    public GameObject[] leftEdge;
    public GameObject[] rightEdge;

    //Pointers
    public GameObject centerPoint;
    public GameObject editPoint;
    [SerializeField] private int ePos;
    [SerializeField] private int col = 0;

    //Max Scale
    public float maxConsolidation;
    //Max Length
    public float maxSpread;
    //Max Brittleness (Critical Fail Threshold)
    public float maxPorosity;

    //Current Length
    public float currSpread;
    //Current Scale
    public float currConsolidationLvl;
    //Current Brittleness (Critical Fail gauge)
    public float currPorosity;

/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *\
* Initialization: Startup stuff
\* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
    private void Start()
    {
        editPoint.transform.position = spine[1].transform.position;
        ePos = 1;

        UpdateConsolidationLvl();
        UpdateSpread();
        UpdateCenter();
    }
    /// 
/// ///////////////////////////////////////////////////////////////////////

/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *\
* UI Guide Section: Where UI elements are located
\* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
    
    // Goes to next bone; loops back around if at end
    public void nextBone()
    {
        switch (col)
        {
            case 0:
                if (ePos + 1 >= spine.Length)
                {
                    ePos = 1;
                    editPoint.transform.position = spine[ePos].transform.position;
                }
                else
                    editPoint.transform.position = spine[++ePos].transform.position;
                break;
            case -1:
                if (ePos + 1 >= leftEdge.Length)
                {
                    ePos = 0;
                    editPoint.transform.position = leftEdge[ePos].transform.position;
                }
                else
                    editPoint.transform.position = leftEdge[++ePos].transform.position;
                break;
            case 1:
                if (ePos + 1 >= rightEdge.Length)
                {
                    ePos = 0;
                    editPoint.transform.position = rightEdge[ePos].transform.position;
                }
                else
                    editPoint.transform.position = rightEdge[++ePos].transform.position;
                break;
        }
    }

    // Goes to prev bone; loops back around if at beginning
    public void prevBone()
    {
        switch(col)
        {
            case 0:
                if (ePos - 1 < 1)
                {
                    ePos = spine.Length - 1;
                    editPoint.transform.position = spine[ePos].transform.position;
                }
                else
                    editPoint.transform.position = spine[--ePos].transform.position;
                break;
            case -1:
                if (ePos - 1 < 0)
                {
                    ePos = leftEdge.Length - 1;
                    editPoint.transform.position = leftEdge[ePos].transform.position;
                }
                else
                    editPoint.transform.position = leftEdge[--ePos].transform.position;
                break;
            case 1:
                if (ePos - 1 < 0)
                {
                    ePos = rightEdge.Length - 1;
                    editPoint.transform.position = rightEdge[ePos].transform.position;
                }
                else
                    editPoint.transform.position = rightEdge[--ePos].transform.position;
                break;
        }  
    }

    // Goes to left bone group
    public void leftBone()
    {
        switch(col)
        {
            case 0:
                editPoint.transform.position = leftEdge[--ePos].transform.position;
                --col;
                break;
            case 1:
                editPoint.transform.position = spine[++ePos].transform.position;
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
                editPoint.transform.position = rightEdge[--ePos].transform.position;
                ++col;
                break;
            case -1:
                editPoint.transform.position = spine[++ePos].transform.position;
                ++col;
                break;
            default:
                break;
        }
    }
    /// 
    /// ///////////////////////////////////////////////////////////////////////

    /* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *\
    * Update Section: Where components are updated
    \* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

    // Updates UI elements
    public void UpdateUI()
    {
        //Updates EditPoint position
        switch(col)
        {
            case 0:
                editPoint.transform.position = spine[ePos].transform.position;
                break;
            case 1:
                editPoint.transform.position = rightEdge[ePos].transform.position;
                break;
            case -1:
                editPoint.transform.position = leftEdge[ePos].transform.position;
                break;

        }
        
    }
        
    // Updates center point location
    public Vector3 UpdateCenter()
    {
        centerPoint.transform.position = Vector3.Lerp(spine[0].transform.position, spine[18].transform.position, 0.5f);
        return centerPoint.transform.position;
    }

    // Updates blade length
    public float UpdateSpread()
    {
        currSpread = Mathf.Round(Vector3.Distance(spine[0].transform.position, spine[18].transform.position)*10)/10;
        //UpdateCenter();
        return currSpread;
    }

    // Updates consolidation level
    public float UpdateConsolidationLvl()
    {
        currConsolidationLvl = boneGroup.transform.localScale.x;
        return currConsolidationLvl;
    }
    /// 
/// ///////////////////////////////////////////////////////////////////////

/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *\
 * Metal Manipulation Section: Manipulates the bones in some fashion
\* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

    // Scales Bones group and spreads out the edge bones horizontally
    public void Consolidation()
    {
        if(maxConsolidation > boneGroup.transform.localScale.x)
        {
            boneGroup.transform.localScale += new Vector3(0.1f, 0.1f, 0);

            foreach (GameObject lEdge in leftEdge)
                lEdge.transform.position -= new Vector3(0.05f, 0f, 0f);
            foreach (GameObject rEdge in rightEdge)
                rEdge.transform.position += new Vector3(0.05f, 0f, 0f);

            UpdateConsolidationLvl();
            UpdateSpread();
            UpdateCenter();
            UpdateUI();
        }
    }

    //Spreads spine bones vertically
    public void Spread()
    {
        if(maxSpread > currSpread)
        {
            for (int i = 1; i < spine.Length - 1; ++i)
                spine[i].transform.position += new Vector3(0f, 0.01f, 0f);

            UpdateSpread();
            UpdateCenter();
            UpdateUI();
        }
    }

    //Rotate the spine clockwise
    public void rotateCW()
    {
        //Have dynamic restrictions
        if (col == 0) //Not permanent
            spine[ePos].transform.Rotate(new Vector3(0f, 0f, -1f));
    }

    public void rotateACW()
    {
        //Have dynamic restrictions

        if (col == 0) //Not permanent
            spine[ePos].transform.Rotate(new Vector3(0f, 0f, 1f));
    }


    /// 
    /// ///////////////////////////////////////////////////////////////////////



}
