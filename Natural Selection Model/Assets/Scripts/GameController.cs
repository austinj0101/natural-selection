using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	//public GameObject[] TeamOne;
	public List<GameObject> TeamOne = new List<GameObject>();
	public List<GameObject> TeamTwo = new List<GameObject>();
	public List<GameObject> AllBots = new List<GameObject>();
	public List<GameObject> foodList = new List<GameObject>();
	public List<GameObject> activeFood = new List<GameObject>();
	public GameObject food;
	//bool[] AllBack;
	private BotController botscript;
	public bool ButtonPressed = false;

	public void ButtonAction()
	{
		ButtonPressed = true;
		foreach (GameObject x in foodList)
		{
			x.GetComponent<FoodController>().StartFood();
		}
		FindBots();
		foreach (GameObject x in AllBots)
		{
			if (x != null)
			{
				Debug.Log(x);
				x.GetComponent<BotController>().StartRound();
			}
		}
	}

	public void FindBots()
	{
		GameObject[] bots1 = GameObject.FindGameObjectsWithTag("Team1");
		GameObject[] bots2 = GameObject.FindGameObjectsWithTag("Team2");
		foreach (GameObject bot in bots1)
		{
			AllBots.Add(bot);
		}
		foreach (GameObject bot in bots2)
		{
			AllBots.Add(bot);
		}
	}

	// Use this for initialization
	public void Start () 
	{
		ButtonPressed = false;
		foodList.Clear();
		foreach (GameObject x in GameObject.FindGameObjectsWithTag("Food"))
		{
			foodList.Add(x);
		}
		AllBots.Clear();
		foreach (GameObject x in GameObject.FindGameObjectsWithTag("Team1"))
		{
			AllBots.Add(x);
		}
		foreach (GameObject x in GameObject.FindGameObjectsWithTag("Team2"))
		{
			AllBots.Add(x);
		}
		TeamOne.Clear();
		TeamTwo.Clear();
		activeFood.Clear();
		foreach (GameObject x in AllBots)
		{
			if (x.tag == "Team1")
			{
				TeamOne.Add(gameObject);
			}
			else if (x.tag == "Team2")
			{
				TeamTwo.Add(gameObject);
			}
		}
		foreach (GameObject y in foodList)
		{
			activeFood.Add(y);
		}
		AllDone();
		//food.SetActive(true);
		//TeamOne = GameObject.FindGameObjectsWithTag("Team1");
		//foods = GameObject.FindGameObjectsWithTag("Food");
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (AllDone() == true)
		{
			ButtonPressed = false;
		}
		AllDone();
		//TeamOne = GameObject.FindGameObjectsWithTag("Team1");
	}

	public bool AllDone()
	{
		foreach (GameObject x in AllBots)
		{
			if (x != null)
			{
				if (x.GetComponent<BotController>().isBack == true)
				{
					return true;
				}
			}
		}
		return false;
	}
}
