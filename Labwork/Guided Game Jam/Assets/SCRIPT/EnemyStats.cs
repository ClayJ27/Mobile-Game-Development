using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class EnemyStats : MonoBehaviour
{
    // Enemy stats to be edited in inspector
    public int health;
    public float movementSpeed;
    public float attackSpeed;
    public GameObject bullet;
    public GameObject deathExplosion;

    Rigidbody2D enemyRB;
    ScoreManager enemyScore;
    EnemySpawning bossSpawning;

    void EnemyMovement()
    {
        Debug.Log("Enemy moving");
        enemyRB = GetComponent<Rigidbody2D>();
        enemyRB.transform.Translate(new Vector2(-movementSpeed, 0f) * Time.deltaTime);
    }

    IEnumerator EnemyAttack()
    {
        Debug.Log("Enemy attacking");
        Instantiate(bullet, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(attackSpeed);
        StartCoroutine(EnemyAttack());
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Enemy starting");
        StartCoroutine(EnemyAttack());
        enemyScore = GameObject.FindGameObjectWithTag("GameManager").GetComponent<ScoreManager>();
        bossSpawning = GameObject.FindGameObjectWithTag("EnemyManager").GetComponent<EnemySpawning>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Enemy movement start");
        EnemyMovement();

        if (this.gameObject.transform.position.x <= -10) // Destroying enemy when off screen
        {
            this.gameObject.SetActive(false);
        }

        if (health <= 0)
        {
            Debug.Log("Enemy defeated");
            this.gameObject.SetActive(false);
            enemyScore.EnemyDeath();
            Instantiate(deathExplosion, transform.position, Quaternion.identity);
            if (bossSpawning.isBossActive == false)
            {
                bossSpawning.enemiesKilled++;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) // Collision with other objects
    {
        if (other.CompareTag("Player")) // Destroy enemy when colliding with player
        {
            Debug.Log("Enemy defeated");
            this.gameObject.SetActive(false);
            enemyScore.EnemyDeath();
        }
        if (other.CompareTag("PlayerBullet")) // Decrease health if shot by player
        {
            Debug.Log("Enemy damaged");
            health--;
            other.gameObject.SetActive(false);
        }
    }
}