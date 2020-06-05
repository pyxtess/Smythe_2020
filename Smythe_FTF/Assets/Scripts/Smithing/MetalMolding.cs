using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MetalMolding : MonoBehaviour
{ 
    public GameObject UnitInfo;
    MetalUnit unit;

    public Text BladeLength;

    // Start is called before the first frame update
    void Start()
    {
        unit = UnitInfo.GetComponent<MetalUnit>();
        UpdateBladeLength();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
            Consolidate();
        if (Input.GetKeyDown(KeyCode.R))
            Spread();
    }
    //Scales main spine (change to Bones Gameobject) & Stretches edges
    private void Consolidate()
    {
        if (unit.MaxConsolidation-0.1f >= unit.spine[0].transform.localScale.x)
        {
            unit.spine[0].transform.localScale += new Vector3(0.1f, 0.1f, 0);

            foreach (GameObject lEdge in unit.leftEdge)
                lEdge.transform.position -= new Vector3(0.05f, 0f, 0f);

            foreach (GameObject rEdge in unit.rightEdge)
                rEdge.transform.position += new Vector3(0.05f, 0f, 0f);

            UpdateBladeLength();
        }
    }

    //Enlongates the blade
    private void Spread()
    {
        for (int i = 1; i < unit.spine.Length - 1; ++i)
            unit.spine[i].transform.position += new Vector3(0f, 0.01f, 0f);

        UpdateBladeLength();
    }

    private void UpdateBladeLength()
    {
        float bLength = Vector3.Distance(unit.spine[0].transform.position, unit.spine[18].transform.position);
        BladeLength.text = "Blade Length: " + Mathf.Round(bLength * 10) / 10 + " u.";
    }


}
