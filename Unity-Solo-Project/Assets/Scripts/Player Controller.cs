using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    Vector2 cameraRotation;
    Vector3 cameraOffset;
    InputAction lookVector;
    Camera playerCam;

    Rigidbody rb;

    public float verticleMove;
    public float horizontalMove;

    public float speed = 5f;
    public float jumpHeight = 10f;
    public float Xsensitivity = 1.0f;
    public float Ysensitivity = 1.0f;
    public float camRotationLimit = 90.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        cameraOffset = new Vector3(0, .5f, .5f);
        rb = GetComponent<Rigidbody>();
        playerCam = Camera.main;
        lookVector = GetComponent<PlayerInput>().currentActionMap.FindAction("Look");
        cameraRotation = Vector2.zero;
    }

    // Update is called once per frame
    private void Update()
    {
        // Camera Rotation System
        playerCam.transform.position = transform.position + cameraOffset;

        cameraRotation.x += lookVector.ReadValue<Vector2>().x * Xsensitivity;
        cameraRotation.y += lookVector.ReadValue<Vector2>().y * Ysensitivity;

        cameraRotation.y = Mathf.Clamp(cameraRotation.y, -camRotationLimit, camRotationLimit);

        playerCam.transform.rotation = Quaternion.Euler(-cameraRotation.y, cameraRotation.x, 0);
        transform.localRotation = Quaternion.AngleAxis(cameraRotation.x, Vector3.up);

        // Movement System
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