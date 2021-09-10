using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopSoundOnDeath : MonoBehaviour
{
    private AudioSource gameSound;
    public PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        gameSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerControllerScript.gameOver)
        {
            gameSound.Stop();
        }
    }
}
