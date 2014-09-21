using UnityEngine;
using System;

public class Quiver : MonoBehaviour {

	public int bow = 0;
	public GameObject[] blockbreaker;
	public Transform getTransform;
	public GameObject[] arrows = new GameObject[10];

	private bool canFire = true;


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
					bow -= 1;
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
					bow -= 1;
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
					bow -= 1;
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
					bow -= 1;
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
