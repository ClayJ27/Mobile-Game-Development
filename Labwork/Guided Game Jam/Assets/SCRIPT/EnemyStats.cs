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
        enemyRB = GetComponent<Rigidbody2D>();
        enemyRB.transform.Translate(new Vector2(-movementSpeed, 0f) * Time.deltaTime);
    }

    IEnumerator EnemyAttack()
    {
        Instantiate(bullet, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(attackSpeed);
        StartCoroutine(EnemyAttack());
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(EnemyAttack());
        enemyScore = GameObject.FindGameObjectWithTag("GameManager").GetComponent<ScoreManager>();
        bossSpawning = GameObject.FindGameObjectWithTag("EnemyManager").GetComponent<EnemySpawning>();
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMovement();

        if (this.gameObject.transform.position.x <= -10) // Destroying enemy when off screen
        {
            Destroy(this.gameObject);
        }

        if (health <= 0)
        {
            Destroy(this.gameObject);
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
            Destroy(this.gameObject);
            enemyScore.EnemyDeath();
        }
        if (other.CompareTag("PlayerBullet")) // Decrease health if shot by player
        {
            health--;
            Destroy(other.gameObject);
        }
    }
}