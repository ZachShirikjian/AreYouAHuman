using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TitleScreen : MonoBehaviour
{
    //REFERENCES//
    public GameObject creditsPanel; //Reference to the Credits panel GameObject in the TitleScreen
    public GameObject tutorialPanel; //Reference to the Tutorial panel GameObject in the TitleScreen

    // Start is called before the first frame update
    void Start()
    {
        creditsPanel.SetActive(false);
    }

    //Loads up the SampleScene when the StartButton is pressed.
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    //Opens the CreditsPanel in the TitleScreen
    public void OpenCredits()
    {
        creditsPanel.SetActive(true);
    }
    //Closes out of the CreditsPanel in the TitleScreen
    public void CloseCredits()
    {
        creditsPanel.SetActive(false);
    }

    //Opens the TutorialPanel in the TitleScreen
    public void OpenTutorial()
    {
        tutorialPanel.SetActive(true);
    }

    //Closes out of the TutorialPanel in the TitleScreen
    public void CloseTutorial()
    {
        tutorialPanel.SetActive(false);
    }
    //Exits out of the game (only works in Builds)
    public void QuitGame()
    {
        //Quits out of Play Mode if the Quit button is pressed 
        #if UNITY_EDITOR 
        UnityEditor.EditorApplication.isPlaying = false;

        #endif
        Application.Quit();
    }
}
