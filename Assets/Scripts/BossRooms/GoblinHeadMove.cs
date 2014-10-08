using UnityEngine;
using System.Collections;

public class GoblinHeadMove : MonoBehaviour {

	//Components to get
	private HingeJoint2D headHinge;
	private JointMotor2D headMotor;

	//Death Configs
	public GameObject kill;
	public GameObject deathSplash;

	void Start ()
	{
		//Get Component
		headHinge = GameObject.Find ("GoblinBossHead").GetComponent<HingeJoint2D>();
		headMotor = headHinge.motor;

		headMotor.motorSpeed = 5.0f;
		headMotor.maxMotorTorque = 20.0f;	
		headHinge.motor = headMotor;

		Debug.Log("Motor Speed Set: "+headHinge.motor.motorSpeed);

		Invoke ("TiltHeadBack", 1.5f);
	}

	void TiltHeadBack ()
	{
		headMotor.motorSpeed = -5.0f;
		headMotor.maxMotorTorque = 50.0f;
		headHinge.motor = headMotor;

		Invoke ("TiltHeadForward", 2.5f);
	}

	void TiltHeadForward ()
	{
		headMotor.motorSpeed = 5.0f;
		headMotor.maxMotorTorque = 1000.0f;
		headHinge.motor = headMotor;
		
		Invoke ("TiltHeadBack", 2.5f);
	}

	private void OnTriggerEnter2D (Collider2D other)
	{
		if(other.gameObject.tag == "Player")
		{
			//Stop all movement of the bad guy!!
			this.gameObject.rigidbody2D.isKinematic = true;
			
			if(kill == null)
			{
				//Debug.Log ("You were killed by a bad guy!!");
				
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
				kill = Instantiate(deathSplash, resetRobbe.transform.position, Quaternion.identity) as GameObject;
				kill.transform.OverlayPosition(resetRobbe.transform);
				kill.transform.localScale = new Vector3(50.0f,50.0f,1.0f);
				
				Destroy(kill, 2.5f);
				Invoke("AllowRobbesMovement", 2.5f);
			}
		}
	}
	
	private void AllowRobbesMovement() 
	{
		//Allow movement of the bad guy again
		this.gameObject.rigidbody2D.isKinematic = false;
		
		//Find Robbe and allow his movement again.  Turn kinematic to false.
		RobbeController _robbe = GameObject.Find("Player").GetComponent<RobbeController>();
		_robbe.enabled = true;
		
		//Find the LookDown camera and allow its movement.
		NoFaithController _lookdown = GameObject.Find("Camera").GetComponent<NoFaithController>();
		_lookdown.enabled = true;
	}
}
