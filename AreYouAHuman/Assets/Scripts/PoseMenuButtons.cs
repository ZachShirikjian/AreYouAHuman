using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PoseMenuButtons : MonoBehaviour
{

    //VARIABLES//
    //The index of the current scene players are on 
    public string currentScene; 

    //Every time a new scene is loaded, make sure the currentScene is the Scene's name.
    void Start()
    {
        currentScene = SceneManager.GetActiveScene().name;
    }
    //Reloads the current level from the beginning 
    public void RestartLevel()
    {
        SceneManager.LoadScene(currentScene);
    }

    //Exits back to the Title Screen
    public void QuitGame()
    {
        SceneManager.LoadScene("_TitleScreen");
    }
}
