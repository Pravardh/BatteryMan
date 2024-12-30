using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public float lookSpeed = 2f;
    public float maxLookAngle = 80f;
    public float gravity = -9.8f;
    public float jumpHeight = 2f;

    private float rotationX = 0f;
    private Vector3 velocity;
    private CharacterController characterController;
    private InputReader inputReader;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        inputReader = GetComponent<InputReader>();

        //---- Session 2 ----
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Move();

        //---- Session 2 ----
        LookAround();
        ApplyGravityAndJump();

    }

    void Move()
    {
        float moveX = inputReader.GetHorizontalAxis() * moveSpeed;
        float moveZ = inputReader.GetVerticalAxis() * moveSpeed;

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        characterController.Move(move * Time.deltaTime);
    }

    //---- Session 2 ----
    void LookAround()
    {
        float mouseX = Input.GetAxis("Mouse X") * lookSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * lookSpeed;

        //String formatting
        rotationX -= mouseY; 
        rotationX = Mathf.Clamp(rotationX, -maxLookAngle, maxLookAngle);

        transform.localRotation = Quaternion.Euler(0f, transform.localRotation.eulerAngles.y + mouseX, 0f);
        Camera.main.transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
    }

    //---- Session 2 ----
    void ApplyGravityAndJump()
    {
        velocity.y = 0f;

        if (Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }
}
