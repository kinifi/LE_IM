using UnityEngine;
using System.Collections;

public class ShaddowSpikeShotting : MonoBehaviour {

	public float shotSpeed;
	
	void Start ()
	{
		if(this.gameObject.tag == "spike")
		{
			rigidbody2D.AddForce(Vector2.up * shotSpeed);
		}
		else if(this.gameObject.tag == "topspike")
		{
			rigidbody2D.AddForce(-Vector2.up * shotSpeed);
		}
		else if(this.gameObject.tag == "rightspike")
		{
			rigidbody2D.AddForce(Vector2.right * shotSpeed);
		}
		else if(this.gameObject.tag == "leftspike")
		{
			rigidbody2D.AddForce(-Vector2.right * shotSpeed);
		}

	}

	void OnCollisionEnter2D (Collision2D other) 
	{
		if(other.gameObject.tag != "Player")
		{
			Destroy(this.gameObject);
		}
		else
		{
			Destroy(this.gameObject, 5.0f);
		}
	}
}
