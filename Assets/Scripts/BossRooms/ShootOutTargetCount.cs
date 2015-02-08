using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShootOutTargetCount : MonoBehaviour {

	//Text configs
	Text targetCountText;
	public int targetCount = 8;

	//Ending config
	bool hasWon = false;

	// Use this for initialization
	void Start () 
	{
		targetCountText = GetComponent<Text>();
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
	
}
