using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CutsceneDialogue : MonoBehaviour
{
    //VARIABLES//
    public int curPlace;
    public TextMeshProUGUI currentDialogue;
    public Image currentImage; 

    //REFERENCES//
    public Sprite[] cutsceneBG; 
    public Dialogue[] dialogue;
    public Animator dialogueAnim;
    public GameObject dialogueBox;
    // Start is called before the first frame update
    void Start()
    {
        curPlace = 0;
        currentImage.sprite = cutsceneBG[0];
        currentDialogue.text = dialogue[curPlace].zortText;
        dialogueAnim.SetTrigger("NewDialogue");
        dialogueBox.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ContinueDialogue()
    {
        //Play DialogueBox animation (eg Persona)
        //When clicking the Continue button, move to the next place in the cutsceneImage array and continue the dialogue
        curPlace++;
        if(curPlace < cutsceneBG.Length -1)
        {
            currentImage.sprite = cutsceneBG[curPlace];
            currentDialogue.text = dialogue[curPlace].zortText;
        }
        else if(curPlace >= cutsceneBG.Length -1)
        {
            dialogueBox.SetActive(false);
            currentImage.sprite = cutsceneBG[curPlace];
            currentDialogue.text = "";
            dialogueAnim.SetBool("EndDialogue",true);
        }
    }
}
