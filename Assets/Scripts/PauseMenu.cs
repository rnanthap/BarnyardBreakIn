using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Class to handle Pause Menu behavior
public class PauseMenu : MonoBehaviour
{
    //Method to restart the game
    public void RestartGame()
    {
        //Unfreeze time
        Time.timeScale = 1;

        //Reset player data
        PlayerData.instance.ResetData();

        //Load Main Menu
        SceneManager.LoadScene(0);
    }

    //Method to quit the game
    public void QuitGame()
    {
        //Close the application
        Application.Quit();
    }
}
