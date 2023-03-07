using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    private Transform player;
    public GameEnding gameEnding;
    private AudioController audioController;

    bool m_IsPlayerInRange;

    private void Start()
    {
        //player = GameObject.Find("Player").transform;
        audioController = GameObject.Find("AudioController").GetComponent<AudioController>();
    }

    //If player collides with collider, then player is in range
    void OnTriggerEnter(Collider other)
    {
        //print("HIT");
        if (other.gameObject.CompareTag("Player"))
        {
            print("PLAYER");
            player = other.transform;
            m_IsPlayerInRange = true;
            
        }
    }

    //If player doesn't collide with collider, then player is not in range
    //void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Player"))
    //    {
    //        m_IsPlayerInRange = false;
    //    }
    //}

    void Update()
    {
        //If player is in range
        if (m_IsPlayerInRange)
        {
            audioController.GameOverAudio();
            PlayerData.instance.ResetData();
            gameEnding.CaughtScreenFade();
            ////Calaculate direction 
            //Vector3 direction = player.position - transform.position + Vector3.up;

            ////Create ray 
            //Ray ray = new Ray(transform.position, direction);

            ////Out parameter
            //RaycastHit raycastHit;

            ////If the raycast hits player, then player is caught
            //if (Physics.Raycast(ray, out raycastHit))
            //{
            //    if (raycastHit.collider.transform == player)
            //    {
            //        //print("RAY");
            //        gameEnding.ShowLevel0WinScreenFade();
            //    }
            //}
        }
    }
}
