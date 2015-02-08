using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShootOutTimer : MonoBehaviour {


	//Text configs
	Text timerText;
	float countDown = 140.0f;

	//End Config
	private bool timeUp = false;

	// Use this for initialization
	void Start () 
	{
		timerText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(timeUp == false)
		{
			StopWatch();
		}
		
	}

	private void StopWatch ()
	{
		if(countDown > 0)
		{
			countDown = (countDown - Time.fixedDeltaTime);
			float roundDown = Mathf.Round(countDown);
			timerText.text = "Time:  " + roundDown.ToString();
		}
		else
		{
			timeUp = true;
			timerText.text = "Time is up!!";
			ResetLevel();
		}
	}

	private void ResetLevel ()
	{
		Application.LoadLevel("ShootOutBoss");
	}
}
