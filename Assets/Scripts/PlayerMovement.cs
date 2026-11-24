using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float movementSpeed = 6f;
    [SerializeField] float jumpForce = 5f;

    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;

    Animator anim;
    private float movementValueX;
    private bool isOnGround;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

       Vector3 move = transform.right * horizontalInput
            + transform.forward * verticalInput;
        move = Vector3.ClampMagnitude(move, 1f);

        rb.linearVelocity = new Vector3(move.x * movementSpeed, rb.linearVelocity.y, move.z * movementSpeed);

        if (Input.GetButtonDown("Jump"))


        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 5f, rb.linearVelocity.z);
        }

        anim.SetFloat("Speed", Mathf.Abs(movementValueX));
        anim.SetBool("IsOnGround", isOnGround);


    }

    void Jump()
    {
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
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
        return Physics.CheckSphere(groundCheck.position, 1f, ground);
    }

}










