using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 5.0f;
    public float runSpeed = 10.0f;
    private Rigidbody rb;
    private Vector3 movement;
    private float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = walkSpeed; // Set initial speed to walking speed
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // Check if the player is pressing the Shift or Ctrl key to run
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) ||
            Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            speed = runSpeed; // Increase the speed to running speed
        }
        else
        {
            speed = walkSpeed; // Set the speed back to walking speed
        }
    }

    void FixedUpdate()
    {
        MovePlayer(movement);
    }

    void MovePlayer(Vector3 movement)
    {
        rb.MovePosition(transform.position + movement * speed * Time.fixedDeltaTime);
    }
}