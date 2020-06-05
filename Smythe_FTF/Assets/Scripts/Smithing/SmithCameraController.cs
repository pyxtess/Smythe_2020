using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmithCameraController : MonoBehaviour
{
    UnitMetal unit;

    private Vector3 targetPos;
    public float cameraSpeed;

    //public float cameraSize;

    private float prevConsolidation;
    private float prevSpread;

    // Start is called before the first frame update
    void Start()
    {
        unit = GameObject.FindGameObjectWithTag("UnitInfo").GetComponent<UnitMetal>();
        prevConsolidation = unit.currConsolidationLvl;
        prevSpread = unit.currSpread;

        //Camera.main.orthographicSize = cameraSize;
    }

    // Update is called once per frame
    void Update()
    {
        viewCenterPoint();

        UpdateOrthogonalSize();

        
        
    }
    
    //Keeps Camera locked on center position
    private void viewCenterPoint()
    {
        targetPos = new Vector3(unit.centerPoint.transform.position.x, unit.centerPoint.transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPos, cameraSpeed * Time.fixedDeltaTime);
    }

    private void UpdateOrthogonalSize()
    {
        /*
        if (prevSpread < unit.currSpread)
            Camera.main.orthographicSize
        */
    }
}
