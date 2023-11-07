using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    //VARIABLES//
    public int timer = 10;    //The # of time (in seconds) a level is.
    private float minutes;
    private float seconds; 
    public TextMeshProUGUI interactText; //text that appears on screen whenever players can pickup an object
    public List<GameObject> playerInventory = new List<GameObject>();
    public TextMeshProUGUI currentStateText;
    
    //REFERENCES//
    public TextMeshProUGUI timerText; //References the timer text to display how much time is left 
    public GameObject posePanel; //Reference to the Pose Panel that appears at the end of the level 
    public PlayerMovement player; //Reference to PlayerMovement script in the Player GameObject
    // Start is called before the first frame update
    //Make sure to initialize (reset) variables EVERY TIME a scene is loaded.
    void Start()
    {
        timer = 10;
        minutes = Mathf.Floor(timer / 60);
        seconds =  timer - minutes * 60;
        timerText.text = minutes.ToString() + ":" + seconds.ToString();
        StopAllCoroutines();
        StartCoroutine(GameTimer());
        interactText.text = "";
        currentStateText.text = "";
        posePanel.SetActive(false);
        player.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //The timer used for each level in the game, starting at 90 seconds.
    //When the timer hits 0, call the CheckPose() method to see if the player
    //Got every correct item in the level.
    public IEnumerator GameTimer()
    {
        for(int i = timer; i > 0; i--)
        {
            yield return new WaitForSeconds(1f);
            // Debug.Log(i);
            timer--;
            minutes = Mathf.Floor(timer / 60);
            seconds =  timer - minutes * 60;
            if(seconds >= 10)
            {
                timerText.text = minutes.ToString() + ":" + seconds.ToString();
            }
            if(seconds < 10)
            {
                timerText.text = minutes.ToString() + ":0" + seconds.ToString();
            }
        }
        Debug.Log("Call CheckPose() method.");
        player.enabled = false;
        currentStateText.text = "TIME'S UP!";
        yield return new WaitForSeconds(3f);
        posePanel.SetActive(true);
    }
}
