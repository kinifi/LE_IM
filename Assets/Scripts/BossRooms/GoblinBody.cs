﻿using UnityEngine;
using System.Collections;

public class GoblinBody : MonoBehaviour {

	//Config for Audio
	public AudioClip[] goblinClips;

	//Config for Gouhl Hits
	public int gouhls = 7;

	//Configs for hits
	private Color baseColor;
	private Color armBaseColor;
	private Color headBaseColor;
	private Color currentColor;
	private Color childrenCurrentColor;
	public int hits = 0;

	//Death Configs
	public GameObject kill;
	public GameObject bowGolden;

	//componenets to get
	private SpriteRenderer _renderer;
	private SpriteRenderer _armRender;
	private SpriteRenderer _headRender;
	private RobbeController _playerController;

	void Start () 
	{
		_renderer = GetComponent<SpriteRenderer>();
		_armRender = GameObject.Find ("GoblinBossArm").GetComponent<SpriteRenderer>();
		_headRender = GameObject.Find ("GoblinBossHead").GetComponent<SpriteRenderer>();
		_playerController = GameObject.Find ("Player").GetComponent<RobbeController>();
		baseColor = new Color(_renderer.color.r, _renderer.color.g, _renderer.color.b, _renderer.color.a);
		armBaseColor = new Color(_armRender.color.r, _armRender.color.g, _armRender.color.b, _armRender.color.a);
		headBaseColor = new Color(_headRender.color.r, _headRender.color.g, _headRender.color.b, _headRender.color.a);

	}

	private void OnTriggerEnter2D (Collider2D col)
	{
		if(col.gameObject.tag == "Player")
		{
			if(kill == null)
			{
				//Let me know you were killed by the Goblin Boss
				Debug.Log ("You were killed by the Goblin Boss!!");
				//Call Death Script on Player
				GameObject.Find("Player").GetComponent<RobbeController>().DelayAllowMovement();
			}
		}
		
		if(col.gameObject.tag == "Arrow")
		{
			//Destroy arrow
			Destroy(col.gameObject);
			//Play damaged soundclip 
			audio.PlayOneShot(goblinClips[0], 0.5f);
			//flash blood red color before returning to baseColor
			_renderer.color = new Color (0.25f, 0.0f, 0.0f, 1.0f);
			_armRender.color = new Color (0.25f, 0.0f, 0.0f, 1.0f);
			_headRender.color = new Color (0.25f, 0.0f, 0.0f, 1.0f);
			Invoke("ReturnToBaseColor", 0.5f);
			//Increment hits
			hits +=1;
			
			//Check if 3 hits have been reached then initiate death sequence
			if(hits >= 3 && gouhls == 0)
			{
				//Change color to blood read and play death soundclip
				_playerController.BossDeathAudios();
				_renderer.color = new Color (0.25f, 0.0f, 0.0f, 1.0f);
				_armRender.color = new Color (0.25f, 0.0f, 0.0f, 1.0f);
				_headRender.color = new Color (0.25f, 0.0f, 0.0f, 1.0f);
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
		_armRender.color = armBaseColor;
		_headRender.color = headBaseColor;
	}

	private void DestroyObject()
	{
		Destroy(gameObject);			
	}
}
