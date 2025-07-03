using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PoseMenuButtons : MonoBehaviour
{

    //VARIABLES//
    //The index of the current scene players are on 
    public int currentScene; 

    //Every time a new scene is loaded, make sure the currentScene index is = to the buildIndex of the scene
    void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
    }
    //Reloads the current level from the beginning 
    public void RestartLevel()
    {
        SceneManager.LoadScene(currentScene);
    }

    //Continues onto the next level, if the player got the pose correct
    //REMOVED BECAUSE OF THE LEVEL SELECT!
    //public void NextLevel()
    //{
   //     SceneManager.LoadScene(currentScene + 1);
   // }

    //Exits back to the Title Screen
    public void QuitGame()
    {
        SceneManager.LoadScene("_TitleScreen");
    }
}
