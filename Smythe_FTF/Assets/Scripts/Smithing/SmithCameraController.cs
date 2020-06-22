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
    private float prevLength;

    // Start is called before the first frame update
    void Start()
    {
        unit = GameObject.FindGameObjectWithTag("UnitInfo").GetComponent<UnitMetal>();
        prevConsolidation = unit.maxConsolidation;
        prevLength = unit.currLength;

        //cameraSize = Camera.main.orthographicSize;
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateOrthogonalSize();
        viewCenterPoint();

    }
    
    //Keeps Camera locked on center position
    private void viewCenterPoint()
    {
        targetPos = new Vector3(unit.centerPoint.transform.position.x, unit.centerPoint.transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPos, cameraSpeed * Time.fixedDeltaTime);

        
    }

    //Updates camera scale
    private void UpdateOrthogonalSize()
    {
        if (prevConsolidation < unit.currConsolidationLvl)
        {
            Camera.main.orthographicSize += 0.15f;
            prevConsolidation = unit.currConsolidationLvl;
        }
        if (prevLength < unit.currLength)
        {
            Camera.main.orthographicSize += 0.075f;
            prevLength = unit.currLength;
        }
        if (prevLength > unit.currLength)
        {
            Camera.main.orthographicSize -= 0.075f;
            prevLength = unit.currLength;
        }
    }
}
