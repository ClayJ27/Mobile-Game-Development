using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class BossStats : MonoBehaviour
{
    // Boss stats to be edited in inspector
    public int health;
    public float movementSpeed;
    public float mainAttackSpeed;
    public float secondaryAttackSpeed;

    public GameObject bossBullet;
    public GameObject bossHomingBullet;
    public GameObject bossDeathExplosion;
    Rigidbody2D bossRB;
    ScoreManager bossScore;
    EnemySpawning bossOnScreen;

    IEnumerator BossMovement()
    {
        bossRB = GetComponent<Rigidbody2D>();
        bossRB.linearVelocityY = movementSpeed;
        yield return new WaitUntil(() => this.gameObject.transform.position.y >= 2.5);
        bossRB.linearVelocityY = -movementSpeed;
        yield return new WaitUntil(() => this.gameObject.transform.position.y <= -2.5);
        StartCoroutine(BossMovement());
    }

    IEnumerator BossMainAttack()
    {
        yield return new WaitForSeconds(mainAttackSpeed);
        float bulletPosX = transform.position.x - 1;
        float topBulletPosY = transform.position.y + 2;
        float bottomBulletPosY = transform.position.y - 2;
        Vector2 topBulletPos = new Vector2(bulletPosX, topBulletPosY);
        Vector2 middleBulletPos = new Vector2(bulletPosX, transform.position.y);
        Vector2 bottomBulletPos = new Vector2(bulletPosX, bottomBulletPosY);
        Instantiate(bossBullet, topBulletPos, Quaternion.identity);
        Instantiate(bossBullet, middleBulletPos, Quaternion.identity);
        Instantiate(bossBullet, bottomBulletPos, Quaternion.identity);
        StartCoroutine(BossMainAttack());
    }

    IEnumerator BossSecondAttack()
    {
        yield return new WaitForSeconds(secondaryAttackSpeed);
        float homingBulletPosY = transform.position.y - 2;
        Vector2 homingBulletPos = new Vector2(transform.position.x, homingBulletPosY);
        Instantiate(bossHomingBullet, homingBulletPos, Quaternion.identity);
        StartCoroutine(BossSecondAttack());
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(BossMovement());
        StartCoroutine(BossMainAttack());
        StartCoroutine(BossSecondAttack());
        bossScore = GameObject.FindGameObjectWithTag("GameManager").GetComponent<ScoreManager>();
        bossOnScreen = GameObject.FindGameObjectWithTag("EnemyManager").GetComponent<EnemySpawning>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
            bossScore.BossDeath();
            Instantiate(bossDeathExplosion, transform.position, Quaternion.identity);
            bossOnScreen.isBossActive = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            health--;
        }
        if (other.CompareTag("PlayerBullet"))
        {
            health--;
            Destroy(other.gameObject);
        }
    }
}
