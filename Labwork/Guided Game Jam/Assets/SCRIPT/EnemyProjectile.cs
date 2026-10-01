using UnityEngine;

public class PlayerTracking : MonoBehaviour
{
    public float bulletSpeed;
    GameObject player;
    Rigidbody2D bulletRB;
    public int damage;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bulletRB = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        Vector2 moveDir = (player.transform.position - transform.position).normalized * bulletSpeed; // Tracks where the player is compared to the enemy
        bulletRB.linearVelocity = new Vector2(moveDir.x, moveDir.y); // Move the bullet
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.transform.position.x <= -10 || this.gameObject.transform.position.x >= 10 || this.gameObject.transform.position.y <= -10 || this.gameObject.transform.position.y >= 10) // Destroying the bullet when it's off screen
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
