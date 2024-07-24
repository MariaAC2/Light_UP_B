using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float speed = 10;
    [SerializeField] float jumpForce = 5;
    [SerializeField] Transform cameraOrientation;
    [SerializeField] float groundCheckDistance = 0.1f; // Distance to check for the ground
    [SerializeField] LayerMask groundMask; // Layer mask to specify what is ground

    float horInput, vertInput;
    bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horInput = Input.GetAxisRaw("Horizontal") * speed;
        vertInput = Input.GetAxisRaw("Vertical") * speed;

        Vector3 move = cameraOrientation.right * horInput + cameraOrientation.forward * vertInput;
        rb.velocity = new Vector3(move.x, rb.velocity.y, move.z);

        // Ground check using Raycast
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundMask);

        Debug.Log("Is Grounded: " + isGrounded); // Add this line for debugging

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            // rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }
    }

}
