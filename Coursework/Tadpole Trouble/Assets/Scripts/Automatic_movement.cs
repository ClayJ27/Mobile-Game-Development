using UnityEngine;

public class Automatic_movement : MonoBehaviour
{
    public float movementSpeed;
    Rigidbody2D rb;

    void Awake() => rb = GetComponent<Rigidbody2D>();


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        movementSpeed = 2;
    }

    // Update is called once per frame
    void Update()
    {
        rb.transform.Translate(new Vector2(0f, movementSpeed) * Time.deltaTime);
    }

    //lol
}