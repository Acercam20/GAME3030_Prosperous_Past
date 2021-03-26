using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //Obtained
    public AudioClip UIButtonPress;
    public AudioClip puzzleComplete;
    public AudioClip puzzleFailed;
    public AudioClip pauseSound;
    public AudioClip rockCollision;
    public AudioClip footstepsOnGrass;
    public AudioClip footstepsOnStone;
    public AudioClip tetraButtonPress;
    public AudioClip activateTotem;
    public AudioClip deactivateTotem;
    public AudioClip platformLowering;
    public AudioClip playerLandingGrass;
    public AudioClip playerLandingStone;
    public AudioClip woodenWallCollapse;
    public AudioClip endGameVictory;
    //To Obtain
    public AudioClip doorOpening;
    public AudioClip ambientMusic;
    public AudioClip MainMenuMusic;


    public void PlaySound(AudioClip a)
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(a);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
