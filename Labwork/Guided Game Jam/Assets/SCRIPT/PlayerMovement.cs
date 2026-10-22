using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class player_movement : MonoBehaviour
{
    public float horizontalSpeed;
    public float verticalSpeed;
    Rigidbody2D rb;
    float xInput;
    float yInput;
    public GameObject bullet_prefab;
    public Transform FirePos; //Determines the location where bullets come from, relative to the player 
    public float bulletSpeed;
    private bool canFire; //Checks to see if the bullet cooldown has depleted before allowing any more bullets to fire
    private float fireCooldown = 0.3f; //Forces the player to wait 0.3 seconds between firing bullets
    private float sinceFire = 0f;
    public Animator animations;
    public InputActionReference move;
    public InputActionReference attack;
    public InputActionReference restart;
    public InputActionReference pause;
    public InputActionReference menu;
    public InputActionReference close; //Closing the pause menu

    private Vector2 _moveDirection;
    public GameObject pauseMenu;
    public GameObject settingsMenu;
    public GameObject buttonDisplay;
    bool paused;
    bool menuOpen;



    void Awake() => rb = GetComponent<Rigidbody2D>();


    void Start()
    {
        canFire = true; //Player is able to shoot the frame the game starts
        paused = false; //starts the game unpaused
        menuOpen = false; //starts the game with the settings menu closed
        Debug.Log("Player starting");
    }

    // Update is called once per frame
    void Update()
    {
        if (paused == true)
        {
            Debug.Log("Game Paused");
            pauseMenu.SetActive(true);
            buttonDisplay.SetActive(false);
            Time.timeScale = 0;
        }
        else
        {
            Debug.Log("Game Unpaused");
            pauseMenu.SetActive(false);
            buttonDisplay.SetActive(true);
            Time.timeScale = 1;
        }
        if (menuOpen == true)
        {
            Debug.Log("Menu Open");
            settingsMenu.SetActive(true);
            buttonDisplay.SetActive(false);
            Time.timeScale = 0;
        }
        else
        {
            Debug.Log("Menu Closed");
            settingsMenu.SetActive(false);
            buttonDisplay.SetActive(true);
            Time.timeScale = 1;
        }
        if (attack.action.triggered)
        {
            Debug.Log("Fire button pressed");
            if (canFire == true)
            {
                canFire = false;
                sinceFire = 0f;
                GameObject bullet = Instantiate(bullet_prefab, FirePos.position, FirePos.rotation); //Creates a bullet at the attached fire location
                rb = gameObject.GetComponent<Rigidbody2D>();
                rb.AddForce(FirePos.right * bulletSpeed * Time.deltaTime, ForceMode2D.Impulse); //Makes the bullet move to the right of the screen at the set speed
                Debug.Log("Bullet firing");
            }
        }
        if (canFire == false)
        {
            Debug.Log("Can't fire");
            // Timer setup using Time.deltaTime code is based on code from the unity documentation on Time.deltaTime
            sinceFire += Time.deltaTime;
            if (sinceFire >= fireCooldown)
            {
                canFire = true;
            }
        }
        _moveDirection = move.action.ReadValue<Vector2>();
        if (restart.action.triggered)
        {
            Debug.Log("Level resetting");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //Reloads the game when restart button is pressed
        }
        if (pause.action.triggered)
        {
            if (paused == false)
            {
                Debug.Log("Game Pausing");
                paused = true;
            }
            else
            {
                Debug.Log("Game Unpausing");
                paused = false;
            }
        }
        if (menu.action.triggered)
        {
            Debug.Log("Menu Opening");
            menuOpen = true;
        }
        if (close.action.triggered)
        {
            Debug.Log("Menu Closing");
            menuOpen = false;
        }
    }

    void FixedUpdate()
    {
        //Help with code for setting animations comes from https://www.youtube.com/watch?v=AdQz2wStdLY&t=1s
        rb.linearVelocity = new Vector2(_moveDirection.x * horizontalSpeed, _moveDirection.y * verticalSpeed);
        if (_moveDirection.y > 0) 
        {
        animations.SetBool("moving_up", true);
        Debug.Log("Moving up animation activation ");

        }
        if (_moveDirection.y < 0)
        {
        animations.SetBool("moving_down", true);
        Debug.Log("Moving down animation activation ");
        }
        if (_moveDirection.y == 0)
        {
        animations.SetBool("moving_up", false);
        animations.SetBool("moving_down", false);
        Debug.Log("Default animation activation ");
        }
        //These sets of if statements check if the player is ascending, descending or only moving horizontally to determine which animations to use
    }


}
