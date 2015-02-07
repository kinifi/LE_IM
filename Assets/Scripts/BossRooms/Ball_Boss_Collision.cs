using UnityEngine;
using System.Collections;

public class Ball_Boss_Collision : MonoBehaviour {

    //Set this to true and attach it to the Idle GameObject
    //Set this to False and attach it to the Ball GameObject
    public bool isIdle = false;
    //assign the parent boss object to this gameobject
    public GameObject Boss;

	//Death Configs
	public GameObject kill;
	private RobbeController _playerController;
	private AudioClip[] _bullyClips;

	// Use this for initialization
	void Awake () 
	{
		_playerController = GameObject.Find ("Player").GetComponent<RobbeController>();
		_bullyClips = GameObject.Find ("Boss").GetComponent<Ball_Boss>().bullyClips;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnPlayerDeath()
    {
        Debug.Log("Kill the player here");

		if(kill == null)
		{
			//Let me know you were killed by spikes
			Debug.Log ("You were killed by the Robot Boss!!");
			//Call Death Script on Player
			GameObject.Find("Player").GetComponent<RobbeController>().DelayAllowMovement();
		}
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        
        if(!isIdle)
        {
            if (coll.gameObject.tag == "Player")
            {
                OnPlayerDeath();
            }
			if (coll.gameObject.tag == "Arrow")
			{
				Destroy(coll);
			}
        }
        else if(isIdle)
        {
            //check to see if we are being hit by the arrow
            if (coll.gameObject.tag == "Arrow")
            {
				GameObject.Find ("Boss").GetComponent<AudioSource>().PlayOneShot(_bullyClips[1], 0.95f);
				//call the hurt state on the boss
                Boss.GetComponent<Ball_Boss>().HurtState();
            }
			if (coll.gameObject.tag == "Player")
			{
				OnPlayerDeath();
			}
        }
    }

}
