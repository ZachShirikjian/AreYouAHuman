using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//This script is used to load the Scene of the button which the player clicks in the Level Select screen.
public class LevelSelectScript : MonoBehaviour
{
    //VARIABLES//
    //The current Page that is displayed on-screen.
    public int currentPage = 1;

    //REFERENCES//
    //The Number of Pages in the Level Select. Change this number as more pages get added.
    public int[] pages = new int[3];

    //In the Inspector for the UI button of your level:
    //Ensure that stageName is set to the name of the Scene you want to load! 
    //To load Office level, set stageName to be OfficeLevel.
    public void LoadStage(string stageName)
    {
        Debug.Log(stageName);
        SceneManager.LoadScene(stageName);
    }

    //Display the Previous Page in the Level Select List 
    public void DisplayPreviousPage()
    {

    }

    //Display the Next Page in the Level Select List.
    public void DisplayNextPage()
    {

    }
    //Quit the Level Select, and Return to the Title Select Screen.
    public void ReturnToTitle()
    {
        SceneManager.LoadScene("_TitleScreen");
    }
}
