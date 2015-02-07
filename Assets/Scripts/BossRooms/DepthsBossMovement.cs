using UnityEngine;
using System.Collections;

public class DepthsBossMovement : MonoBehaviour {

	//Configs for movement
	public float moreForce = 150.0f;

	//Config for Audio
	public AudioClip[] depthClips;
	
	//Configs for hits and perlWings
	private Color baseColor;
	private Color currentColor;
	private int hits = 0;
	public int perlWings = 2;

	//Configs for death
	public GameObject kill;
	public GameObject bowGolden;

	//componenets to get
	private SpriteRenderer _renderer;
	private RobbeController _playerController;
	private Vector3 _position;

	// Use this for initialization
	void Start () 
	{
		_renderer = GetComponent<SpriteRenderer>();
		_playerController = GameObject.Find ("Player").GetComponent<RobbeController>();
		baseColor = new Color(_renderer.color.r, _renderer.color.g, _renderer.color.b, _renderer.color.a);
		Invoke("Fading", 2.0f);	
		Invoke ("DownForce", 1.0f);
	}
	
	private void DownForce ()
	{
		rigidbody2D.AddForce(-Vector2.up * moreForce);
//		Debug.Log ("Down enforced");
		Invoke("UpForce", 1.0f);
	}

	private void UpForce ()
	{
		rigidbody2D.AddForce(Vector2.up * moreForce);
//		Debug.Log ("Up enforced");
		Invoke("DownForce", 1.0f);
	}

	private void OnTriggerEnter2D (Collider2D col)
	{
		if(col.gameObject.tag == "Player")
		{
			
			if(kill == null)
			{
				//Let me know you were killed the Depths Boss
				Debug.Log ("You were killed by the Depths Boss!!");
				//Call Death Script on Player
				GameObject.Find("Player").GetComponent<RobbeController>().DelayAllowMovement();
			}
		}
		
		if(col.gameObject.tag == "Arrow")
		{
			//Destroy arrow
			Destroy(col.gameObject);
			//Play damaged soundclip and flash blood red color before returning to baseColor
			audio.PlayOneShot(depthClips[0], 0.5f);
			_renderer.color = new Color (0.25f, 0.0f, 0.0f, 1.0f);
			Invoke("ReturnToBaseColor", 0.5f);
			//Increment hits
			hits +=1;
			
			//Check if 3 hits have been reached then initiate death sequence
			if(hits >= 3 && perlWings == 0 )
			{
				//Change color to blood read and play death soundclip
				_playerController.BossDeathAudios();
				_renderer.color = new Color (0.25f, 0.0f, 0.0f, 1.0f);
				//Inrement Steam Stat
				SteamManager.StatsAndAchievements.incrementNumBossesDefeated();
				Debug.Log("YOU KILLED THE BOSS!!!!");
				//Invoke drop and destroy
				Vector3 pos = transform.position;
				Instantiate(bowGolden, pos, Quaternion.identity);
				Destroy(this.gameObject);			}
		}
	}

	private void ReturnToBaseColor()
	{
		_renderer.color = baseColor;
	}
}
