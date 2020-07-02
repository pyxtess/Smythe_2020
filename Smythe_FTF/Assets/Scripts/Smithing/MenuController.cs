using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< HEAD
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class MenuController : MonoBehaviour
{
    public GameObject[] MenuObjects;
    //public TextMeshProUGUI[] MenuTexts;

    GameObject currentSelected;

=======

public class MenuController : MonoBehaviour
{
    SmithCameraController cam;
    UnitMetal unit;
    public bool ptrActive;
    
    GameObject prevMenu;

    public GameObject spineMenu;
    public GameObject edgeMenu;
>>>>>>> parent of dd961e7... Hard coded menu

    // Start is called before the first frame update
    void Start()
    {
        unit = GameObject.FindGameObjectWithTag("UnitInfo").GetComponent<UnitMetal>();
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<SmithCameraController>();
        ptrActive = false;
    }

<<<<<<< HEAD
    void Setup()
    {
        currentSelected = MenuObjects[0];
        MenuObjects[0].GetComponent<Button>().Select();

        //Debug.Log(EventSystem.current.currentSelectedGameObject.name);

    }

    void Update()
    {
        if(currentSelected != EventSystem.current.currentSelectedGameObject)
            currentSelected = EventSystem.current.currentSelectedGameObject;
    }
    
=======
    // Update is called once per frame
    void Update()
    {
        if(ptrActive)
        {
            if (Input.GetKeyDown(KeyCode.W))
                unit.nextBone();
            if (Input.GetKeyDown(KeyCode.S))
                unit.prevBone();
            if (Input.GetKeyDown(KeyCode.A))
                unit.leftBone();
            if (Input.GetKeyDown(KeyCode.D))
                unit.rightBone();
            if (Input.GetKeyDown(KeyCode.Escape))
                pointToMenu(prevMenu);
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (unit.col == 0)
                    pointToMenu(spineMenu);
                else
                    pointToMenu(edgeMenu);
            }
        }
        
    }

    public void pointToMenu(GameObject menu)
    {
        unit.editPoint.SetActive(false);
        menu.SetActive(true);
        cam.zoomOut(1f);
        ptrActive = false;
    }

    public void menuToPoint(GameObject menu)
    { 
        menu.SetActive(false);
        unit.editPoint.SetActive(true);
        prevMenu = menu;
        cam.zoomIn(1f);
        ptrActive = true;
    }

>>>>>>> parent of dd961e7... Hard coded menu
}
