using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float totalHealth = 3f;
    public RectTransform heartUI;

    //game over
    public RectTransform gameOverMenu;
    public GameObject hordes;
    public GameObject vidas;

    private float health;
    private float heartSize = 1290f; 

    private SpriteRenderer _renderer;
    private Animator _animator;
    private PlayerController _controller;


    private void Awake()
    {
    	_renderer = GetComponent<SpriteRenderer>();
    	_animator = GetComponent<Animator>();
    	_controller = GetComponent<PlayerController>();

    }

    void Start()
    {
        health = totalHealth;
    }

    public void AddDamage(float amount)
    {
    	health = health - amount;
    	StartCoroutine("VisualFeedback");

    	//game over
    	if (health <= 0f){
    		health = 0f;
    		gameObject.SetActive(false);
    	}

    	heartUI.sizeDelta = new Vector2(heartSize * health, heartSize);
    	Debug.Log("El jugador fue dañado. Su vida actual es: " + health);

    }

    public void AddHealth (float amount)
    {
    	health = health + amount;

    	if (health > totalHealth){
    		health = totalHealth;
    	}

    	heartUI.sizeDelta = new Vector2(heartSize * health, heartSize);
    	Debug.Log("El jugador obtuvo vida. Su vida actual es: " + health);
    }

    private IEnumerator VisualFeedback()
    {
    	_renderer.color = Color.red;
    	yield return new WaitForSeconds(0.1f);
    	_renderer.color = Color.white;
    }

    private void OnEnable()
    {
    	health = totalHealth;
        heartUI.sizeDelta = new Vector2(heartSize * health, heartSize);

        for (int a = 0; a < vidas.transform.childCount; a++)
        {
            vidas.transform.GetChild(a).gameObject.SetActive(true);
        }
    } 

    private void OnDisable()
    {
    	if(health <= 0f){
    		gameOverMenu.gameObject.SetActive(true);
    	}

		_renderer.color = Color.white;    	

    	hordes.SetActive(false);
    	_animator.enabled = false;
    	_controller.enabled = false;

    }

}
