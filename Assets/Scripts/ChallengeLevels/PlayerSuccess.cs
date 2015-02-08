using UnityEngine;
using System.Collections;

public class PlayerSuccess : MonoBehaviour {

	//public GameObject FadeObj;
	private bool hasSendLevelIncreaseData = false;
	public string playerName = "Player";

	// Use this for initialization
	void Start () {
		this.collider2D.isTrigger = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D coll)
	{

		if(coll.transform.name == playerName)
		{
			//FadeObj.SetActive(true);
			//coll.GetComponent<RobbeController>().canMove = false;
			//coll.GetComponent<Rigidbody2D>().isKinematic = true;
			//Invoke("loadSuccessLevel", 0.2f);
			if(hasSendLevelIncreaseData == false)
			{
				hasSendLevelIncreaseData = true;
				IncrementPlayerProgress();
			}
			Debug.Log("Player Success");
			loadSuccessLevel();
		}
	}

	private void IncrementPlayerProgress()
	{
		int _levelNum = PlayerPrefs.GetInt("levelUnlock");
		_levelNum++;
		PlayerPrefs.SetInt("levelUnlock", _levelNum);
	}

	private void loadSuccessLevel()
	{
		Application.LoadLevel("EndingLevel");
	}



}
