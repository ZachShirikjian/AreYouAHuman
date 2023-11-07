using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    //VARIABLES//
    public int timer = 90;    //The # of time (in seconds) a level is.
    private float minutes;
    private float seconds; 
    public TextMeshProUGUI interactText; //text that appears on screen whenever players can pickup an object
    public List<GameObject> playerInventory = new List<GameObject>();
    public TextMeshProUGUI currentStateText;
    //REFERENCES//
    public TextMeshProUGUI timerText; //References the timer text to display how much time is left 
    // Start is called before the first frame update
    //Make sure to initialize (reset) variables EVERY TIME a scene is loaded.
    void Start()
    {
        timer = 90;
        minutes = Mathf.Floor(timer / 60);
        seconds =  timer - minutes * 60;
        timerText.text = minutes.ToString() + ":" + seconds.ToString();
        StopAllCoroutines();
        StartCoroutine(GameTimer());
        interactText.text = "";
        currentStateText.text = "";
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
            timerText.text = minutes.ToString() + ":" + seconds.ToString();
        }
        Debug.Log("Call CheckPose() method.");
        currentStateText.text = "TIME'S UP!";
    }
}
