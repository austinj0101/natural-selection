using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoints : MonoBehaviour {

	private GameObject SpawnArea;
	private SpawnController spawnScript;
	
	// Use this for initialization
	public void Start () 
	{
		SpawnArea = transform.parent.gameObject;
		spawnScript = SpawnArea.GetComponent<SpawnController>();
		//spawnScript.TotalRedSpawns.Add(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
