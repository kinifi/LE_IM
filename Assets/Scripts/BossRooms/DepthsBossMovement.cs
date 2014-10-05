using UnityEngine;
using System.Collections;

public class DepthsBossMovement : MonoBehaviour {

	//Configs for movement
	public float moreForce = 150.0f;

	//Config for Audio
	public AudioClip[] depthClips;
	
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
	void Start () {

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
				Debug.Log ("You were killed by a the boss!!");
				
				//Get the needed game objects
				GameObject resetRobbe = GameObject.Find ("Player");
				GameObject respawn = GameObject.Find("Spawn_Location");
				
				//Instantiate the death splash and overlay Robbe.  Destroy it and call the movement function.
				audio.PlayOneShot(depthClips[1], 0.5f);
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
			audio.PlayOneShot(depthClips[0], 0.5f);
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
}
