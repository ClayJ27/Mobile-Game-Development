using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class TiltSteering : MonoBehaviour
{
    [SerializeField] float deadZone = 0.05f;
    [SerializeField] float sensitivity = 2f;
    Vector3 neutral;
    public float horizontalSpeed;
    public float verticalSpeed;
    Rigidbody2D rb;
    float xInput;
    float yInput;
    public Animator animations;
    private Vector2 _moveDirection;

    void OnEnable()
    {
        if (Accelerometer.current != null)
            InputSystem.EnableDevice(Accelerometer.current);
    }

    public void Calibrate()
    {
        if (Accelerometer.current != null)
            neutral = Accelerometer.current.acceleration.ReadValue();
    }

    public float ReadTilt()
    {
        if (Accelerometer.current == null) return 0f;
        float x = Accelerometer.current.acceleration.ReadValue().x - neutral.x;
        if (Mathf.Abs(x) < deadZone) x = 0f;
        return Mathf.Clamp(x * sensitivity, -1f, 1f);
    }

    void FixedUpdate()
    {
        //Help with code for setting animations comes from https://www.youtube.com/watch?v=AdQz2wStdLY&t=1s
        rb.linearVelocity = new Vector2(_moveDirection.x * horizontalSpeed, _moveDirection.y * verticalSpeed);
        if (_moveDirection.y > 0)
        {
            animations.SetBool("moving_up", true);
        }
        if (_moveDirection.y < 0)
        {
            animations.SetBool("moving_down", true);
        }
        if (_moveDirection.y == 0)
        {
            animations.SetBool("moving_up", false);
            animations.SetBool("moving_down", false);
        }
        //These sets of if statements check if the player is ascending, descending or only moving horizontally to determine which animations to use
    }
}

