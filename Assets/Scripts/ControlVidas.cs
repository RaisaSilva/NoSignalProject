using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlVidas : MonoBehaviour
{
    public float healthRestoration = 0.5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")){

        	// incrementamos la vida del jugador
        	collision.SendMessageUpwards("AddHealth", healthRestoration);

        	gameObject.SetActive(false);
           
        }
    }
}
