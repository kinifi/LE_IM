using UnityEngine;
using System.Collections;

public class ScaredController : MonoBehaviour {

	//Configs for fading
	public float fadeSpeed = 0.8f; //fading speed
	private float alpha = 1.0f; //alpha value between 0 and 1. 1 = 100% visable
	private int fadeDir = -1; //direction to fade: in = -1 out = 1

	//Configs for ghost movement
	private float xPos;

	//Config for Audio
	public AudioClip[] scaredClips;

	//Configs for hits and death
	private Color baseColor;
	private Color currentColor;
	private int hits = 0;
	public GameObject kill;
	public GameObject deathSplash;
	public GameObject bowGolden;

	//componenets to get
	private SpriteRenderer _renderer;
	private RobbeController _playerController;
	private Vector3 _position;


	// Use this for initialization
	void Start () 
	{
		_renderer = GetComponent<SpriteRenderer>();
		baseColor = new Color(_renderer.color.r, _renderer.color.g, _renderer.color.b, _renderer.color.a);
		Invoke("Fading", 2.0f);	
		Invoke ("GhostMover", 2.0f);
	}

	void Update ()
	{
		Invoke ("Fading", 2.0f);
		CheckPlayerPos();
	}

	void GhostMover ()
	{
		_playerController = GameObject.Find ("Player").GetComponent<RobbeController>();
		_position = GameObject.Find ("Player").transform.position;


		{
			xPos = _position.x ;
		}
		if(_playerController._right)
		{
			if(_playerController.playervelocity.x == 0)
			{
				int hop = Random.Range (0,4); 
				xPos = _position.x - hop;
			}
			else
			{
				xPos  = _position.x - 3.0f;
			}
		}
		else if(!_playerController._right)
		{
			if(_playerController.playervelocity.x == 0)
			{
				int hop = Random.Range (0,4);
				xPos = _position.x + hop;
			}
			else
			{
				xPos  = _position.x + 3.0f;
			}
		}
		Vector3 pos = new Vector3(Mathf.Clamp(xPos, 0.0f, 39.0f), transform.position.y, transform.position.z);
		this.transform.position = pos;
		//Debug.Log("New postiont is: "+this.transform.position);
		Invoke("GhostMover", 2.0f);
	}

	void Fading ()
	{
		//fade out/in the alpha value using directio, speed, and Time.deltaTime to convert to seconds
		alpha += fadeDir * fadeSpeed; 

		//force (clamp) value between 0 and 1
		alpha = Mathf.Clamp01(alpha);

		//set new alpha
		currentColor = _renderer.color;
		currentColor.a = alpha;
		_renderer.color = currentColor;

		//switch direction then call it again
		fadeDir *= -1;
		if(alpha == 1.0f)
		{
			Invoke("Flicker", 1.0f);
		}
		else
		{
			alpha = 1.0f;
		}
		//Debug.Log ("Alpha's value is: "+alpha);
	}

	void Flicker ()
	{
		float flicker = Random.Range (0.0f, 0.95f);
		alpha = flicker;
	}

	void CheckPlayerPos ()
	{
		GameObject _robbe = GameObject.Find ("Player");
		Vector3 theScale = this.gameObject.transform.localScale;
		if(_robbe.transform.position.x > this.transform.position.x)
		{
			theScale.x = 1.0f;
			this.gameObject.transform.localScale = theScale;
		}
		else
		{
			theScale.x = -1.0f;
			this.gameObject.transform.localScale = theScale;
		}
	}

	private void OnTriggerEnter2D (Collider2D col)
	{
		if(col.gameObject.tag == "Player")
		{
						
			if(kill == null)
			{
				Debug.Log ("You were killed by a the boss!!");
				
				//Get the needed game objects
				GameObject resetRobbe = GameObject.Find ("Player");
				GameObject respawn = GameObject.Find("Spawn_Location");

				//Instantiate the death splash and overlay Robbe.  Destroy it and call the movement function.
				kill = Instantiate(deathSplash, resetRobbe.transform.position, Quaternion.identity) as GameObject;
				kill.transform.OverlayPosition(resetRobbe.transform);
				kill.transform.localScale = new Vector3(50.0f,50.0f,1.0f);

				//Set Robbe's transform to the Spawn Location.
				resetRobbe.transform.position = respawn.transform.position;

				//Find the Smooth Flow script and disable it
				Smooth_Follow _smthFollow = GameObject.Find("Camera").GetComponent<Smooth_Follow>();
				_smthFollow.enabled = false;

				//Find Robbe's controller and prevent his movement.
				RobbeController _robbe = GameObject.Find("Player").GetComponent<RobbeController>();
				_robbe.enabled = false;
				
				//Find the LookDown camera and prevent its movement.
				NoFaithController _lookdown = GameObject.Find("Camera").GetComponent<NoFaithController>();
				_lookdown.enabled = false;

				Destroy(kill, 2.5f);
				Invoke("AllowRobbesMovement", 2.6f);
			}
		}
		
		if(col.gameObject.tag == "Arrow")
		{
			//Destroy arrow
			Destroy(col.gameObject);
			//Play damaged soundclip and flash blood red color before returning to baseColor
			audio.PlayOneShot(scaredClips[0], 0.5f);

			_renderer.color = new Color (0.25f, 0.0f, 0.0f, 1.0f);
			Invoke("ReturnToBaseColor", 0.5f);
			//Increment hits
			hits +=1;

			//Check if 3 hits have been reached then initiate death sequence
			if(hits >= 3)
			{
				//Change color to blood read and play death soundclip
				_playerController.BossDeathAudios();
				_renderer.color = new Color (0.25f, 0.0f, 0.0f, 1.0f);
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

	private void AllowRobbesMovement() 
	{
		//Find Robbe and allow his movement again.  Turn kinematic to false.
		RobbeController _robbe = GameObject.Find("Player").GetComponent<RobbeController>();
		_robbe.enabled = true;
		
		//Find the LookDown camera and allow its movement.
		NoFaithController _lookdown = GameObject.Find("Camera").GetComponent<NoFaithController>();
		_lookdown.enabled = true;

		//Find the Smooth Flow script and enable it
		Smooth_Follow _smthFollow = GameObject.Find("Camera").GetComponent<Smooth_Follow>();
		_smthFollow.enabled = true;
	}
}
