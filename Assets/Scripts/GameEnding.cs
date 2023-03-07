using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

//Class to handle game ending
public class GameEnding : MonoBehaviour
{
    //Used to fade screen when caught or win game
    public CanvasGroup caughtBackgroundImageCanvasGroup;
    public CanvasGroup winBackgroundImageCanvasGroup;

    //Used to handle fade effects
    private float fadeDuration = 3f;
    private float displayImageDuration = 1f;

    //Timer for fade effects
    float timer;

    //Displays caught screen fade
    public void CaughtScreenFade()
    {
        //Freeze time
        Time.timeScale = 0;

        //Keep track of time passed
        timer += Time.unscaledDeltaTime;

        //Create fade effect
        caughtBackgroundImageCanvasGroup.alpha = timer / fadeDuration;

        //Once fade is done
        if (timer > fadeDuration + displayImageDuration)
        {
            //Unfreeze time
            Time.timeScale = 1;

            //Reload the scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    //Displays win screen fade
    public void WinScreenFade()
    {
        //Freeze time
        Time.timeScale = 0;

        //Keep track of time passed
        timer += Time.unscaledDeltaTime;

        //Create fade effect
        winBackgroundImageCanvasGroup.alpha = timer / fadeDuration;

        //Once fade is done
        if (timer > fadeDuration + displayImageDuration)
        {
            //Let the cursor show again
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
