using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Class to handle main manu
public class MainMenu : MonoBehaviour
{
    //Reference audio controller
    private AudioController audioController;

    private void Start()
    {
        //Assign audio controller
        audioController = GameObject.Find("AudioController").GetComponent<AudioController>();

        //Start to play music
        audioController.HomeBackgroundAudio(true);
    }

    //Method to start the game
    public void StartGame()
    {
        //Loads the first level
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //Method to quit game
    public void QuitGame()
    {
        //Close the application
        Application.Quit();
    }
}
