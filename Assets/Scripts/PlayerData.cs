using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class to store Player Data
public class PlayerData : MonoBehaviour
{
    //Player data instance
    public static PlayerData instance;

    //Player data properties
    public int maxHealth = 100;
    public int points = 0;

    void Awake()
    {
        //Singleton
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    //Method to reset player's data
    public void ResetData()
    {
        maxHealth = 100;
        points = 0;
    }
}
