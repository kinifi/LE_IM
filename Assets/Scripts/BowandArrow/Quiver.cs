using UnityEngine;
using System;

public class Quiver : MonoBehaviour {

	public int bow = 0;
	public GameObject[] blockbreaker;
	public Transform getTransform;
	public GameObject[] arrows = new GameObject[10];


	void Update ()
	{

		if(bow > 0)
		{
			Transform shootTransform = getTransform;
			GameObject projectile;

			if(Input.GetKeyDown(KeyCode.W) || Input.GetButtonDown("Shooting Up"))
			{
				projectile = Instantiate(blockbreaker[0], shootTransform.position, Quaternion.identity) as GameObject;
				projectile.GetComponent<ArrowMover>().ShootUp();
				bow -= 1;
				Debug.Log ("Bow: " + bow);
			}
			if(Input.GetKeyDown(KeyCode.S) || Input.GetButtonDown("Shooting Down"))
			{
				projectile = Instantiate(blockbreaker[1], shootTransform.position, Quaternion.identity) as GameObject;
				projectile.GetComponent<ArrowMover>().ShootDown();
				bow -= 1;
				Debug.Log ("Bow: " + bow);
			}
			if(Input.GetKeyDown(KeyCode.D) || Input.GetButtonDown("Shooting Right"))
			{
				projectile = Instantiate(blockbreaker[2], shootTransform.position, Quaternion.identity) as GameObject;
				projectile.GetComponent<ArrowMover>().ShootRight();
				bow -= 1;
				Debug.Log ("Bow: " + bow);
  			}
			if( Input.GetKeyDown(KeyCode.A) || Input.GetButtonDown("Shooting Left"))
			{
				projectile = Instantiate(blockbreaker[3], shootTransform.position, Quaternion.identity) as GameObject;
				projectile.GetComponent<ArrowMover>().ShootLeft();
				bow -= 1;
				Debug.Log ("Bow: " + bow);
			}
		}
	}
}
