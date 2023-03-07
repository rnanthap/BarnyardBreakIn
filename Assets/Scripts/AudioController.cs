using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Class to manage audio
public class AudioController : MonoBehaviour
{
    // Declaring variables to reference audio sources
    public AudioSource homeBackgroundAudio;
    public AudioSource playerMovement;
    public AudioSource playerDamage;
    public AudioSource itemPickup;
    public AudioSource gameOver;

    //Plays home background music
    public void HomeBackgroundAudio(bool isPlaying)
    {
        if (isPlaying)
        {
            if (!homeBackgroundAudio.isPlaying)
            {
                homeBackgroundAudio.Play();
            }
        }
        else
        {
            homeBackgroundAudio.Stop();
        }
    }

    //If the player is moving the walking sound is played
    public void PlayerMovementAudio(bool isMoving)
    {
        if (isMoving)
        {
            if (!playerMovement.isPlaying)
            {
                playerMovement.Play();
            }
        }
        else
        {
            playerMovement.Stop();
        }
    }

    //Plays the player hurt audio as well as the zombie attack sound
    public void PlayerDamageAudio()
    {
        if (playerDamage.isPlaying)
        {
            playerDamage.Stop();
        }

        playerDamage.Play();
    }

    //Plays audio for item pickup
    public void PickupItemAudio()
    {
        if (!itemPickup.isPlaying)
        {
            itemPickup.Play();
        }
    }

    // Plays audio for when player is caught
    public void GameOverAudio()
    {
        if (!gameOver.isPlaying)
        {
            gameOver.Play();
        }
    }
}
