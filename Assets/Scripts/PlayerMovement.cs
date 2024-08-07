using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float speed = 20;
    [SerializeField] float angularSpeed = 50;
    [SerializeField] float jumpForce = 5;
    [SerializeField] float groundCheckDistance = 0.1f; // Distance to check for the ground
    [SerializeField] LayerMask groundMask; // Layer mask to specify what is ground

    float horInput, vertInput;
    bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(0, -20f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        horInput = Input.GetAxisRaw("Horizontal");
        vertInput = Input.GetAxisRaw("Vertical");

        Vector3 velocity = transform.forward * vertInput * speed;
        Vector3 angularVelocity = Vector3.up * horInput * angularSpeed; // in Euler angles
        transform.Translate(velocity * Time.deltaTime, Space.World);
        transform.Rotate(angularVelocity * Time.deltaTime);

        // // Ground check using Raycast
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundMask);

        Debug.Log("Is Grounded: " + isGrounded); // Add this line for debugging

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            // rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }
    }

}
