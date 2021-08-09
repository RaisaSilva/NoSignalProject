using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

	public float speed = 2.5f;
    public float groundCheckRadius;
    public float jumpForce = 2.5f;
    public Transform groundCheck; //floorpoint
    public LayerMask groundLayer; //selec layer
    

    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private Vector2 _movement;
    private bool _faceRight = true; 
    private bool _isGrounded;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        
    }

    void Update()
    {
        //movimiento
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        _movement = new Vector2(horizontalInput, 0f);

        //mirada 
        if (horizontalInput < 0f && _faceRight == true) {
            Flip();
        } else if (horizontalInput > 0f && _faceRight == false) {
            Flip();
        }

        //grounded?
        _isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer); //
    
        //jumping?
        if(Input.GetButtonDown("Jump") && _isGrounded == true ){
            _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    void FixedUpdate()
    {
        float horizontalVelocity = _movement.normalized.x * speed;
        _rigidbody.velocity = new Vector2(horizontalVelocity, _rigidbody.velocity.y);
    }

    void LateUpdate()
    {
        _animator.SetBool("Rest", _movement == Vector2.zero);
        _animator.SetBool("IsGrounded", _isGrounded);
        _animator.SetFloat("VerticalVelocity", _rigidbody.velocity.y);
    }

    void Flip()
    {
        _faceRight = !_faceRight;
        float localScaleX =  transform.localScale.x;
        localScaleX = localScaleX * -1f;
        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);

    }

    private void OnDisable()
    {
        transform.position = new Vector2(-14, 3);
    }
}
