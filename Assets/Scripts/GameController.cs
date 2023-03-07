using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartGame()
    {
        //Time.timeScale = 1;
        //PlayerController.hasCarKey = false;
        //PlayerController.hasCityKey1 = false;
        //PlayerController.hasCityKey2 = false;
        //PlayerController.hasCityKey3 = false;
        //PlayerController.instance.hasPotion = false;
        //PlayerController.level0Complete = false;
        //SceneManager.LoadScene(0);
        //PlayerData.instance.ResetData();
        print("RESTART");
    }

    public void ReturnHome()
    {
        Time.timeScale = 1;
        //PlayerController.hasCarKey = false;
        //PlayerController.hasCityKey1 = false;
        //PlayerController.hasCityKey2 = false;
        //PlayerController.hasCityKey3 = false;
        //PlayerController.instance.hasPotion = false;
        //PlayerController.level0Complete = false;
        SceneManager.LoadScene(0);
        PlayerData.instance.ResetData();
    }

    //Method to quiet the game
    public void QuitGame()
    {
        //Close the application
        Application.Quit();
    }
}
