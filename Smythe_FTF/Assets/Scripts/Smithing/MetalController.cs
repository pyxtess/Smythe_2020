using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MetalController : MonoBehaviour
{
    UnitMetal unit;

    public Text spreadText;
    public Text consolidationLvlText;

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
        if (Input.GetKeyDown(KeyCode.F))
            unit.Consolidation();
        if (Input.GetKeyDown(KeyCode.R))
            unit.Spread();
        if (Input.GetKeyDown(KeyCode.W))
            unit.nextSpine();
        if (Input.GetKeyDown(KeyCode.S))
            unit.prevSpine();
        if (Input.GetKeyDown(KeyCode.Q))
            unit.rotateCW();

        UpdateUI();
    }
   
    private void UpdateUI()
    {
        //Blade Length
        spreadText.text = "Spread: " + Mathf.Round(unit.currSpread * 10) / 10 + " u.";

        //Consolidation Level
        consolidationLvlText.text = "Consolidation: " + unit.currConsolidationLvl + " u.";

        //Center Point Position
        
    }


}
