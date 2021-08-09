using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlKey : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
                //1. Mouse
        if (Input.GetMouseButtonDown(0)) {
        	Debug.Log("Boton presionado");
        }

        if (Input.GetMouseButton(0)) {
        	Debug.Log("Boton está presionado");
        }

        if (Input.GetMouseButtonUp(0)) {
        	Debug.Log("Boton liberado");
        } 
         
        if (Input.GetKeyDown(KeyCode.Space)) {
        	Debug.Log("Puedes usar esta tecla para saltar");
        }
        
    }
}
