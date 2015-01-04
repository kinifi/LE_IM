using UnityEngine;
using System.Collections;

public class ArrowMover : MonoBehaviour {

	//set shot speed
	public float shootSpeed = 300.0f;


	public void ShootUp ()
	{
		rigidbody2D.AddForce(Vector2.up * shootSpeed);
	}

	public void ShootDown ()
	{
		rigidbody2D.AddForce(-Vector2.up * shootSpeed);
	}
	public void ShootRight ()
	{
		rigidbody2D.AddForce(Vector2.right * shootSpeed);
	}
	public void ShootLeft ()
	{
		rigidbody2D.AddForce(-Vector2.right * shootSpeed);
	}
	void OnCollisionEnter2D (Collision2D other) 
	{
		if(other.gameObject.tag != "Player" && other.gameObject.tag != "BreakableBlock" && other.gameObject.layer != 17)
		{
			//Debug.Log("This object is causing problems: " + other.gameObject);
			Destroy(this.gameObject);
			//Debug.Log ("BUGS BUGS BUGS BUGS BUGS");
		}
	}
}
