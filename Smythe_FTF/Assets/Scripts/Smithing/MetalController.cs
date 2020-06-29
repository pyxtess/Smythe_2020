using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MetalController : MonoBehaviour
{
    UnitMetal unit;

    public Text lengthText;
    public Text widthText;
    public Text consolidationLvlText;
    public Text porosityText;

    // Start is called before the first frame update
    void Start()
    {
        //Finds the Metal Prefab>>UnitMetal
        unit = GameObject.FindGameObjectWithTag("UnitInfo").GetComponent<UnitMetal>();
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.R))
            unit.Spread();
        if (Input.GetKeyDown(KeyCode.W))
            unit.nextBone();
        if (Input.GetKeyDown(KeyCode.S))
            unit.prevBone();
        if (Input.GetKeyDown(KeyCode.A))
            unit.leftBone();
        if (Input.GetKeyDown(KeyCode.D))
            unit.rightBone();
        if (Input.GetKeyDown(KeyCode.Q))
            unit.rotateACW();
        if (Input.GetKeyDown(KeyCode.E))
            unit.rotateCW();
        */

        UpdateUI();
    }
   
    private void UpdateUI()
    {
        //Blade Length
        lengthText.text = "Blade Length: " + Mathf.Round(unit.currLength * 10) / 10 + " u.";

        //Blade Width
        widthText.text = "Blade Width: " + Mathf.Round(unit.currWidth * 10) / 10 + " u.";

        //Consolidation Level
        consolidationLvlText.text = "Consolidation: " + unit.currConsolidationLvl + " u.";

        //Porosity Threshold Position
        porosityText.text = "Porosity Threshold: " + unit.currPorosity + " u.";
    }


}
