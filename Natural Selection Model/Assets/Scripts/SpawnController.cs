using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {

	public GameObject bot;
	private BotController botscript;
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
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
