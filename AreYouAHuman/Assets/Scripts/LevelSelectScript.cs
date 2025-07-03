using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Linq;

//This script is used to load the Scene of the button which the player clicks in the Level Select screen.
public class LevelSelectScript : MonoBehaviour
{
    //VARIABLES//
    //The current index of the Page that is displayed on-screen. Computers start count from 0, not 1.
    public int currentPage = 0;

    //REFERENCES//
    //The Number of Pages in the Level Select. Add to the List in the Inspector as more Pages get added.
    public List<GameObject> pages = new List<GameObject>();

    //In the Inspector for the UI button of your level:
    //Ensure that stageName is set to the name of the Scene you want to load! 
    //To load Office level, set stageName to be OfficeLevel.

    private void Start()
    {
        //Ensure the currentPage displayed is Page 1. 
        currentPage = 0;
        pages[currentPage].SetActive(true);

        for(int i = 1; i < pages.Count; i++)
        {
            pages[i].SetActive(false);
        }
    }
    public void LoadStage(string stageName)
    {
        Debug.Log(stageName);
        SceneManager.LoadScene(stageName);
    }

    //Display the Previous Page in the Level Select List 
    public void DisplayPreviousPage()
    {
        //Get the currentPage number,
        //And make it invisible.
        pages[currentPage].SetActive(false);

        //Get the current Page number - 1 to get the Previous Page,
        //And make it visible.
        pages[currentPage - 1].SetActive(true);

        //Update the currentPage number to match the correct Page Number Displayed.
        currentPage = currentPage - 1;
    }

    //Display the Next Page in the Level Select List.
    public void DisplayNextPage()
    {
        //Get the currentPage number,
        //And make it invisible.
        pages[currentPage].SetActive(false);

        //Get the current Page number - 1 to get the Previous Page,
        //And make it visible.

        //To Prevent an IndexOutOfBoundsException, check to make sure the next page is still within the Pages List.
        if(currentPage + 1 <= pages.Count)
        {
            pages[currentPage + 1].SetActive(true);
        }

        //Update the currentPage number to match the correct Page Number Displayed.
        currentPage = currentPage + 1;
    }

    //Quit the Level Select, and Return to the Title Select Screen.
    public void ReturnToTitle()
    {
        SceneManager.LoadScene("_TitleScreen");
    }
}
