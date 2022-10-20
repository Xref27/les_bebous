using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Collision coll;
    [SerializeField] private PlayerInput pl;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Vector2 movementInput;
    public static PlayerMovement Instance { get; private set; }

    private Rigidbody2D rb;
    private int _canJump = 2;

    public int jumpForce;

    private void Awake()
        Instance = this;
    }

    [Space]
    [Header("Jump")]
    [SerializeField] private float jumpPower;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
	}
    [Space]
    [Header("Movement")]
    [SerializeField] private float horizontalMovement;
    [SerializeField] private float speedMovement;
    [SerializeField] private bool isInTheAir;

    void Awake()
    {
        coll = GetComponent<Collision>();
        pl = GetComponent<PlayerInput>();
    }

    

    private void Update()
    {
                if (coll.onGround)
        {
            isInTheAir = false;
        }
        else
        {
            isInTheAir = true;
        }

        rb.velocity = new Vector2(horizontalMovement * speedMovement, rb.velocity.y);

        //rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * 5f, rb.velocity.y);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        horizontalMovement = context.ReadValue<Vector2>().x;
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && coll.onGround)
        {
            Jump(Vector2.up);
        }
        if (context.canceled && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }

    private void Jump(Vector2 dir)
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.velocity += dir * jumpPower;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_canJump > 0)
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                _canJump--;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _canJump = 2;
        }
    }
    }
}
