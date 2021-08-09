using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{

    //(-1,1) Direcion: Derecha
    //(1,1) Direccion: Izquierda 

	public float speed = 1f;
	public float maxX;
	public float minX;
	public float waitingTime = 1f;

	private GameObject _object; //objeto invisible posicion a la que quiero llegar
    private Animator _animator;
    private CocodAtaque _cocodAtaque;
   // public AudioSource _audio;

//recogemos los componentes 
    void Awake()
    {
        _animator = GetComponent<Animator>(); 
        _cocodAtaque = GetComponentInChildren<CocodAtaque>();
     //   _audio = GetComponent<AudioSource>();
    }

    void Start()
    {
        UpdateObject();
        StartCoroutine("PatrolToTarget");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateObject()
    {
    	//como 1ra vez, crear objeto en la DERECHA
    	if (_object == null) {
    		_object = new GameObject("Object");
    		_object.transform.position = new Vector2(minX, transform.position.y);
    		transform.localScale = new Vector3(1,1,1);
            Debug.Log("Direccion: izquiera");

            return; //para que no ejecute el resto
    	}

    	//objeto en la izq -> objeto en der
    	if (_object.transform.position.x == minX) {
    		_object.transform.position = new Vector2(maxX, transform.position.y);
    		transform.localScale = new Vector3(-1,1,1); 
    	}

    	//objeto en la der-> objeto en izq
    	else if (_object.transform.position.x == maxX) {
    		_object.transform.position = new Vector2 (minX, transform.position.y);
    		transform.localScale = new Vector3(1,1,1);
    	}


    }

    //tipo corrrutina = funct de pasos
    private IEnumerator PatrolToTarget() 
    {
    	while (Vector2.Distance(transform.position, _object.transform.position) > 0.05f) {
           
    		//vamos a movernos
    		// posicion del cocod - mi posicion
    		Vector2 direction = _object.transform.position - transform.position; 

    		float xDirection = direction.x;

    		transform.Translate(direction.normalized * speed * Time.deltaTime);

    		// devolucion de una corrutina, dice que no sigas, pero cuando empiezas desde el incio hasta aquí
    		yield return null;

    	}

    	// llego al objeto
    	//Debug.Log("Ha llegado al objeto");
    	transform.position = new Vector2(_object.transform.position.x, transform.position.y);


        if (_cocodAtaque != null) {
            _cocodAtaque.Shoot();
            //_audio.Play();
        }
    	//esperaremo un poco
    	Debug.Log("Esperaremos..." + waitingTime + " seg");
    	//llamte otra vez
    	yield return new WaitForSeconds(waitingTime);

    	//
    	Debug.Log("Waiting enough, let's update the target and move again");
    	UpdateObject();
    	StartCoroutine("PatrolToTarget");
    }
}
