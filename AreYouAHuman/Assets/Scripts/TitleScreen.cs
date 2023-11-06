using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TitleScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
    //Exits out of the game (only works in Builds)
    public void QuitGame()
    {
        Application.Quit();
    }
}
