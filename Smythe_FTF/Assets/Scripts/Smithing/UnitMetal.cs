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
    public GameObject spinePoint;
    [SerializeField] private int sPos;
    
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
        spinePoint.transform.position = spine[1].transform.position;
        sPos = 1;

        UpdateConsolidationLvl();
        UpdateSpread();
        UpdateCenter();
    }
    /// 
/// ///////////////////////////////////////////////////////////////////////

/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *\
* UI Guide Section: Where UI elements are located
\* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
    
    // Goes to next spine bone; loops back around if at end
    public void nextSpine()
    {
        if(sPos+1 >= spine.Length)
        {
            sPos = 1;
            spinePoint.transform.position = spine[sPos].transform.position;
        }
        else
            spinePoint.transform.position = spine[++sPos].transform.position;
    }

    // Goes to prev spine bone; loops back around if at beginning
    public void prevSpine()
    {
        if (sPos - 1 < 1)
        {
            sPos = spine.Length - 1;
            spinePoint.transform.position = spine[sPos].transform.position;
        }
        else
            spinePoint.transform.position = spine[--sPos].transform.position;
    }
    /// 
/// ///////////////////////////////////////////////////////////////////////

/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *\
* Update Section: Where components are updated
\* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

    // Updates UI elements
    public void UpdateUI()
    {
        spinePoint.transform.position = spine[sPos].transform.position;
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
        //add dynamic restrictions

        // Rotate the cube by converting the angles into a quaternion.
        Quaternion target = Quaternion.Euler(0, 0, spine[sPos].transform.rotation.z - 1);

        // Dampen towards the target rotation
        spine[sPos].transform.rotation = Quaternion.Slerp(transform.rotation, target, 5.0f);
    }


    /// 
    /// ///////////////////////////////////////////////////////////////////////



}
