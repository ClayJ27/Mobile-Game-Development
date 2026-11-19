using UnityEngine;

public class FishMovement : MonoBehaviour
{

    Rigidbody2D fishRB;
    public float movementSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fishRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        fishRB.transform.Translate(new Vector2(-movementSpeed, 0f) * Time.deltaTime);
    }
}
