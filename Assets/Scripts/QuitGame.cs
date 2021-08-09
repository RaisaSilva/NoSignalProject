using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
 	public void Quit()
 	{
 		Application.Quit();
 		Debug.Log("Acabas de salir del juego");
 	}
}
