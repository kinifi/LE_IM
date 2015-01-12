using UnityEngine;
using System.Collections;

public class RotateBlocks : MonoBehaviour {

	public float speed = 2.0f;
	public float bigSpeed = -20.0f;


	// Update is called once per frame
	void FixedUpdate () 
	{
		if(this.gameObject.tag == "big")
		{
			rigidbody2D.MoveRotation(rigidbody2D.rotation + bigSpeed * Time.deltaTime);
		}
		else
		{
			rigidbody2D.MoveRotation(rigidbody2D.rotation + speed * Time.deltaTime);
		}
	}
}
