using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class MenuController : MonoBehaviour
{
    public GameObject[] MenuObjects;
    //public TextMeshProUGUI[] MenuTexts;

    GameObject currentSelected;


    // Start is called before the first frame update
    void Start()
    {
        Setup();
    }

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
    
}
