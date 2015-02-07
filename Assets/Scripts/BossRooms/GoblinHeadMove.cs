using UnityEngine;
using System.Collections;

public class GoblinHeadMove : MonoBehaviour {

	//Components to get
	private HingeJoint2D headHinge;
	private JointMotor2D headMotor;

	//Death Configs
	public GameObject kill;

	//Hits config
	GoblinBody _hits;

	void Start ()
	{
		//GetHits
		_hits = GameObject.Find("GoblinBody").GetComponent<GoblinBody>();

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
			//Let me know you were killed by the Goblin Boss
			Debug.Log ("You were killed by the Goblin Boss!!");
			//Call Death Script on Player
			GameObject.Find("Player").GetComponent<RobbeController>().DelayAllowMovement();
		}
		if(other.gameObject.tag == "Arrow")
		{
			//Destroy arrow
			Destroy(other.gameObject);

			//Increment hits
			_hits.hits +=1;
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
