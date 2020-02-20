using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour {

	public GameObject startButton;
	public GameObject GameController;
	private GameController GameScript;
	Button strt;

	// Use this for initialization
	void Start () 
	{
		strt = startButton.GetComponent<Button>();
		GameScript = GameController.GetComponent<GameController>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (GameScript.ButtonPressed == false)
		{
			strt.interactable = true;
		}
		else
		{
			strt.interactable = false;
		}
	}
}
