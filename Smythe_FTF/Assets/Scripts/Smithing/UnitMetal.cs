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
        UpdateConsolidationLvl();
        UpdateSpread();
        UpdateCenter();
    }
/// 
/// ///////////////////////////////////////////////////////////////////////

/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *\
* Update Section: Where components are updated
\* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
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
        }
    }


    /// 
    /// ///////////////////////////////////////////////////////////////////////
    


}
