using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodController : MonoBehaviour {

	public GameObject GameController;
	private GameController GameScript;
	private List<GameObject> activeFoods;
	private Renderer rend;
	private Collider col;

	private bool IsActive;


	//public List<GameObject> foodList = new List<GameObject>();

	public void Start()
	{
		GameScript = GameController.GetComponent<GameController>();
		GameScript.foodList.Add(gameObject);
		rend = GetComponent<Renderer>();
		col = GetComponent<Collider>();
		col.enabled = true;
		rend.enabled = true;
		if (rend.enabled == true && col.enabled == true)
		{
			IsActive = true;
		}
		else
		{
			IsActive = false;
		}
	}

	// Use this for initialization
	public void StartFood() 
	{
		gameObject.tag = "Food";
		col.enabled = true;
		rend.enabled = true;
		bool Active = (Random.value > 0.5f);
		if (Active == false)
		{
			gameObject.tag = "Untagged";
			col.enabled = false;
			rend.enabled = false;
			IsActive = false;
		}
		else
		{
			col.enabled = true;
			rend.enabled = true;
			gameObject.tag = "Food";
		}

		if (IsActive == false)
		{
			GameScript.activeFood.Remove(gameObject);
		}

		/*foreach (GameObject x in (GameScript.AllBots))
		{
			Debug.Log("Starting bots");
			x.GetComponent<BotController>().StartRound();
		}*/
	}
	
	// Update is called once per frame
	public void Update () 
	{
		
	}
}
