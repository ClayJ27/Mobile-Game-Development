using UnityEngine;

public class PlayerBulletTest : MonoBehaviour
{
    Rigidbody2D bulletRB;
    public float bulletSpeed;

    void BulletMovement()
    {
        bulletRB.transform.Translate(new Vector2(bulletSpeed, 0f) * Time.deltaTime);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bulletRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        BulletMovement();
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
