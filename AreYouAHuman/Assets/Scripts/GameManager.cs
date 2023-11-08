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
    public List<GameObject> playerInventory = new List<GameObject>(); //INGAME player inventory

    // public InventoryItem[] iventoryItems = new InventoryItem[3]; //UI player inventory
    public TextMeshProUGUI currentStateText;
    
    //REFERENCES//
    public TextMeshProUGUI timerText; //References the timer text to display how much time is left 
    private GameObject player; //Reference to Player GameObject
    public GameObject inventory; //Reference to Player's Inventory, which doesn't get shown at PoseCheck screen

    //PAUSE MENU//
    private bool paused = false;
    public GameObject pauseMenu; //Reference to Pause Menu for pausing the game 

    //POSE CHECK//
    public GameObject posePanel; //Reference to the Pose Panel that appears at the end of the level 
    public Image playerPose;
    public Sprite[] poseImages = new Sprite[8];
    public Image boxIcon; //displays checkmark or X if captcha is correct or not
    public Sprite checkmark; //checkmark if player passed captcha
    public Sprite xMark; //X symbol if player failed captcha
    
    public GameObject continueButton; //reference to continue button, which is only active when the player correctly got the pose right 
    public int itemsCollected = 0; 

    // Start is called before the first frame update
    //Make sure to initialize (reset) variables EVERY TIME a scene is loaded.
    void Start()
    {
        paused = false;
        itemsCollected = 0;
        timer = 90;
        minutes = Mathf.Floor(timer / 60);
        seconds =  timer - minutes * 60;
        timerText.text = minutes.ToString() + ":" + seconds.ToString();
        StopAllCoroutines();
        StartCoroutine(GameTimer());
        interactText.text = "";
        currentStateText.text = "";
        posePanel.SetActive(false);
        player = GameObject.Find("Zort");
        player.SetActive(true);
        boxIcon.sprite = null;
        inventory.SetActive(true);
        continueButton.SetActive(false);
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P) && !paused)
        {
            PauseGame();
        }
    }

    //PAUSE MENU//
    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
    }

    public void UnpauseGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
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
        player.SetActive(false);
        currentStateText.text = "TIME'S UP!";
        yield return new WaitForSeconds(3f);
        ComparePose();
    }

    public void ComparePose()
    {
        inventory.SetActive(false);
         posePanel.SetActive(true);
         switch(itemsCollected)
         {
             case 1:
                 playerPose.sprite = poseImages[4];
                 boxIcon.sprite = xMark;
                 break;
             case 2:
                 playerPose.sprite = poseImages[2];
                 boxIcon.sprite = xMark;
                 break;
             case 3:
                 playerPose.sprite = poseImages[0];
                 boxIcon.sprite = checkmark;
                 continueButton.SetActive(true);
                 break;
            //  case 4: 
            //      playerPose.sprite = poseImages[3];
            //      boxIcon.sprite = xMark;
            //  case 5: 
            //      playerPose.sprite = poseImages[4];
            //      boxIcon.sprite = xMark;
            //  case 6: 
            //      playerPose.sprite = poseImages[5];
            //      boxIcon.sprite = xMark;
            //  case 7: 
            //      playerPose.sprite = poseImages[6];
            //      boxIcon.sprite = xMark;
         default:
             playerPose.sprite = poseImages[7];
             boxIcon.sprite = xMark;
             break;
         }
    }
}
