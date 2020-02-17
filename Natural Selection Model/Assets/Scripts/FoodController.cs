using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodController : MonoBehaviour {


	// Use this for initialization
	public void StartFood() 
	{
		gameObject.SetActive(true);
		bool isActive = (Random.value > 0.5f);
		if (isActive == false)
		{
			gameObject.SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
