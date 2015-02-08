using UnityEngine;
using System.Collections;

public class PlayerFail : MonoBehaviour {

	//public GameObject FadeObj;
	public bool isSpike = false;
	public bool isFalling = false;
	public string playerName = "Player";

	private bool hasIncrementedStat = false;
	private GameObject player;

	// Use this for initialization
	void Start () {

		this.collider2D.isTrigger = true;
        saveLevelName();
	}
	
	public void startDeath() {
		//FadeObj.SetActive(true);
		if(hasIncrementedStat == false)
		{
			hasIncrementedStat = true;
			incrementStats();
			Invoke("loadFailLevel", 0.2f);
		}
		Invoke("disablePlayer", 0.1f);
		Debug.Log("Player Fell");
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.transform.name == playerName)
		{
			startDeath();
            saveLevelName();
		}
	}

	private void disablePlayer()
	{
		player = GameObject.Find("Player");
		player.GetComponent<RobbeController>().canMove = false;
		player.GetComponent<Rigidbody2D>().isKinematic = true;
	}

	private void incrementStats()
	{
		if(isFalling == true)
		{
			SteamManager.StatsAndAchievements.incrementNumOfDeathsByFalling();
			SteamManager.StatsAndAchievements.Unlock_Falling_Is_Fun_Achievement();
		}
		else if(isSpike == true)
		{
			SteamManager.StatsAndAchievements.incrementNumOfDeathsBySpikes();
		}
	}

	private void loadFailLevel()
	{

        
        //Debug.Log(">>>>>>>>>>>>>>>>>>>>>>>>>>>>> load failed level");
        
		Application.LoadLevel("FailedLevel");
	}

    private void saveLevelName()
    {
        //Debug.Log(">>>>>>>>>>>>>>>>>>>>>>Saved Level name: " + Application.loadedLevelName);
        PlayerPrefs.SetString("PreviousLevel", Application.loadedLevelName);
    }

}
