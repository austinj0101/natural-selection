using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour 
{
	private GameObject GameController;
	private GameController GameScript;

	// Use this for initialization
	void Start () 
	{
		GameController = GameObject.FindGameObjectWithTag("GameController");
		GameScript = GameController.GetComponent<GameController>();

		foreach (GameObject x in GameScript.foodList)
		{
			Debug.Log(x);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
