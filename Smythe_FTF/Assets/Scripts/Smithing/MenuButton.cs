using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuButton : MonoBehaviour
{
    public Button myButton;
    public int thisIndex;
    public int prevIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        if(thisIndex == 0)
        {
            // Select the button
            myButton.Select(); // Or EventSystem.current.SetSelectedGameObject(myButton.gameObject)
            
            // Highlight the button
            myButton.OnSelect(null); // Or myButton.OnSelect(new BaseEventData(EventSystem.current))
        }
        
    }

    private void OnEnable()
    {
        if (thisIndex == prevIndex)
        {
            // Select the button
            myButton.Select(); // Or EventSystem.current.SetSelectedGameObject(myButton.gameObject)

            // Highlight the button
            myButton.OnSelect(null); // Or myButton.OnSelect(new BaseEventData(EventSystem.current))
        }
        
    }
}
