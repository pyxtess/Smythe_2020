using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/*
 * SmithMenuController: Controls the Smithing Stage of the Sword making process
*/

public enum SmithState { Start, MoveSelection, AreaSelection, SubMoveSelection, Action, Busy};

public class SmithMenuController : MonoBehaviour
{
    //////////////////////////////////////////
    [SerializeField] SmithState state;
    public UnitMetal unit;
    /////////////////////
    public GameObject MoveMenu;
    private MenuController MoveMenuController;
    /////////////////////
    public GameObject AreaSelector;
    private AreaSelectorController AreaSelectorController;
    /////////////////////
    /// 
    public GameObject SpineMenu;

    public GameObject EdgeMenu;

    public GameObject currSubMenu;
    private MenuController SubMenuController;
    /////////////////////
    public SmithDialogueController dialogueBox;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SetupSmith());
    }

    //Sets up Stuff
    public IEnumerator SetupSmith()
    {
        state = SmithState.Start;
        MoveMenuController = MoveMenu.GetComponent<MenuController>();
        AreaSelectorController = AreaSelector.GetComponent<AreaSelectorController>();


        StartCoroutine(dialogueBox.TypeDialogue("Time to Smith!"));

        yield return new WaitForSeconds(2f);

        StartCoroutine(dialogueBox.TypeDialogue("What will you do?"));

        state = SmithState.MoveSelection;
        MoveMenu.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            /////////////////////
            //Move Selector Menu
            case SmithState.MoveSelection:
                //Movement
                MoveMenuController.VerticalMenuControl();
                //Submit & Cancel
                if (Input.GetKeyUp(KeyCode.Return))
                {
                    switch (MoveMenuController.currPosition)
                    {
                        case 0:
                            unit.Consolidation(0.1f);
                            break;
                        case 1:
                            MenuSetup(AreaSelector, MoveMenu, SmithState.AreaSelection, "Select an area you wish to draw out...");
                            break;
                    }
                }
                break;
            /////////////////////
            //Area Selector
            case SmithState.AreaSelection:
                AreaSelection();
                break;
            /////////////////////
            //Sub Menus
            case SmithState.SubMoveSelection:
                SubMenuController.CircularMenuControl();
                //if (Input.GetKeyUp(KeyCode.Return))
                    
                if (Input.GetKeyUp(KeyCode.Escape))
                        MenuSetup(AreaSelector, currSubMenu, SmithState.AreaSelection, "Select an area you wish to draw out...");
                break;
            /////////////////////
            //Minigame
            case SmithState.Action:
                break;
        }
    }

    void MenuSetup(GameObject menu, GameObject prevMenu, SmithState newState, string dialoguePrompt, bool saveMenu = false)
    {
        state = newState;
        prevMenu.SetActive(false);
        menu.SetActive(true);
        if (saveMenu)
        {
            currSubMenu = menu;
            SubMenuController = currSubMenu.GetComponent<MenuController>();
            if (Input.GetKeyUp(KeyCode.Return))
            {
                
            }

            if (Input.GetKeyUp(KeyCode.Escape))
                MenuSetup(MoveMenu, AreaSelector, SmithState.MoveSelection, "Ok... What will you do?");
        }
        else
        {
            currSubMenu = null;
            SubMenuController = null;
        }

        StartCoroutine(dialogueBox.TypeDialogue(dialoguePrompt));
    }

    void AreaSelection()
    {
        //UP
        if (Input.GetKeyDown(KeyCode.W))
            AreaSelectorController.nextBone();
        //Down
        if (Input.GetKeyDown(KeyCode.S))
            AreaSelectorController.prevBone();
        //Left
        if (Input.GetKeyDown(KeyCode.A))
            AreaSelectorController.leftBone();
        //Right
        if (Input.GetKeyDown(KeyCode.D))
            AreaSelectorController.rightBone();

        AreaSelectorController.UpdateAreaSelector();

        if (Input.GetKeyUp(KeyCode.Return))
        {
            if (AreaSelectorController.col == 0)
                MenuSetup(SpineMenu, AreaSelector, SmithState.SubMoveSelection, "...and select an how you wish to draw!", true);
            else
                MenuSetup(EdgeMenu, AreaSelector, SmithState.SubMoveSelection, "...and select an how you wish to draw!", true);
        }

        if (Input.GetKeyUp(KeyCode.Escape))
            MenuSetup(MoveMenu, AreaSelector, SmithState.MoveSelection, "Ok... What will you do?");
    }

}
