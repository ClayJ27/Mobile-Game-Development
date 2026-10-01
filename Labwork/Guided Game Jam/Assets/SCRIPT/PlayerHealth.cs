using UnityEngine;
using UnityEngine.SceneManagement;

public class player_health : MonoBehaviour
{
    public int health;
    public GameObject playerDeathExplosion;
    private bool invincible;
    private float invincibilityLength = 1f;
    private float timeInvincible = 0f; //How long the current period of invicibility has lasted

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = 3;
        invincible = false;
    }

    void Update()
    {
        if (invincible == true)
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.blue; //Makes the player blue when they are invincible so they know when the invincibility ends
            timeInvincible += Time.deltaTime;
            if (timeInvincible >= invincibilityLength)
            {
                invincible = false;
                timeInvincible = 0f;
                this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
    }
  
    void OnTriggerEnter2D(Collider2D other) // Checks when the player makes contact with an enemy bullet
    {
        if (invincible == false)
        {
            if (other.CompareTag("EnemyBullet") || other.CompareTag("Enemy"))
            {
                invincible = true;
                Destroy(other.gameObject);
                health--;
                if (health <= 0)
                {
                    Destroy(this.gameObject);
                    Instantiate(playerDeathExplosion, transform.position, Quaternion.identity);
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //Reloads the game after dying
                }
            }
            if (other.CompareTag("Boss"))
            {
                invincible = true;
                health--;
                if (health <= 0)
                {
                    Destroy(this.gameObject);
                    Instantiate(playerDeathExplosion, transform.position, Quaternion.identity);
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //Reloads the game after dying
                }
            }
        }
    }
}