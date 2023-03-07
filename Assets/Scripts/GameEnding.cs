using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

//Class to handle game ending
public class GameEnding : MonoBehaviour
{
    //Used to fade completetion screen after game done
    public CanvasGroup caughtBackgroundImageCanvasGroup;

    public CanvasGroup winBackgroundImageCanvasGroup;

    //Used to handle fade effects
    //public float fadeDuration = 2.5f;
    //public float displayImageDuration = 1f;

    //Used to handle fade effects
    private float fadeDuration = 3f;
    private float displayImageDuration = 1f;

    private AudioController audioController;

    //Timer for fade effects
    float timer;

    private void Start()
    {
        //Assign the exit background
        //caughtBackgroundImageCanvasGroup = GameObject.FindObjectOfType<CanvasGroup>();

        audioController = GameObject.Find("AudioController").GetComponent<AudioController>();
    }

    void Update()
    {
        ////If player has potion, show win screen
        //if (PlayerController.instance.hasPotion)
        //{
        //    audioController.HomeBackgroundAudio(true);
        //    ShowLevel2WinScreenFade();
        //}

        ////If player is done level 1, show scene change screen
        //if (PlayerController.instance.level1Complete)
        //{
        //    audioController.PlayerMovementAudio(false);
        //    ShowLevel1WinScreenFade();
        //}
    }

    //Method when Player wins the game, fade out and show completion screen
    //public void ShowLevel0WinScreenFade()
    //{
    //    timer += Time.deltaTime;

    //    exitBackgroundImageCanvasGroup.alpha = timer / fadeDuration;

    //    if (timer > fadeDuration + displayImageDuration)
    //    {
    //        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    //    }
    //}

    public void CaughtScreenFade()
    {
        //timer += Time.deltaTime;
        Time.timeScale = 0;

        timer += Time.unscaledDeltaTime;
        caughtBackgroundImageCanvasGroup.alpha = timer / fadeDuration;
        if (timer > fadeDuration + displayImageDuration)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            //PlayerController.level0Complete = true;
        }
    }

    public void WinScreenFade()
    {

        Time.timeScale = 0;

        timer += Time.unscaledDeltaTime;
        //timer += Time.deltaTime;

        winBackgroundImageCanvasGroup.alpha = timer / fadeDuration;
        if (timer > fadeDuration + displayImageDuration)
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            //PlayerController.level0Complete = true;
            //Let the cursor show again
            Cursor.lockState = CursorLockMode.None;
        }
    }

    //Method when Player wins the game, fade out and show completion screen
    public void ShowLevel1WinScreenFade()
    {
        Time.timeScale = 0;

        timer += Time.unscaledDeltaTime;

        caughtBackgroundImageCanvasGroup.alpha = timer / fadeDuration;

        if (timer > fadeDuration + displayImageDuration)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    //Method when Player wins the game, fade out and show completion screen
    void ShowLevel2WinScreenFade()
    {
        timer += Time.deltaTime;

        caughtBackgroundImageCanvasGroup.alpha = timer / fadeDuration;

        if (timer > fadeDuration + displayImageDuration)
        {
            //Let the cursor show again
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
