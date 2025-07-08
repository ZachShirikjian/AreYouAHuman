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
    //Disables the Credits and Tutorial Panel when launching the Title Screen.
    void Start()
    {
        creditsPanel.SetActive(false);
        tutorialPanel.SetActive(false);
    }

    //Loads up the LevelSelectScreen scene when the StartButton is pressed.
    public void StartGame()
    {
        SceneManager.LoadScene("LevelSelectScreen");
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

    //Exits out of Are You Human? when the QUIT button is clicked.
    public void QuitGame()
    {
        //Exits Play Mode if QUIT is clicked during Play Mode (Editor).
        #if UNITY_EDITOR 
        UnityEditor.EditorApplication.isPlaying = false;

        //Closes the Game if QUIT is clicked in a Build of the game.
        #endif
        Application.Quit();
    }
}
