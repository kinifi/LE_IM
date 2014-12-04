﻿using UnityEngine;
using System;

public class Quiver : MonoBehaviour {

	//Starting Bow
	public int bow = 0;

	//Components to get
	public GameObject[] blockbreaker;
	public Transform getTransform;
	public GameObject[] arrows = new GameObject[10];
	private AudioClip[] _shotsound;
	//Shooting Configs
	private bool canFire = true;

	//Components to get
	private int _quiverCount;

	void Start ()
	{
		_shotsound = GetComponent<RobbeController>().clips;
		_quiverCount = GetComponent<Inventory>().Arrows;
		bow = _quiverCount;
	}
	void Update ()
	{

		if(bow > 0)
		{
			Transform shootTransform = getTransform;
			GameObject projectile;

			if(Input.GetKeyDown(KeyCode.UpArrow)|| Input.GetAxis("ShootUD") < -0.9f)
			{
				if(canFire == true)
				{
					canFire = false;
					projectile = Instantiate(blockbreaker[0], shootTransform.position, Quaternion.identity) as GameObject;
					projectile.GetComponent<ArrowMover>().ShootUp();
					audio.PlayOneShot(_shotsound[3], 0.9F);
					bow -= 1;
					Inventory arrowCount = GameObject.Find("Player").GetComponent<Inventory>();
					arrowCount.Arrows -= 1;
					//Update PlayerPrefs
					PlayerPrefs.SetInt("bow", arrowCount.Arrows);
					Debug.Log ("This is the bow count " + bow + " and the arrow count " + arrowCount.Arrows);
					//Allow shooting in 0.5s
					Invoke("AllowFire", 0.5f);
					//Start HUD
					arrowCount.InventoryOnTimer();
				}
			}
			if(Input.GetKeyDown(KeyCode.DownArrow)|| Input.GetAxis("ShootUD") > 0.9f)
			{
				if(canFire == true)
				{
					canFire = false;
					projectile = Instantiate(blockbreaker[1], shootTransform.position, Quaternion.identity) as GameObject;
					projectile.GetComponent<ArrowMover>().ShootDown();
					audio.PlayOneShot(_shotsound[3], 0.9F);
					bow -= 1;
					Inventory arrowCount = GameObject.Find("Player").GetComponent<Inventory>();
					arrowCount.Arrows -= 1;
					//Update PlayerPrefs
					PlayerPrefs.SetInt("bow", arrowCount.Arrows);
					Debug.Log ("This is the bow count " + bow + " and the arrow count " + arrowCount.Arrows);
					//Allow shooting in 0.5s
					Invoke("AllowFire", 0.5f);
					//Start HUD
					arrowCount.InventoryOnTimer();
				}
			}
			if(Input.GetKeyDown(KeyCode.RightArrow)|| Input.GetAxis("ShootLR") > 0.9f)
			{
				if(canFire == true)
				{
					canFire = false;
					projectile = Instantiate(blockbreaker[2], shootTransform.position, Quaternion.identity) as GameObject;
					projectile.GetComponent<ArrowMover>().ShootRight();
					audio.PlayOneShot(_shotsound[3], 0.9F);
					bow -= 1;
					Inventory arrowCount = GameObject.Find("Player").GetComponent<Inventory>();
					arrowCount.Arrows -= 1;
					//Update PlayerPrefs
					PlayerPrefs.SetInt("bow", arrowCount.Arrows);
					Debug.Log ("This is the bow count " + bow + " and the arrow count " + arrowCount.Arrows);
					//Allow shooting in 0.5s
					Invoke("AllowFire", 0.5f);
					//Start HUD
					arrowCount.InventoryOnTimer();
				}
			}
			if(Input.GetKeyDown(KeyCode.LeftArrow)|| Input.GetAxis("ShootLR") < -0.9f)
			{
				if(canFire == true)
				{
					canFire = false;
					projectile = Instantiate(blockbreaker[3], shootTransform.position, Quaternion.identity) as GameObject;
					projectile.GetComponent<ArrowMover>().ShootLeft();
					audio.PlayOneShot(_shotsound[3], 0.9F);
					bow -= 1;
					Inventory arrowCount = GameObject.Find("Player").GetComponent<Inventory>();
					arrowCount.Arrows -= 1;
					//Update PlayerPrefs
					PlayerPrefs.SetInt("bow", arrowCount.Arrows);
					Debug.Log ("This is the bow count " + bow + " and the arrow count " + arrowCount.Arrows);
					//Allow shooting in 0.5s
					Invoke("AllowFire", 0.5f);
					//Start HUD
					arrowCount.InventoryOnTimer();
				}
			}
		}
	}
	
	void AllowFire()
	{
		canFire = true;
	}
}
