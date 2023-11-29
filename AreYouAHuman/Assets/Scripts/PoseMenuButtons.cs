using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PoseMenuButtons : MonoBehaviour
{
    //Reloads the current level from the beginning 
    public void RestartLevel()
    {
        SceneManager.LoadScene("SampleScene");
    }

    //Continues onto the next level, if the player got the pose correct
    public void NextLevel()
    {
        SceneManager.LoadScene("Cutscene");
    }

    //Exits back to the Title Screen
    public void QuitGame()
    {
        SceneManager.LoadScene("_TitleScreen");
    }
}
