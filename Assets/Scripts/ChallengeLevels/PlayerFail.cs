using UnityEngine;
using System.Collections;

public class PlayerFail : MonoBehaviour {

	//public GameObject FadeObj;
	public bool isSpike = false;
	public bool isFalling = false;
	public string playerName = "Player";

	private bool hasIncrementedStat = false;
	private GameObject player;

	//Shot configs
	private bool isShot = false;
	private GameObject bowGolden;

	//Audio Configs
	public AudioClip[] _Sounds;

	//Animation Configs
	private Animator _anim;

	// Use this for initialization
	void Start () {

		this.collider2D.isTrigger = true;
        saveLevelName();
		_anim = GetComponent<Animator>();
		bowGolden = GameObject.Find ("Player").GetComponent<RobbeController>()._goldenBow;
	}
	
	public void startDeath() {
		//FadeObj.SetActive(true);
		disablePlayer();
		if(hasIncrementedStat == false)
		{
			hasIncrementedStat = true;
			incrementStats();
			//Invoke("loadFailLevel", 0.2f);
			loadFailLevel();
		}
		//Invoke("disablePlayer", 0.1f);


		Debug.Log("Player Fell");
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		Debug.Log ("This object has collided" + coll.gameObject.tag);
		if(coll.transform.name == playerName)
		{
			startDeath();
            saveLevelName();
		}
		else if(coll.gameObject.tag == "Arrow" && this.gameObject.name == "eyes")
		{
			//stop motion
			GameObject.Find("Enemy").GetComponent<moveToPoints>().enabled = false;
			//Set isShot to true and disable the trigger collider
			isShot = true;
			GameObject.Find ("eyes").GetComponent<PolygonCollider2D>().enabled = false;
			//GameObject.Find ("eyes").GetComponent<CircleCollider2D>().enabled = false;
			//Stop anim body
			this.gameObject.GetComponentInParent<ParticleSystem>().renderer.enabled = false;
			//Start anim
			_anim.SetBool("IsDead", true);
			//Play audio
			audio.PlayOneShot(_Sounds[0]);
			//Get position for bow drop
			Vector3 pos = transform.position;
			//Destroy Arrow
			Destroy(coll.gameObject);
						//chance of drop
			int drop = Random.Range(1,6);
			//drop
			if(drop == 5)
			{
				Instantiate(bowGolden, pos, Quaternion.identity);
			}
			//Destroy object
			Invoke ("DestroyObject", 0.45f);
		}
	}

	private void DestroyObject ()
	{
		Destroy(GameObject.Find("Enemy").gameObject);
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
