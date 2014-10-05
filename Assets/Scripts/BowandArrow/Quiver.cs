using UnityEngine;
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

			if(Input.GetKeyDown(KeyCode.UpArrow)|| Input.GetAxis("Fire Up/Down") < -0.9f)
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
					Debug.Log (bow);
					Invoke("AllowFire", 0.5f);
				}
			}
			if(Input.GetKeyDown(KeyCode.DownArrow)|| Input.GetAxis("Fire Up/Down") > 0.9f)
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
					Debug.Log (bow);
					Invoke("AllowFire", 0.5f);
				}
			}
			if(Input.GetKeyDown(KeyCode.RightArrow)|| Input.GetAxis("Fire Left/Right") > 0.9f)
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
					Debug.Log (bow);
					Invoke("AllowFire", 0.5f);
				}
			}
			if(Input.GetKeyDown(KeyCode.LeftArrow)|| Input.GetAxis("Fire Left/Right") < -0.9f)
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
					Debug.Log (bow);
					Invoke("AllowFire", 0.5f);
				}
			}
		}
	}
	
	void AllowFire()
	{
		canFire = true;
	}
}
