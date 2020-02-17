using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public GameObject[] TeamOne;
	public GameObject[] foods;
	public GameObject food;
	bool[] AllBack;
	private BotController botscript;
	private bool ButtonPressed = false;

	public void ButtonAction()
	{
		ButtonPressed = true;
	}


	// Use this for initialization
	void Start () 
	{
		TeamOne = GameObject.FindGameObjectsWithTag("Team1");
		foods = GameObject.FindGameObjectsWithTag("Food");
		Debug.Log(TeamOne);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (ButtonPressed == true)
		{
			for (int i = 0; i < TeamOne.Length; i++)
			{
				TeamOne[i].GetComponent<BotController>().StartRound();
			}
			food.GetComponent<FoodController>().StartFood();
			ButtonPressed = false;
			for (int i = 0; i < foods.Length; i++)
			{
				foods[i].GetComponent<FoodController>().StartFood();
			}

		}
		AllDone();
		TeamOne = GameObject.FindGameObjectsWithTag("Team1");
	}

	private bool AllDone()
	{
		for (int i = 0; i < TeamOne.Length; i++)
		{
			if (TeamOne[i].GetComponent<BotController>().isBack == true)
			{
				return true;
			}
		}
		return false;
	}
}
