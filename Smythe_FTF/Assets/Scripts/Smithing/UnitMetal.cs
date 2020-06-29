using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMetal : MonoBehaviour
{
    public string MetalName;
//-----------------------------------------------
    //Bone Group
    public GameObject boneGroup;
//-----------------------------------------------
    //Bones
    public GameObject[] spine;
    public GameObject[] leftEdge;
    public GameObject[] rightEdge;
//-----------------------------------------------
    //Pointers
    public GameObject centerPoint;
    public GameObject editPoint;
    [SerializeField] private int ePos;
    public int col = 0;
//-----------------------------------------------
    public float maxLength;
    public float maxWidth;
    //Max Scale
    public float maxConsolidation;
    //Max Brittleness (Critical Fail Threshold)
    public int maxPorosity;
    //-----------------------------------------------
    public float currLength;
    public float currWidth;
    //Current Scale
    public float currConsolidationLvl;
    //Current Brittleness (Critical Fail gauge)
    public int currPorosity;
//-----------------------------------------------
    //Best Consolidation point
    //public float porosityThreshold;
    //Number subtracted to porosity when successful
    //public float cpSuccess;
    //Number added to porosity when failed
    //public float cpFail;

    /* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *\
    * Initialization: Startup stuff
    \* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
    private void Start()
    {
        editPoint.transform.position = spine[1].transform.position;
        editPoint.SetActive(false);
        ePos = 1;

        currLength = 1;
        currWidth = 1;

        //cpSuccess = currPorosity / ((porosityThreshold - currConsolidationLvl) * 9);
        //cpFail = maxPorosity / ((maxConsolidation - porosityThreshold) * 9);

        UpdateConsolidationLvl();
        //UpdateLength();
        //UpdateWidth();
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
    public float UpdateLength()
    {
        currLength = Mathf.Round(Vector3.Distance(spine[0].transform.position, spine[18].transform.position)*10)/10;
        //UpdateCenter();
        return currLength;
    }

    // Updates blade length
    public float UpdateWidth()
    {
        currWidth = Mathf.Round(Vector3.Distance(leftEdge[0].transform.position, rightEdge[0].transform.position) * 10) / 10;
        //UpdateCenter();
        return currWidth;
    }

    // Updates consolidation level
    public float UpdateConsolidationLvl()
    {
        currConsolidationLvl = Mathf.Round(boneGroup.transform.localScale.x * 10)/10;
        return currConsolidationLvl;
    }

    public float UpdatePorosityThreshold()
    {
        return currPorosity;
    }

    /// 
/// ///////////////////////////////////////////////////////////////////////

/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *\
 * Metal Manipulation Section: Manipulates the bones in some fashion
\* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

    // Scales Bones group and spreads out the edge bones horizontally
    public void Consolidation(float consolPos)
    {
        if(currConsolidationLvl < maxConsolidation)
        {
            //0.1f
            boneGroup.transform.localScale += new Vector3(consolPos, consolPos, 0);

            if (currPorosity > 0)
                currPorosity -= 1;
            else
            {
                currPorosity -= 2;
                if (currPorosity <= maxPorosity)
                    currPorosity = maxPorosity;
            }

            UpdateConsolidationLvl();
            UpdateLength();
            UpdateWidth();
            UpdateCenter();
            UpdateUI();
        }
    }

    //Spreads spine bones vertically
    public void drawAllVertical(float lengthScale)
    {
        if(currLength < maxLength)
        {
            for (int i = 1; i < spine.Length - 1; ++i)
                spine[i].transform.position += new Vector3(0f, lengthScale, 0f);

            UpdateLength();
            UpdateCenter();
            UpdateUI();
        }
    }

    public void drawAllHorizontal(float widthScale)
    {
        if (currWidth < maxWidth)
        {
            foreach (GameObject lEdge in leftEdge)
                lEdge.transform.position -= new Vector3(widthScale, 0f, 0f);
            foreach (GameObject rEdge in rightEdge)
                rEdge.transform.position += new Vector3(widthScale, 0f, 0f);

            UpdateWidth();
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
