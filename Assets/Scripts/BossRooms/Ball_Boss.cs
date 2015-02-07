using UnityEngine;
using System.Collections;

public class Ball_Boss : MonoBehaviour {

    public GameObject Idle, Roll, Hurt;
    public int Life = 3;
    public float Speed = 5;
    public Transform LeftofLevel, RightofLevel;
	public AudioClip[] bullyClips;

	//Death Configs
	public GameObject kill;
	public GameObject bowGolden;
	public GameObject telaIn;
	private RobbeController _playerController;

	// Use this for initialization
	void Start () {

        //start with the boss laughter and idle state
		_playerController = GameObject.Find ("Player").GetComponent<RobbeController>();
        Laugh(true);
		audio.PlayOneShot(bullyClips[1], 0.85f);

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //Starts standing in the middle on top

    //Move to the Left of the Map
    private void moveLeftState()
    {

        rigidbody2D.AddForce(new Vector2(Speed, 0) * Random.Range(2, 4));

        //enable the Roll State
        Roll.SetActive(true);
        //Disable all other states
        Hurt.SetActive(false);
        Idle.SetActive(false);

        Invoke("idleState", 1.5f);
    }

    //Move to the right of the Map
    private void moveRightState()
    {
        rigidbody2D.AddForce(new Vector2(-Speed, 0) * Random.Range(2, 4));

        //enable the Roll State
        Roll.SetActive(true);
        //Disable all other states
        Hurt.SetActive(false);
        Idle.SetActive(false);

        Invoke("idleState", 1.5f);
    }


    //Hurt
    //Subtracts from Life total
    //Checks to see if it needs to call Death on the Boss
    public void HurtState()
    {
        //Play the Hurt Animation
        //enable the Hurt State
        Hurt.SetActive(true);
        //Disable all other states
        Idle.SetActive(false);
        Roll.SetActive(false);


        //Subtract from the life total
		//Play damaged soundclip 
        Life--;

        Debug.Log("" + Life);
        //Check if we need to kill the player
        if(Life <= 0)
        {
            Debug.Log("Killing the Boss");
            BossDeath_OnComplete();
        }
    }

    /// user this method to do what you want to the boss when he dies or with the level when he dies
    private void BossDeath_OnComplete()
    {
        Debug.Log("Destory Boss Here");
		//Change color to blood read and play death soundclip
		_playerController.BossDeathAudios();////////////////////////
		//Increment Steam Stat
		SteamManager.StatsAndAchievements.incrementNumBossesDefeated();
		Debug.Log("YOU KILLED THE BOSS!!!!");
		//Invoke drop and destroy
		Vector3 pos = transform.position;
		Vector3 pos2 = pos;
		pos2.y -=2.25f;
		Instantiate(bowGolden, pos, Quaternion.identity);
		Instantiate(telaIn, pos2, Quaternion.identity);
        Destroy(this.gameObject);
    }

    //Idle
    //Starting and Default Animation After Hurt and Roll
    public void idleState()
    {
        Debug.Log("Idle");
        //enable the Idle State
        Idle.SetActive(true);

        //Disable all other states
        Hurt.SetActive(false);
        Roll.SetActive(false);

        //invoke a movement
        int _ran = Random.Range(0, 2);
        if(_ran == 1)
        {
            Invoke("moveRightState", 1.5f);
        }
        else
        {
            Invoke("moveLeftState", 1.5f);
        }
        
    }


    //Laugh
    //Call the sound to play of the boss laughing
    //Made Public in case you want to call it from another GameObject
    //Pass True to play Idle Animation during Laugh
    //Set to false by default
    public void Laugh(bool playIdle = false)
    {
		Debug.Log("Boss Laugh");

        if(playIdle)
        {
            idleState();
            Debug.Log("Returning to Idle After Laugh");
        }
        else
        {
            Debug.Log("Not Playing Idle After laugh");
        }

    }

}
