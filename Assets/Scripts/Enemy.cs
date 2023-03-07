using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    //Stores the enemy's last position
    private Vector3 lastPosition;

    //Variable assignment for inspector
    public NavMeshAgent agent;
    public GameObject playerObj;
    public LayerMask playerMask;
    public AudioSource animalAudio; //The corresponding animals have audio souce component attached to them

    //Base stats, corresponding animals have range, speed and strength assigned in inspector
    public float detectRange = 10f;
    public float attackRange = 1f;
    public float attackSpeed = 2f;
    public int strength = 5;

    //Timer before enemy can attack again
    float attackTimer = 0;

    //Checks is player is in detect or attack range
    bool inDetectRange, inAttackRange;


    // Start is called before the first frame update
    public virtual void Start()
    {
        //Assign player GO and get player's last position
        playerObj = GameObject.Find("Player");
        lastPosition = gameObject.transform.position;

        //Assign audio controller
        animalAudio = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        //Check if play is in detect or attack range
        inDetectRange = Physics.CheckSphere(transform.position, detectRange, playerMask);
        inAttackRange = Physics.CheckSphere(transform.position, attackRange, playerMask);

        attackTimer += Time.deltaTime;

        //Chase player if is in range
        if (inDetectRange) Chase();

        //Assign last position
        lastPosition = gameObject.transform.position;

        //If player is in attack range and enemy can attack again
        if (inAttackRange && attackTimer >= attackSpeed) Attack();
    }

    //Method for animal to attack player
    public virtual void Attack()
    {
        //Reset attack timer
        attackTimer = 0;

        //Play animal audio
        if (animalAudio.isPlaying)
        {
            animalAudio.Stop();
        }

        animalAudio.Play();

        //Have player take damage
        PlayerController.instance.TakeDamage(strength);
    }

    //Method to chase player
    public virtual void Chase()
    {
        agent.SetDestination(playerObj.transform.position);
    }

    //Draws both attack and detect range on editor
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectRange);
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
