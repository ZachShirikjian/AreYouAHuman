using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//This script is used to load the Are You Human? level assigned to the button which the player clicks. 
public class LevelSelectScript : MonoBehaviour
{

    //In the Inspector for the UI button of your level:
    //Ensure that stageName is set to the name of the Scene you want to load! 
    //To load Office level, set stageName to be OfficeLevel.
    public void LoadStage(string stageName)
    {
        Debug.Log(stageName);
        SceneManager.LoadScene(stageName);
    }
}
