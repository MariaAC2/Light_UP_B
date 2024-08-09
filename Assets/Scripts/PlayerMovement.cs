using System.Collections.Generic;
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
        StartCoroutine(Dialogs.ShowDialog(new List<string> {
            "Welcome to the game! Some very very very long text meant to try this feature! Some more very very very long text that should be displayed in the dialog box!",
            "This is the second dialog box!"
        }));
    }

    // Update is called once per frame
    void Update()
    {
        horInput = Input.GetAxisRaw("Horizontal");
        vertInput = Input.GetAxisRaw("Vertical");

        Vector3 velocity = vertInput * speed * transform.forward;
        Quaternion rotation = Quaternion.Euler(horInput * angularSpeed * Time.deltaTime * Vector3.up);
        rb.velocity = new Vector3(velocity.x, rb.velocity.y, velocity.z);
        rb.MoveRotation(transform.rotation * rotation);

        // // Ground check using Raycast
        isGrounded = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), groundCheckDistance, groundMask);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            // rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }
    }

}
