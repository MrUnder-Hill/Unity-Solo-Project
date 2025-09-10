using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    Rigidbody rb;

    public float verticleMove;
    public float horizontalMove;
    public float speed = 5f;
    public float jumpHeight = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 temp = rb.linearVelocity;

        temp.x = verticleMove * speed;
        temp.z = horizontalMove * speed;

        rb.linearVelocity = (temp.x * transform.forward) + (temp.y * transform.up) + (temp.z * transform.right);
    }

    public void Move(InputAction.CallbackContext context)
    {
        Vector2 inputAxis = context.ReadValue<Vector2>();

        verticleMove = inputAxis.y;
        horizontalMove = inputAxis.x;
    }
}