using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * CameraController: Controls camera during sword making process
*/

public class SmithCameraController : MonoBehaviour
{
    UnitMetal unit;

    public GameObject menuController;
    //MenuController mc;

    private Vector3 targetPos;
    public float cameraSpeed;

    //public float cameraSize;

    private float prevConsolidation;
    private float prevLength;

    // Start is called before the first frame update
    void Start()
    {
        unit = GameObject.FindGameObjectWithTag("UnitInfo").GetComponent<UnitMetal>();
        //mc = menuController.GetComponent<MenuController>();

        prevConsolidation = unit.maxConsolidation;
        prevLength = unit.currLength;

        //cameraSize = Camera.main.orthographicSize;
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(!mc.ptrActive)
        {
            //UpdateOrthogonalSize();
            viewCenterPoint();
        }
        else
        {
            viewEditPoint();
        }
        */

    }
    
    //Keeps Camera locked on center position
    private void viewCenterPoint()
    {

        targetPos = new Vector3(unit.centerPoint.transform.position.x, unit.centerPoint.transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPos, cameraSpeed * Time.fixedDeltaTime);
    }

    //Zooms In
    public void zoomIn(float zoom)
    {
        Camera.main.orthographicSize -= zoom;
    }
    //Zooms Out
    public void zoomOut(float zoom)
    {
        Camera.main.orthographicSize += zoom;
    }

    /*

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
    */
}
