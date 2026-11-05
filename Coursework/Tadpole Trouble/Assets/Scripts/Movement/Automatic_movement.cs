using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.InputSystem;

public class Automatic_movement : MonoBehaviour
{
    public float currentSpeed;
    public float defaultSpeed;
    Rigidbody2D rb;
    public InputActionReference speed_up;

    void Awake() => rb = GetComponent<Rigidbody2D>();


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        defaultSpeed = 2;
        currentSpeed = defaultSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        rb.transform.Translate(new Vector2(0f, currentSpeed) * Time.deltaTime);
        if (speed_up.action.triggered)
        {
            currentSpeed = defaultSpeed * 3;
        }
        //if (speed_up.action.triggered == false)
        //{
            //currentSpeed = defaultSpeed;
        //}

    }

}