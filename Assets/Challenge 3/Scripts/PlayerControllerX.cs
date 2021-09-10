using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public bool gameOver;

    public float floatForce;
    private float gravityModifier = 1f;
    private Rigidbody playerRb;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;
    public AudioClip boingSound;

    private float topBound = 13.0f;
    private float gameCeiling = 15.5f;


    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= gravityModifier;
        playerRb = GetComponent<Rigidbody>();
        playerAudio = GetComponent<AudioSource>();

        // Apply a small upward force at the start of the game
        playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // if player tries to go beyond a certain ceiling, reset the position
        if (playerRb.position.y > gameCeiling)
        {

            playerRb.position = new Vector3(playerRb.position.x, gameCeiling, playerRb.position.z);

        }
        
        // if player goes beyond a certain height, add a downward force to attenuate the player down
        else if (playerRb.position.y >= topBound)
        {

            playerRb.AddForce(Vector3.down * playerRb.position.y / topBound, ForceMode.Force);

        }

        // Allow the player to raise the balloon when space bar is pressed and player is low enough
        else if (Input.GetKey(KeyCode.Space) && !gameOver)
        {

            playerRb.AddForce(Vector3.up * floatForce, ForceMode.Force);

        }
    }

    private void OnCollisionEnter(Collision other)
    {
        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
        } 

        // if player collides with money, fireworks
        else if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);

        }

        // apply a small upward force when colliding with the ground and play a sound
        else if (other.gameObject.CompareTag("Ground") && !gameOver)
        {
            playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);
            playerAudio.PlayOneShot(boingSound, 1.0f);
        }

    }

}
