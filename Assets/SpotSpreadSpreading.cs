using UnityEngine;
using System.Collections;

public class SpotSpreadSpreading : MonoBehaviour {

	public float spotSpeed;
	private bool hasCollided = false;



	void Start ()
	{
		string shotName = this.gameObject.name;
		if(this.gameObject.tag == "spotspread")
		{
			switch(shotName)
			{
			case "topSpot":
			{
				rigidbody2D.AddForce(new Vector2(-1.0f, 0.5f) * spotSpeed);
				break;
			}
			case "bottomSpot":
			{
				rigidbody2D.AddForce(new Vector2(1.0f, 0.5f) * spotSpeed);
				break;
			}
			default:
			{
				rigidbody2D.AddForce(Vector2.up * spotSpeed);
				break;
			}
			}
		}
		else if(this.gameObject.tag == "spotspreadtop")
		{
			switch(shotName)
			{
			case "topSpot":
			{
				rigidbody2D.AddForce(new Vector2(-0.5f, -1.0f) * spotSpeed);
				break;
			}
			case "bottomSpot":
			{
				rigidbody2D.AddForce(new Vector2(0.5f, -1.0f) * spotSpeed);
				break;
			}
			default:
			{
				rigidbody2D.AddForce(-Vector2.up * spotSpeed);
				break;
			}
			}
		}
		else if(this.gameObject.tag == "spotspreadright")
		{
			switch(shotName)
				{
				case "topSpot":
				{
					rigidbody2D.AddForce(new Vector2(1.05f, 0.5f) * spotSpeed);
					break;
				}
				case "bottomSpot":
				{
					rigidbody2D.AddForce(new Vector2(1.0f, -0.5f) * spotSpeed);
					break;
				}
				default:
				{
					rigidbody2D.AddForce(Vector2.right * spotSpeed);
					break;
				}
			}
		}
		else if(this.gameObject.tag == "spotspreadleft")
		{
			switch(shotName)
				{
				case "topSpot":
				{
					rigidbody2D.AddForce(new Vector2(-1.05f, 0.5f) * spotSpeed);
					break;
				}
				case "bottomSpot":
				{
					rigidbody2D.AddForce(new Vector2(-1.0f, -0.5f) * spotSpeed);
					break;
				}
				default:
				{
					rigidbody2D.AddForce(-Vector2.right * spotSpeed);
					break;
				}
				}
		}
	}
	
	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.gameObject.tag == "Player")
		{
			DeathByShots();
		}
		else if(other.gameObject.tag != "Player")
		{
			Destroy(this.gameObject);
		}
	}
	
	void OnCollisionEnter2D (Collision2D other)
	{
		if(other.gameObject.tag != "Player")
		{
			Destroy(this.gameObject);
			
		}
		else if(other.gameObject.tag == "Player")
		{
			DeathByShots();
		}
	}
	
	private void DeathByShots()
	{
		if(!hasCollided)
		{
			//Set hasCollided to true to prevent multiple kills
			hasCollided = true;
			//Invoke the reset for hasCollided
			Invoke("InvokeReset", 0.25f);
			//Let me know you were killed by spikes
			Debug.Log ("You were killed by a Spot Shot!!");
			//Call Death Script on Player
			GameObject.Find("Player").GetComponent<RobbeController>().DelayAllowMovement();
		}
	}

	private void InvokeReset()
	{
		hasCollided = false;
	}
}
