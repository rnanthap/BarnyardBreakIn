using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class to check if player is caught by police
public class Observer : MonoBehaviour
{
    //Reference the player and audio controller
    private Transform player;
    private AudioController audioController;

    //Reference to game ending
    public GameEnding gameEnding;

    //Checks if player is in range of police
    bool isPlayerInRange;

    private void Start()
    {
        //Assign audio controller
        audioController = GameObject.Find("AudioController").GetComponent<AudioController>();
    }

    //If player collides with collider, then player is in range
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = other.transform;
            isPlayerInRange = true;
        }
    }

    void Update()
    {
        //If player is in range
        if (isPlayerInRange)
        {
            //Play game over music 
            audioController.GameOverAudio();

            //Reset player data 
            PlayerData.instance.ResetData();

            //Display caught screen
            gameEnding.CaughtScreenFade();
        }
    }
}
