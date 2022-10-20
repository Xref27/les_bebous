using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance { get; private set; }

    private Rigidbody2D rb;
    private int _canJump = 2;

    public int jumpForce;
    public AudioSource run;
    public AudioSource jumpsound;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }


    private void Update()
    {
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * 5f, rb.velocity.y);
        if(Mathf.Abs(rb.velocity.x)>0.1f&& Mathf.Abs(rb.velocity.y) < 0.1f)
        {
            run.Play();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_canJump > 0)
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                _canJump--;
                jumpsound.Play();
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
