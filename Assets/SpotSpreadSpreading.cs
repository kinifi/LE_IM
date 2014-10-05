using UnityEngine;
using System.Collections;

public class SpotSpreadSpreading : MonoBehaviour {

	public float spotSpeed;
	public GameObject deathMessage;
	public GameObject kill;
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
			DeathbySpikes();
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
			Destroy(this.gameObject, 1.0f);
		}
	}
	
	private void DeathbySpikes()
	{
		//Stop all movement of Spike Cannon.
		this.rigidbody2D.isKinematic = true; 
		
		if(kill == null)
		{
			
			if(!hasCollided)
			{
				hasCollided = true;
				
				Invoke("InvokeReset", 0.2f);
				
				//Debug.Log ("You were killed by a cannon spike!!");
				
				//Find Robbe's gameobject and set his transform to the Spawn Location.
				GameObject resetRobbe = GameObject.Find ("Player");
				GameObject respawn = GameObject.Find("Spawn_Location");
				resetRobbe.transform.position = respawn.transform.position;
				
				//Find Robbe's controller and prevent his movement.
				RobbeController _robbe = GameObject.Find("Player").GetComponent<RobbeController>();
				_robbe.enabled = false;
				
				//Find the LookDown camera and prevent its movement.
				NoFaithController _lookdown = GameObject.Find("Camera").GetComponent<NoFaithController>();
				_lookdown.enabled = false;
				
				//Instantiate the death splash and overlay Robbe.  Destroy it and call the movement function.
				kill = Instantiate(deathMessage, resetRobbe.transform.position, Quaternion.identity) as GameObject;
				kill.transform.OverlayPosition(resetRobbe.transform);
				kill.transform.localScale = new Vector3(50.0f,50.0f,1.0f);
				
				Destroy(kill, 2.5f);
				Invoke("AllowRobbesMovement", 2.5f);
			}
		}
	}
	
	private void AllowRobbesMovement() 
	{
		//Find Robbe and allow his movement again.  Turn kinematic to false.
		RobbeController _robbe = GameObject.Find("Player").GetComponent<RobbeController>();
		_robbe.enabled = true;
		
		//Find the LookDown camera and allow its movement.
		NoFaithController _lookdown = GameObject.Find("Camera").GetComponent<NoFaithController>();
		_lookdown.enabled = true;
		
		//Destory the spike :)
		Destroy(this.gameObject);
	}

	private void InvokeReset()
	{
		hasCollided = false;
	}
}
