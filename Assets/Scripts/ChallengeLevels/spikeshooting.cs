using UnityEngine;
using System.Collections;

public class spikeshooting : MonoBehaviour {

	public float shotSpeed;
	private bool hasCollided = false;
	
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
		if(other.gameObject.tag == "Player")
		{
			Destroy(this.gameObject);
		}
	}

}
