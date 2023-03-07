using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    private CameraController cam;
    private Rigidbody rb;
    private AudioController audioController;
    private Animator animator;
    private GameObject items;

    public LayerMask groundMask;
    public GameObject pauseMenu;
    public TextMeshProUGUI pointsUIText, winStatsUIText;
    public HealthBar healthBar;
    public GameEnding gameEnding;

    public int maxHealth;
    public float moveSpeed = 10.0f;
    public float jumpForce = 5.5f;
    public bool hasAllItems;
    public static int points = 0;

    static int health;
    float x, z;
    bool grounded = true;
    bool menuUp = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this; // Set the Singleton
        }
        else
        {
            Debug.LogError("Player.Awake() - Attempted to assign second Player.S!");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //Variable assignment
        cam = GetComponent<CameraController>();
        rb = GetComponentInChildren<Rigidbody>();
        animator = GetComponent<Animator>();

        //Make cursor locked to screen
        Cursor.lockState = CursorLockMode.Locked;

        //Set player data
        maxHealth = PlayerData.instance.maxHealth;
        points = PlayerData.instance.points;
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(health);

        //Set points UI text
        pointsUIText.text = "Points: " + points.ToString();

        //Assign audio controller
        audioController = GameObject.Find("AudioController").GetComponent<AudioController>();

        //Assign items
        items = GameObject.Find("Items");

        //Unfreeze time
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //Get the keyboard's axis for movement
        x = Input.GetAxis("Horizontal");  //To move left and right
        z = Input.GetAxis("Vertical");    //To move foward and backward

        //If player is walking, show animation
        bool hasHorizontalInput = !Mathf.Approximately(x, 0f);
        bool hasVerticalInput = !Mathf.Approximately(z, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        animator.SetBool("isWalking", isWalking);
        audioController.PlayerMovementAudio(isWalking);

        //If press SpaceBar, player jumps
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        //If press P, show pause menu
        if (Input.GetKeyDown(KeyCode.P))
        {
            ShowPauseMenu();
        }

        //If player has all items
        if (hasAllItems)
        {
            //Play home music and show win screen fade
            audioController.HomeBackgroundAudio(true);
            gameEnding.WinScreenFade();
        }
    }

    private void FixedUpdate()
    {
        //Store the players movement direction
        Vector3 move = transform.right * x + transform.forward * z;

        //Multiply the movement direction vector by the movement speed
        move *= moveSpeed;

        //Set the y value of the direction equal to the rigidbody's y value
        //For physics calculations such as gravity
        move.y = rb.velocity.y;

        //Set the direction
        rb.velocity = move;
    }

    //Method to show pause menu
    public void ShowPauseMenu()
    {
        if (menuUp)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
            //Lock the mouse cursor to the center of the game window
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
            //Lock the mouse cursor to the center of the game window
            Cursor.lockState = CursorLockMode.None;
        }

        menuUp = !menuUp;
        cam.togglePause();
    }

    //Method to add points
    public void AddPoints(int pointsEarned)
    {
        //Add points earned to total points
        points += pointsEarned;
        PlayerData.instance.points = points;

        //Update points UI
        pointsUIText.text = "Points: " + points.ToString();

        //If all items are collected
        if (CheckAllItemsCollected() == true)
        {
            //Update score UI text
            winStatsUIText.text = "Score: " + points.ToString();
            pointsUIText.gameObject.SetActive(false);
            hasAllItems = true;
        }
    }

    //Method to check if player has collected all items
    public bool CheckAllItemsCollected()
    {
        //For each child in Items GO
        for (int i = 0; i < items.transform.childCount; i++)
        {
            //If an item is active, return false (not all items have been collected)
            if (items.transform.GetChild(i).gameObject.activeInHierarchy)
            {
                return false;
            }
        }

        //All items have been collected
        return true;
    }

    //Method to allow player to jump
    void Jump()
    {
        //Check is player is on the ground
        grounded = Physics.Raycast(transform.position + Vector3.up, Vector3.down, 1f, groundMask);

        //If player is on the ground
        if (grounded)
        {
            //Add jump force
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    //Method to allow player to take damage
    public void TakeDamage(int damage)
    {
        //If player health is above 0
        if (health > 0)
        {
            //Player loses health and play damage audio
            health -= damage;
            healthBar.SetHealth(health);
            audioController.PlayerDamageAudio();
        }

        //If player's health is under or equal to 0
        if (health <= 0)
        {
            //Set health to 0 (in case of negative)
            health = 0;
            healthBar.SetHealth(health);

            //Reset player's data 
            PlayerData.instance.ResetData();

            //Play dead animation
            animator.SetTrigger("isDead");
        }
    }

    //Checks if player collide with another collider
    private void OnTriggerEnter(Collider other)
    {
        //If the collider is an item
        if (other.CompareTag("Item"))
        {
            //Play pick up item audio
            audioController.PickupItemAudio();

            //Set item to inactive
            other.gameObject.SetActive(false);

            //Add points
            AddPoints(5);
        }
    }
}
