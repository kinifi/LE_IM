using UnityEngine;
using System.Collections;

public class GoblinArmMove : MonoBehaviour {

	//Transform configs
	public Transform sight1Start, sight1End, sight2Start, sight2End;
	public bool spotted;
	public bool spotted2;
	private bool canBeSpotted = true;
	
	//Configs for speed
	public float speed = 5000.0f;
	private Vector2 sightedSpeed;
	
	//Configs for sight rays
	private Vector2 sightRay1Start;
	private Vector2 sightRay1End;
	private Vector2 sightRay1UpdateStart;
	private Vector2 sightRay1UpdateEnd;
	
	private Vector2 sightRay2Start;
	private Vector2 sightRay2End;
	private Vector2 sightRay2UpdateStart;
	private Vector2 sightRay2UpdateEnd;

	//Config for sight layermask
	public LayerMask goblinSightlayerMask; //make sure we aren't in this layer 

	//AI Configs
	private float nextAttack = 5.0f;

	//Components to get
	private HingeJoint2D armHinge;
	private JointMotor2D armMotor;
	private Vector3 playerPos;
	private Vector3 armPos;

	//Death Configs
	public GameObject kill;
	public GameObject deathSplash;

	void Start ()
	{
		//Get Motor Components
		armHinge = GameObject.Find ("GoblinBossArm").GetComponent<HingeJoint2D>();
		armMotor = armHinge.motor;
		
		//Set Motor Configs
		armMotor.motorSpeed = 45.0f;
		armMotor.maxMotorTorque = 20.0f;	
		armHinge.motor = armMotor;

		//Set Sight Configs
		//Initialize sight ray
		sightRay1Start = sight1Start.position;
		sightRay1End = sight1End.position;

		sightRay2Start = sight2Start.position;
		sightRay2End = sight2End.position;

		//Debug
		//Debug.Log("Motor Speed Set: "+armHinge.motor.motorSpeed);

		//Invoke TiltBack
		Invoke ("TiltArmBack", 1.5f);
		InvokeRepeating("PlayAudio", 1.0f, 10.0f);
	}

	void Update ()
	{
		RaycastMethod();
		Behaviours();
	}

	//Method to draw rays and check bools
	private void RaycastMethod ()
	{
		//Sight Rays
		Debug.DrawLine(sightRay1Start, sightRay1End, Color.red);
		spotted = Physics2D.Linecast(sightRay1Start, sightRay1End, goblinSightlayerMask);
		Debug.DrawLine(sightRay2Start, sightRay2End, Color.yellow);
		spotted2 = Physics2D.Linecast(sightRay2Start, sightRay2End, goblinSightlayerMask);
	}

	//Method to act on bools
	private void Behaviours ()
	{
		if(spotted == true || spotted2 == true)
		{
			//Debug.Log ("Spotted!!!!");

			if(canBeSpotted == true)
			{
				canBeSpotted = false;
				ArmUpFast();
				Invoke ("ArmDownFast", 0.75f);
			}
		}
	}

	private void TiltArmBack ()
	{
		//Change Motor Configs
		armMotor.motorSpeed = -65.0f;
		armMotor.maxMotorTorque = 50.0f;
		//Set Motor
		armHinge.motor = armMotor;
		//Invoke TiltForward
		Invoke ("TiltArmForward", nextAttack);
	}
	
	private void TiltArmForward ()
	{
		//Change Motor Configs
		armMotor.motorSpeed = 55.0f;
		armMotor.maxMotorTorque = 1000.0f;
		//Set Motor
		armHinge.motor = armMotor;
		//Invoke TiltBack
		Invoke ("TiltArmBack", nextAttack);
	}

	private void ArmUpFast()
	{
		//Change Motor Configs
		armMotor.motorSpeed = -500.0f;
		armMotor.maxMotorTorque = 1000.0f;
		//Set Motor
		armHinge.motor = armMotor;
	}

	private void ArmDownFast()
	{
		//Change Motor Configs
		armMotor.motorSpeed = 500.0f;
		armMotor.maxMotorTorque = 100000.0f;
		//Set Motor
		armHinge.motor = armMotor;
		Invoke ("ResetArm", 1.5f);
	}

	private void ResetArm()
	{
		TiltArmBack();
		canBeSpotted = true;
	}

	private void PlayAudio()
	{
		audio.Play();
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
				
				//Failsafe enable movement
				GameObject.Find("Player").GetComponent<RobbeController>().DelayAllowMovement();
				
				//Instantiate the death splash and overlay Robbe.  Destroy it and call the movement function.
				GameObject resetRobbe = GameObject.Find ("Player");
				kill = Instantiate(deathSplash, resetRobbe.transform.position, Quaternion.identity) as GameObject;
				kill.transform.OverlayPosition(resetRobbe.transform);
				kill.transform.localScale = new Vector3(50.0f,50.0f,1.0f);
				
				Destroy(kill, 1.0f);
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
