using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopSoundOnDeathX : MonoBehaviour
{
    private AudioSource gameSound;
    public PlayerControllerX playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerControllerX>();
        gameSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // I want game audio to stop on game over
        if (playerControllerScript.gameOver)
        {
            gameSound.Stop();
        }
    }
}
