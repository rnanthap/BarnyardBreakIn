using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    private AudioController audioController;
    public LayerMask playerMask;
    public GameObject pickupInstructionsText;
    public float pickUpRange = 2f;
    bool playerInRange = false;

    // Start is called before the first frame update
    void Start()
    {
        audioController = GameObject.Find("AudioController").GetComponent<AudioController>();

    }

    // Update is called once per frame
    void Update()
    {
        CheckPickUp();
    }

    private void CheckPickUp()
    {
        playerInRange = Physics.CheckSphere(transform.position, pickUpRange, playerMask);

        if (playerInRange)
        {
            pickupInstructionsText.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                // PlayerController.instance.PickUpWeapon(thisWeapon);

                //transform.Find("StarEffect").gameObject.SetActive(false);

                //ammoCounter.setMag(curAmmo);
                gameObject.SetActive(false);
                pickupInstructionsText.SetActive(false);
            }
        }
        else
        {
            //pickupInstructionsText.SetActive(false);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, pickUpRange);
    }
}
