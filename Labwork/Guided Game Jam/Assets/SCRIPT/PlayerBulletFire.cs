using UnityEngine;

public class PlayerBulletTest : MonoBehaviour
{
    Rigidbody2D bulletRB;
    public float bulletSpeed;

    void BulletMovement()
    {
        bulletRB.transform.Translate(new Vector2(bulletSpeed, 0f) * Time.deltaTime);
        Debug.Log("Bullet moving");
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bulletRB = GetComponent<Rigidbody2D>();
        Debug.Log("Bullet starting");

    }

    // Update is called once per frame
    void Update()
    {
        BulletMovement();
    }

    private void OnBecameInvisible()
    {
        this.gameObject.SetActive(false);
        Debug.Log("Bullet invisible");
    }
}
