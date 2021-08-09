using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoPrueba : MonoBehaviour
{

    //(-1,1) Direcion: Derecha
    //(1,1) Direccion: Izquierda 

	public float speed = 5f;
    public float realSpeed = 5f;
    public float playerAware = 3f;
    public float aimingTime = 0.5f;
    public float shootingTime = 1.5f;
	public float y;
    public float maxX;
	public float minX;



    private Rigidbody2D _rigidbody;
	private GameObject _object; //objeto invisible posicion a la que quiero llegar
    private Animator _animator;
    private CocodAtaque _cocodAtaque; 

    private Vector2 _movement;
    private bool _facingRight;
    private bool _isAttacking;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>(); 
        _cocodAtaque = GetComponentInChildren<CocodAtaque>();

    }

    void Start()
    {
        if (transform.localScale.x < 0f) {
            _facingRight = true;
        } else if (transform.localScale.x > 0f) {
            _facingRight = false;
        }

    }

    void Update()
    {
        Vector2 direction = Vector2.left;

        if (_facingRight == true) {
            Debug.Log("debe ir a la derecha");
            direction = Vector2.right;
        }

        if (_isAttacking == false) {

            if (_facingRight == true) {

                if (transform.position.x >= maxX) {
                    Debug.Log("Tiene que dar vuelta IZQ");
                    Flip();
                } 

            } else {
                if (transform.position.x <= minX) {
                    Debug.Log("Tiene que dar vuelta DER");
                    Flip();
                } 
            }
        }

    }

    private void FixedUpdate()
    {
        float horizontalVelocity = speed;

        if (_facingRight == false) {
            horizontalVelocity = horizontalVelocity * -1f;
        }

        _rigidbody.velocity = new Vector2(horizontalVelocity, _rigidbody.velocity.y);
    }

    private void LateUpdate()
    {
        //_animator.SetBool("Idle", _rigidbody.velocity == Vector2.zero);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (_isAttacking == false && collision.CompareTag("Player")) {
            StartCoroutine(AimAndShoot());
        }
    }

    private void Flip()
    {
        _facingRight = !_facingRight;
        float localScaleX = transform.localScale.x;
        localScaleX = localScaleX * -1f;
        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }

    private IEnumerator AimAndShoot()
    {
        float speedBackup = speed;
        speed = 0f;

        _isAttacking = true;

        yield return new WaitForSeconds(aimingTime);

       CanShoot();

        yield return new WaitForSeconds(shootingTime);

        _isAttacking = false;
        speed = speedBackup;
    }

    void CanShoot()
    {
        if (_cocodAtaque != null) {
            _cocodAtaque.Shoot();
        }
    }

    private void OnDisable()
    {
        transform.position = new Vector2(maxX, y);
        _isAttacking = false;
        speed = realSpeed;
    }

}
