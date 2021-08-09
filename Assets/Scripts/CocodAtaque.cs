using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CocodAtaque : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bulletPrefab;
    private Transform _firePoint;
    public GameObject shooter;

    private bool _faceRight = true;
    private Rigidbody2D _rigidbody; 
    public float speed = 1f;
    private Animator _animator;
    public float shootingTime = 1.5f;
    public float amingTime= 5.5f;

    void Awake()
    {
        //encontrar el punto de partida para la bala   
    	_firePoint = transform.Find("FirePoint"); 
    }


    public void Shoot()
    {
        if (bulletPrefab != null && _firePoint != null && shooter != null){
            GameObject myBullet = Instantiate (bulletPrefab, _firePoint.position, Quaternion.identity) as GameObject; //as GameObject para guardarlo en una var

            Bala bulletComponent = myBullet.GetComponent<Bala>();

            if (shooter.transform.localScale.x > 0f) {
                //izquierda
                bulletComponent.direction = Vector2.left; //vector2 (1f, 0f)

            } else {
                //derecha
                bulletComponent.direction = Vector2.right; //vector2 (1f, 0f)
            }

        }
    }
}
