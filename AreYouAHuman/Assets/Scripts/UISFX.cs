using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISFX : MonoBehaviour
{

    //REFERENCES//

    //The SFX AudioSource where SFX play from.
    public AudioSource sfxSource;

    //The AudioManager script which holds all the SFX Audio to play during gameplay.
    public AudioManager audioManager;

    //Called on the PointerEnter EventTrigger
    //Plays the UIHover SFX when hovering over a Button in a Menu.
    public void PlayHover()
    {
        sfxSource.PlayOneShot(audioManager.uiHover);
    }

    //Called on the PointerDown EventTrigger
    //Plays the Click SFX when clicking a Button in a Menu.
    public void PlayClick()
    {
        sfxSource.PlayOneShot(audioManager.uiClick);
    }
}
