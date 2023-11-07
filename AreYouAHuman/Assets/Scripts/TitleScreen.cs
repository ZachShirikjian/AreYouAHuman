using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TitleScreen : MonoBehaviour
{
    //REFERENCES//
    public GameObject creditsPanel;

    // Start is called before the first frame update
    void Start()
    {
        creditsPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
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
    //Exits out of the game (only works in Builds)
    public void QuitGame()
    {
        Application.Quit();
    }
}
