using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    //VARIABLES//
    public bool timerRunning = true; //set to false if player submits their props before timer runs out
    public int timer = 60;    //The # of time (in seconds) a level is.
    private float minutes;
    private float seconds; 
    public GameObject interactPrompt;
    public TextMeshProUGUI interactText; //text that appears on screen whenever players can pickup an object

    //INVENTORY//
    public List<GameObject> playerInventory = new List<GameObject>(); //INGAME player inventory which holds items in player inventory
    public GameObject inventory; //Reference to Player's Inventory UI, which doesn't get shown at PoseCheck screen
    public int maxInventoryItems;        //THE MAX AMOUNT OF ITEMS A PLAYER CAN HOLD IN A LEVEL (CHANGES EVERY LEVEL)
    public int itemsCollected = 0; 
    public GameObject correctItem; //1st Correct Item for the Pose 
    public GameObject correctItem2; //2nd Correct Item for the Pose 
     public GameObject correctItem3; //3rd Correct Item for the Pose 

    // public InventoryItem[] iventoryItems = new InventoryItem[3]; //UI player inventory
    public TextMeshProUGUI currentStateText;
    
    //REFERENCES//
    public TextMeshProUGUI timerText; //References the timer text to display how much time is left 
    private GameObject player; //Reference to Player GameObject

    //PAUSE MENU//
    private bool paused = false;
    public GameObject pauseMenu; //Reference to Pause Menu for pausing the game 

    //POSE CHECK//
    public GameObject posePanel; //Reference to the Pose Panel that appears at the end of the level 
    public Image playerPose;
    public GameObject[] inventorySprites = new GameObject[3];
    public Image boxIcon; //displays checkmark or X if captcha is correct or not
    public Sprite checkmark; //checkmark if player passed captcha
    public Sprite xMark; //X symbol if player failed captcha
    public GameObject submitButton;
    public GameObject continueButton; //reference to continue button, which is only active when the player correctly got the pose right 

    //Reference to current scene
    private int currentScene;

    //Reference to Audio stuff
    public AudioManager audioManager;
    public AudioSource sfxSource;
    public AudioSource musicSource;
    // Start is called before the first frame update
    //Make sure to initialize (reset) variables EVERY TIME a scene is loaded.
    void Start()
    {
        timerRunning = true;
        submitButton.SetActive(false);
        paused = false;
        itemsCollected = 0;
        // timer = 60;
        minutes = Mathf.Floor(timer / 60);
        seconds = timer - minutes * 60;
        timerText.text = minutes.ToString() + ":0" + seconds.ToString();
        StopAllCoroutines();
        StartCoroutine(GameTimer());
        interactText.text = "";
        interactPrompt.SetActive(false);
        currentStateText.text = "";
        posePanel.SetActive(false);
        player = GameObject.Find("Zort");
        player.SetActive(true);
        boxIcon.sprite = null;
        inventory.SetActive(true);
        continueButton.SetActive(false);
        pauseMenu.SetActive(false);
        currentScene = SceneManager.GetActiveScene().buildIndex;
        if(currentScene == 1)
        {
            maxInventoryItems = 3;
        }
        else if(currentScene == 2)
        {
            maxInventoryItems = 4;
        }
        for(int i = 0; i < inventorySprites.Length; i++)
        {
            inventorySprites[i].SetActive(false);
        }
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

    //Stops timer if time runs out OR if players feel ready to compare the Pose
    public void StopTimer()
    {
        submitButton.SetActive(false);
        timerRunning = false;
        Debug.Log("Call CheckPose() method.");
        player.SetActive(false);
        currentStateText.text = "FINISH!";
        sfxSource.PlayOneShot(audioManager.timesUp);
        musicSource.Stop();
        Invoke("ComparePose", 3.0f);
    }

    //The timer used for each level in the game, starting at 90 seconds.
    //When the timer hits 0, call the CheckPose() method to see if the player
    //Got every correct item in the level.
    public IEnumerator GameTimer()
    {
        for(int i = timer; i > 0; i--)
        {
            if(timerRunning == true)
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
                if(seconds <= 0)
                {
                    StopTimer();
                }
            }
            if(timerRunning == false)
            {
                Debug.Log("STOP TIMER");
                break;
            }
        }
    }

    public void ComparePose()
    {
         inventory.SetActive(false);
         posePanel.SetActive(true);
        //  PrefabUtility.GetPrefabType(correctItem);  
        if(playerInventory.Contains(correctItem))
        {
            Debug.Log("GOT ITEM 1");
            inventorySprites[0].SetActive(true);
            if(playerInventory.Contains(correctItem2) && playerInventory.Contains(correctItem3))
            {
                continueButton.SetActive(true);
                sfxSource.PlayOneShot(audioManager.correctPose);
                boxIcon.sprite = checkmark;
            }
        }
        if(playerInventory.Contains(correctItem2))
        {
            Debug.Log("GOT ITEM 2");
            inventorySprites[1].SetActive(true);
        }
        if(playerInventory.Contains(correctItem3))
        {   
            Debug.Log("GOT ITEM 3");
            inventorySprites[2].SetActive(true);
        }

        else
        {
            Debug.Log("NO ITEMS");
            boxIcon.sprite = xMark;
            sfxSource.PlayOneShot(audioManager.wrongPose);
        }
    }
}
