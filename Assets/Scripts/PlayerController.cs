using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] float JumpForce = 5f;

    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(horizontalInput * 5f, rb.velocity.y, verticalInput * 5f);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();
        }
    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 5f, rb.velocity.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy Head"))
        {
            Destroy(collision.transform.parent.gameObject);
            Jump();
        }
    }
    bool IsGrounded()
    {
      return Physics.CheckSphere(groundCheck.position, .1f, ground);
    }
}
