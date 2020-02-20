using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {

	public GameObject GameController;
	public GameObject bot;
	private BotController botscript;
	//private List<GameObject> AvailableRedSpawns = new List<GameObject>();
	//private List<GameObject> AvailableBlueSpawns = new List<GameObject>();
	//public List<GameObject> TotalRedSpawns = new List<GameObject>();
	//public List<GameObject> TotalBlueSpawns = new List<GameObject>();
	public int newOnes = 0;
	public int newTwos = 0;


	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Team1" | other.gameObject.tag == "Team2")
		{
			botscript = other.GetComponent<BotController>();
			if (botscript.energy < 0)
			{
				botscript.SetSpeed();
			}
		}
	}

	// Use this for initialization
	void Start () 
	{
		newOnes = 0;
		newTwos = 0;
		/*foreach (GameObject x in GameObject.FindGameObjectsWithTag("SpawnReds"))
		{
			TotalRedSpawns.Add(x);
		}
		foreach (GameObject x in GameObject.FindGameObjectsWithTag("SpawnBlues"))
		{
			TotalBlueSpawns.Add(x);
		}*/
	}
	
	public void Spawn()
	{
		Debug.Log("In Spawn");
		if (gameObject.tag == "Spawn1")
		{
			float placeX = Random.Range(20, 24);
			float placeZ = Random.Range(-8, 8);
			//int index = Random.Range(0, TotalRedSpawns.Count);
			GameObject newBot = Instantiate(bot, new Vector3(placeX, 1, placeZ), Quaternion.identity);
			GameController.GetComponent<GameController>().AllBots.Add(newBot);
			GameController.GetComponent<GameController>().TeamOne.Add(newBot);
		}
		else
		{
			float placeX = Random.Range(20, 24);
			float placeZ = Random.Range(-8, 8);
			//int index = Random.Range(0, TotalRedSpawns.Count);
			GameObject newBot = Instantiate(bot, new Vector3(placeX, 1, placeZ), Quaternion.identity);
			GameController.GetComponent<GameController>().AllBots.Add(newBot);
			GameController.GetComponent<GameController>().TeamOne.Add(newBot);
		}
		foreach(GameObject x in GameObject.FindGameObjectsWithTag("Team1"))
		{
			GameController.GetComponent<GameController>().AllBots.Add(x);
		}
	}

	// Update is called once per frame
	void Update () 
	{
		
	}
}
