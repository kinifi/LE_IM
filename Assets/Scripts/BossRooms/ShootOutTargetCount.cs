using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShootOutTargetCount : MonoBehaviour {

	//Text configs
	Text targetCountText;
	public int targetCount = 8;

	//Ending config
	private bool hasWon = false;
	private GameObject _player;
	public GameObject _Exit;


	// Use this for initialization
	void Start () 
	{
		targetCountText = GetComponent<Text>();
		_player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(hasWon == false)
		{
			CheckTargetCount();
		}
	}

	private void CheckTargetCount ()
	{
		if(targetCount == 0)
		{
			hasWon = true;
			targetCountText.text = "YOU'VE WON!!!";
			TheExitIsHere();
		}
		else
		{
			targetCountText.text = "Targets: " + targetCount.ToString();
		}
	}

	public void TargetHit ()
	{
		targetCount -= 1;
	}

	private void TheExitIsHere ()
	{
		Vector3 exitHere = _player.transform.position;
		exitHere.x += 3.0f;
		GameObject theExit = Instantiate(_Exit, exitHere, Quaternion.identity) as GameObject;
	}
	
}
