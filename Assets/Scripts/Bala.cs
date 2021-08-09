using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float damage = 0.5f;
    public float speed = 2f;
    public Vector2 direction;

    public float lifeTime = 6f;//tiempo de vida de la bala

    void Start()
    {
        Destroy(gameObject, lifeTime); //unity metodo (el objeto, tiempo) 
    }

    void Update()
    {
    	Vector2 movement = direction.normalized * speed * Time.deltaTime; //maginitud del vector = normalizado y se adapta por el frame  
    	transform.Translate(movement);
        
    }
    // encontrar al jugador y reducir vida
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")){
        
            collision.SendMessageUpwards("AddDamage", damage);
            Destroy(gameObject);
        }
    }
}
