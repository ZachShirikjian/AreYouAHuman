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
    public int maxInventoryItems; //THE MAX AMOUNT OF ITEMS A PLAYER CAN HOLD IN A LEVEL (CHANGES EVERY LEVEL)
    public int itemsCollected = 0; //The amount of items players currently have in their Inventory.

    public GameObject[] correctItems;     //A list of all the Correct Props needed to complete a Level. 
    public TextMeshProUGUI currentStateText; //Displays FINISH! when time runs out or when players submit their chosen Props. 
    
    //REFERENCES//
    public TextMeshProUGUI timerText; //References the timer text to display how much time is left 
    private GameObject player; //Reference to Player GameObject

    //PAUSE MENU//
    private bool paused = false;
    public GameObject pauseMenu; //Reference to Pause Menu for pausing the game 

    //POSE CHECK//
    public GameObject posePanel; //Reference to the Pose Panel that appears at the end of the level 
    public Image playerPose;

    //List of all the Position sprites where Props can go when checking Poses (Head, Torso, Hand, Pants).
    public GameObject[] inventorySprites = new GameObject[4];
    public Image boxIcon; //Displays checkmark or X if captcha is correct or not
    public Sprite checkmark; //Checkmark if player passed captcha
    public Sprite xMark; //X symbol if player failed captcha
    public GameObject submitButton;
    public GameObject continueButton; //Reference to continue button, which is only active when the player correctly got the pose right 

    //References the Current Scene in the game. 
    private int currentScene;

    //AUDIO REFERENCES//
    public AudioManager audioManager; //The AudioManager script, which holds all the SFX audio used during gameplay. Attached to the AudioManager GameObject.
    public AudioSource sfxSource; //The SFX AudioSource, which plays a particular AudioClip from the audioManager GameObject.
    public AudioSource musicSource; //The Music AudioSource, which plays the music attached to the Clip property in the Inspector. 
    
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
        Time.timeScale = 1f;

        //Increases the Max Inventory Items you can carry depending on the Level you're currently on. 

        // //Level 1
        // if(currentScene == 1) 
        // {
        //     maxInventoryItems = 3;
        // }

        // //Level 2
        // else if(currentScene == 2)
        // {
        //     maxInventoryItems = 4;
        // }

        //Disable all the InventorySprites before they are used in the ComparePose() method.
        for(int i = 0; i < inventorySprites.Length; i++)
        {
            inventorySprites[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

        //Pauses the game after pressing the P key. 
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

    //Resumes the game and unpauses it if the RESUME button is clicked in the Pause Menu.

    public void UnpauseGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
    }

    //Stops the timer once the Time runs out or when players got enough Props and are ready to check their Pose.
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
                if(seconds > 10)
                {
                    timerText.text = minutes.ToString() + ":" + seconds.ToString();
                }
                if(seconds == 10)
                {
                    timerText.text = minutes.ToString() + ":" + seconds.ToString();
                    sfxSource.PlayOneShot(audioManager.tenSeconds);
                }
                if(seconds < 10)
                {
                    timerText.text = minutes.ToString() + ":0" + seconds.ToString();
                    sfxSource.PlayOneShot(audioManager.tenSeconds);
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

    //When the time runs out, or when the player collects the maximum amount of props and clicks the Submit button,
    //Check to see if the Player got all the correct Props by comparing their Pose to the Example one in the Level.

    public void ComparePose()
    {
         inventory.SetActive(false);
         posePanel.SetActive(true);

        //The total amount of correct items that players have collected.
        int totalItems = 0; 

        for(int i = 0; i < playerInventory.Count; i++)
        {
            // inventorySprites[i].GetComponent<Image>().sprite = playerInventory[]
            Debug.Log(playerInventory[i].GetComponent<InventoryItem>().itemPosition);
             switch(playerInventory[i].GetComponent<InventoryItem>().itemPosition)
               {
                   case Position.Head:
                       inventorySprites[0].SetActive(true);
                       inventorySprites[0].GetComponent<Image>().sprite = playerInventory[i].GetComponent<InventoryItem>().poseSprite;
                       break;
                   case Position.Torso:
                        inventorySprites[1].SetActive(true);
                        inventorySprites[1].GetComponent<Image>().sprite = playerInventory[i].GetComponent<InventoryItem>().poseSprite;
                      break;
                   case Position.Accessory:
                       inventorySprites[2].SetActive(true);
                       inventorySprites[2].GetComponent<Image>().sprite = playerInventory[i].GetComponent<InventoryItem>().poseSprite;
                    break;
                  case Position.Pants:
                      inventorySprites[3].SetActive(true);
                       inventorySprites[3].GetComponent<Image>().sprite = playerInventory[i].GetComponent<InventoryItem>().poseSprite;
                    break;
                  default:
                 break;
               }

            if(playerInventory.Contains(correctItems[i]))
            {
                totalItems++;
            }
            else if(playerInventory.Contains(correctItems[i]) == false)
            {
                Debug.Log("WRONG!");
            }
        }

        //If the total number of correct items players got is equal or more than the correctItems list,
        //Players passed the test, so they can play the next level. 
        //Enable the Continue button and play the CorrectPose SFX.
        if(totalItems == correctItems.Length)
        {
                continueButton.SetActive(true);
                sfxSource.PlayOneShot(audioManager.correctPose);
                boxIcon.sprite = checkmark;
        }

        //If the total number of correct items players got is less than the amount they were supposed to get,
        //Players failed the test, so they have to retry the current level.
        else if(totalItems < correctItems.Length)
        {
                continueButton.SetActive(false);
                boxIcon.sprite = xMark;
                sfxSource.PlayOneShot(audioManager.wrongPose);
        }
}
}
