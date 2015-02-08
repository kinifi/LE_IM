using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GoblinWispCount : MonoBehaviour {

	//Text configs
	Text wispCountText;

	//Count configs
	public int wispCount = 7;

	//Ending config
	public bool defeatedWisps = false;
	private GameObject _player;

	// Use this for initialization
	void Start () 
	{
		//confirm wisp count is 7
		wispCount = 7;
		//get text component
		wispCountText = GetComponent<Text>();
		//Find player
		_player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(defeatedWisps == false)
		{
			CheckWispCount();
		}
	}

	private void CheckWispCount ()
	{
		if(wispCount == 0)
		{
			defeatedWisps = true;
			wispCountText.text = "Defeat the Goblin!";
		}
		else
		{
			wispCountText.text = "Wisps: " + wispCount.ToString();
		}
	}

	public void WispHit ()
	{
		wispCount -= 1;
	}
}
