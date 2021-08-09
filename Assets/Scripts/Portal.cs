using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
	public RectTransform winMenu;
	public GameObject hordes;

   private void OnTriggerEnter2D(Collider2D collision)
    {
    	collision.gameObject.SetActive(false);

    	winMenu.gameObject.SetActive(true);

    	hordes.SetActive(false);
    	


    }
}
