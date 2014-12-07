﻿using UnityEngine;
using System.Collections;

public class WolfWalk : MonoBehaviour {

	//Configs for walk
	public bool faceRight = true;
	public bool walls = false;
	public float moveSpeed = 2000.0f;

	//Configs for wall rays
	private Vector2 wallRayStart;
	private Vector2 wallRayEnd;
	private Vector2 wallRayUpdateStart;
	private Vector2 wallRayUpdateEnd;
	//Config for sight layermask	
	public LayerMask walllayerMask; //make sure we aren't in this layer 
	//Transform configs
	public Transform wallStart, wallEnd;

	//Configs for breath
	private float nextPause;

	//Death Configs
	public GameObject kill;
	public GameObject deathSplash;
	public GameObject bowGolden;

	//Configs for hits
	private SpriteRenderer _renderer;
	private Color baseColor;
	private Color currentColor;
	private int hits = 0;

	// Use this for initialization
	void Awake () 
	{
		WolfWalkInitialize();
		ColorInitialize();
		InvokeRepeating("RandomBreathPause", 0.5f, nextPause);
	}

	// Update is called once per frame
	void Update () 
	{
		RaycastMethod();
		Behaviours();
		UpdateWallRayPosition();
	}

	//---------------------Movement Methods----------------------------//

	//initializes wolf movement
	private void WolfWalkInitialize()
	{
		//Initialize wall ray
		wallRayStart = wallStart.position;
		wallRayEnd = wallEnd.position;
	}


	//sets the original color of the boss
	private void ColorInitialize()
	{
		_renderer = GetComponent<SpriteRenderer>();
		baseColor = new Color(_renderer.color.r, _renderer.color.g, _renderer.color.b, _renderer.color.a);
	}


	//flips then contiinues in opposite direcitron
	private void Patrol ()
	{
		Flip();
		if(faceRight == true)
		{
			ZeroOutFources();
			walls = false;
			rigidbody2D.AddForce(-Vector2.right * moveSpeed * Time.deltaTime);
		}
		else
		{
			ZeroOutFources();
			walls = false;
			rigidbody2D.AddForce(Vector2.right * moveSpeed * Time.deltaTime);
		}
	}


	//flips the wolf and adjust rotaiton
	private void Flip()
	{
		faceRight = !faceRight;
		Vector3 theScale = transform.localScale;
		Quaternion theRotation = transform.localRotation;
		theRotation.z *= -1;
		theScale.x *= -1;
		transform.localScale = theScale;
		transform.localRotation = theRotation;
		//Debug.Log ("Flip ran and moveForward is now: " + moveForward);
	}

	//Zeros out forces for fliping the wolf
	private void ZeroOutFources ()
	{
		rigidbody2D.isKinematic = true;
		rigidbody2D.isKinematic = false;
	}

	//draws the raycast lines
	private void RaycastMethod ()
	{
		//Wall Rays
		Debug.DrawLine (wallRayStart, wallRayEnd, Color.yellow);
		walls = Physics2D.Linecast(wallRayStart, wallRayEnd, walllayerMask);
	}

	//manages all the behaviours associated with raycasting
	private void Behaviours ()
	{
		//if the ray hits a wall patrol continues
		if(walls == true)
		{
			//Debug.Log ("Walls is: "+walls);
			Patrol();
		}
	}

	//manages the raypositions
	private void UpdateWallRayPosition ()
	{
		if(faceRight)
		{
			//update the wall start ray pos
			wallRayUpdateStart = transform.position;
			wallRayUpdateStart.x -= 2.0f;
			wallRayUpdateStart.y +=0.5f;
			wallRayStart = wallRayUpdateStart;
			
			//update the wall end ray pos
			wallRayUpdateEnd = transform.position;
			wallRayUpdateEnd.x -= 5.0f;
			wallRayUpdateEnd.y -=1.5f;
			wallRayEnd = wallRayUpdateEnd;
		}
		else
		{
			//update the wall start ray pos
			wallRayUpdateStart = transform.position;
			wallRayUpdateStart.x += 2.0f;
			wallRayUpdateStart.y +=0.5f;
			wallRayStart = wallRayUpdateStart;
			
			//update the wall end ray pos
			wallRayUpdateEnd = transform.position;
			wallRayUpdateEnd.x += 5.0f;
			wallRayUpdateEnd.y -=1.5f;
			wallRayEnd = wallRayUpdateEnd;
		}
	}

	//Randomly pauses the breath particles then invokes the play
	private void RandomBreathPause ()
	{
		nextPause = Random.Range (0.5f, 1.5f);
		GameObject.Find("DeathBreath").particleSystem.Pause();
		Invoke ("BreathPlay", 0.5f);
	}

	//Plays the breath particles
	private void BreathPlay ()
	{
		GameObject.Find("DeathBreath").particleSystem.Play();
	}


	//Magages All The Trigger Collision
	private void OnTriggerEnter2D (Collider2D other)
	{
		if(other.gameObject.tag == "Player")
		{
			//Stop all movement of the bad guy!!
			this.gameObject.rigidbody2D.isKinematic = true;
			
			if(kill == null)
			{
				//Debug.Log ("You were killed by a bad guy!!");
				
				//Failsafe enable movement
				GameObject.Find("Player").GetComponent<RobbeController>().DelayAllowMovement();

				//Instantiate the death splash and overlay Robbe.  Destroy it and call the movement function.
				GameObject resetRobbe = GameObject.Find ("Player");
				kill = Instantiate(deathSplash, resetRobbe.transform.position, Quaternion.identity) as GameObject;
				kill.transform.OverlayPosition(resetRobbe.transform);
				kill.transform.localScale = new Vector3(50.0f,50.0f,1.0f);
				
				Destroy(kill, 1.0f);
			}
		}

		if(other.gameObject.tag == "Arrow")
		{
			//Destroy arrow
			Destroy(other.gameObject);
			//Play damaged soundclip 
			//audio.PlayOneShot(goblinClips[0], 0.5f);//////////////////////////
			//flash blood red color before returning to baseColor
			_renderer.color = new Color (0.25f, 0.0f, 0.0f, 1.0f);
			Invoke("ReturnToBaseColor", 0.5f);
			//Increment hits
			hits +=1;
			
			//Check if 3 hits have been reached then initiate death sequence
			if(hits >= 3)
			{
				//Change color to blood read and play death soundclip
				//_playerController.BossDeathAudios();////////////////////////
				_renderer.color = new Color (0.25f, 0.0f, 0.0f, 1.0f);
				//Increment Steam Stat
				SteamManager.StatsAndAchievements.incrementNumBossesDefeated();
				Debug.Log("YOU KILLED THE BOSS!!!!");
				//Invoke drop and destroy
				Vector3 pos = transform.position;
				Instantiate(bowGolden, pos, Quaternion.identity);
				Invoke("DestroyObject", 0.5f);
			}
		}
	}
	
	private void ReturnToBaseColor()
	{
		_renderer.color = baseColor;
	}
	
	private void DestroyObject()
	{
		Destroy(gameObject);			
	}
}