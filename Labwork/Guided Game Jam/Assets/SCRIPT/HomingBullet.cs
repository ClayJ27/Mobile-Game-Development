using System.Collections;
using UnityEngine;

public class HomingBullet : MonoBehaviour
{
    public float bulletSpeed;
    GameObject player;
    Rigidbody2D bulletRB;
    public int damage;
    public float expireTimer;

    IEnumerator DestroyHomingBullet()
    {
        yield return new WaitForSeconds(expireTimer);
        Destroy(this.gameObject);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bulletRB = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(DestroyHomingBullet());
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveDir = (player.transform.position - transform.position).normalized * bulletSpeed; // Tracks where the player is compared to the enemy
        bulletRB.linearVelocity = new Vector2(moveDir.x, moveDir.y); // Move the bullet
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
