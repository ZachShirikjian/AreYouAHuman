using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISFX : MonoBehaviour
{

    //REFERENCE TO AUDIO STUFF//
    public AudioSource sfxSource;
    public AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Called on the PointerEnter EventTrigger
    public void PlayHover()
    {
        sfxSource.PlayOneShot(audioManager.uiHover);
    }

    //Called on the PointerDown EventTrigger
    public void PlayClick()
    {
        sfxSource.PlayOneShot(audioManager.uiClick);
    }
}
