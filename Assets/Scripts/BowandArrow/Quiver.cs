using UnityEngine;
using System;

public class Quiver : MonoBehaviour {

	public int bow = 0;
	public GameObject[] blockbreaker;
	public Transform getTransform;
	private float RSX, RSY;
	public GameObject[] arrows = new GameObject[10];
	public float firerate = 1.0f;
	private float nextfire = 0;


	void Update ()
	{
		RSX = Input.GetAxis("ShootHorizontal");
		RSY = Input.GetAxis("ShootVertical");

		if(bow > 0)
		{
			Transform shootTransform = getTransform;

			GameObject projectile;
			if((Time.time>nextfire && Input.GetKeyDown(KeyCode.W)) || (Time.time>nextfire && RSY > -0.98))
			{
				nextfire = Time.time + firerate;
				projectile = Instantiate(blockbreaker[0], shootTransform.position, Quaternion.identity) as GameObject;
				projectile.GetComponent<ArrowMover>().ShootUp();
				bow -= 1;
				Input.ResetInputAxes();
				Debug.Log ("Bow: " + bow);
			}
			if((Time.time>nextfire && Input.GetKeyDown(KeyCode.S)) || (Time.time>nextfire && RSY < 0.98))
			{
				nextfire = Time.time + firerate;
				projectile = Instantiate(blockbreaker[1], shootTransform.position, Quaternion.identity) as GameObject;
				projectile.GetComponent<ArrowMover>().ShootDown();
				bow -= 1;
				Input.ResetInputAxes();
				Debug.Log ("Bow: " + bow);
			}
			if((Time.time>nextfire && Input.GetKeyDown(KeyCode.D)) || (Time.time>nextfire && RSX > 0.98))
			{
				nextfire = Time.time + firerate;
				projectile = Instantiate(blockbreaker[2], shootTransform.position, Quaternion.identity) as GameObject;
				projectile.GetComponent<ArrowMover>().ShootRight();
				bow -= 1;
				Input.ResetInputAxes();
				Debug.Log ("Bow: " + bow);
  			}
			if((Time.time>nextfire && Input.GetKeyDown(KeyCode.A)) || (Time.time>nextfire && RSX < -0.98))
			{
				nextfire = Time.time + firerate;
				projectile = Instantiate(blockbreaker[3], shootTransform.position, Quaternion.identity) as GameObject;
				projectile.GetComponent<ArrowMover>().ShootLeft();
				bow -= 1;
				Input.ResetInputAxes();
				Debug.Log ("Bow: " + bow);
			}
		}
	}
}
