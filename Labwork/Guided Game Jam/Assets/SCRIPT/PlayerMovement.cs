using UnityEngine;

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


    void Awake() => rb = GetComponent<Rigidbody2D>();

    void Start()
    {
        canFire = true; //Player is able to shoot the frame the game starts
    }

    // Update is called once per frame
    void Update()
    { 
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            if (canFire == true)
            {
                canFire = false;
                sinceFire = 0f;
                GameObject bullet = Instantiate(bullet_prefab, FirePos.position, FirePos.rotation); //Creates a bullet at the attached fire location
                rb = gameObject.GetComponent<Rigidbody2D>();
                rb.AddForce(FirePos.right * bulletSpeed * Time.deltaTime, ForceMode2D.Impulse); //Makes the bullet move to the right of the screen at the set speed
            }
        }
        if (canFire == false)
        {
            // Timer setup using Time.deltaTime code is based on code from the unity documentation on Time.deltaTime
            sinceFire += Time.deltaTime;
            if (sinceFire >= fireCooldown)
            {
                canFire = true;
            }
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(yInput * verticalSpeed, rb.linearVelocity.y); //Allows for horizontal movement
        rb.linearVelocity = new Vector2(xInput * horizontalSpeed, rb.linearVelocity.x); //Allows for horizontal movement
        //Help with code for setting animations comes from https://www.youtube.com/watch?v=AdQz2wStdLY&t=1s
        if (yInput > 0) 
        {
            animations.SetBool("moving_up", true);
        }
        if (yInput < 0)
        {
            animations.SetBool("moving_down", true);
        }
        if (yInput == 0)
        {
            animations.SetBool("moving_up", false);
            animations.SetBool("moving_down", false);
        }
        //These sets of if statements check if the player is ascending, descending or only moving horizontally to determine which animations to use
    }
}
