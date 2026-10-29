using System;
using System.Runtime.InteropServices;
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
    //public Animator animations;
    public InputActionReference move;
    //public InputActionReference restart;
    //public InputActionReference pause;
    //public InputActionReference menu;
    //public InputActionReference close; //Closing the pause menu
    private Vector2 _moveDirection;
    //public GameObject pauseMenu;
    //public GameObject settingsMenu;
    //public GameObject buttonDisplay;
    //bool paused;
    //bool menuOpen;



    void Awake() => rb = GetComponent<Rigidbody2D>();



    void Start()
    {
        //paused = false; //starts the game unpaused
        //menuOpen = false; //starts the game with the settings menu closed
    }

    // Update is called once per frame
    void Update()
    {
        //if (paused == true)
        //{
        //pauseMenu.SetActive(true);
        //buttonDisplay.SetActive(false);
        //Time.timeScale = 0;
        //}
        //else
        //{
        //pauseMenu.SetActive(false);
        //buttonDisplay.SetActive(true);
        //Time.timeScale = 1;
        //}
        //if (menuOpen == true)
        //{
        //settingsMenu.SetActive(true);
        //buttonDisplay.SetActive(false);
        //Time.timeScale = 0;
        //}
        //else
        //{
        //settingsMenu.SetActive(false);
        //buttonDisplay.SetActive(true);
        //Time.timeScale = 1;
        //}
        _moveDirection = move.action.ReadValue<Vector2>();
        //if (restart.action.triggered)
        //{
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //Reloads the game when restart button is pressed
        //}
        //if (pause.action.triggered)
        //{
        //if (paused == false)
        //{
        //paused = true;
        //}
        //else
        //{
        //paused = false;
        //}
        //}
        //if (menu.action.triggered)
        //{
        //menuOpen = true;
        //}
        //if (close.action.triggered)
        //{
        //menuOpen = false;
        //}
    }


    void FixedUpdate()
    {
        //Help with code for setting animations comes from https://www.youtube.com/watch?v=AdQz2wStdLY&t=1s
        rb.linearVelocity = new Vector2(_moveDirection.x * horizontalSpeed, _moveDirection.y * verticalSpeed);

    }

}