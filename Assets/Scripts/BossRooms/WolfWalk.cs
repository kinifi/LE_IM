using UnityEngine;
using System.Collections;

public class WolfWalk : MonoBehaviour {

	//Configs for walk
	public bool facingRight = false;
	private float moveSpeed = 3.0f;

	//Configs for Breath Motor
	private HingeJoint2D breathHinge;
	private JointMotor2D breathMotor;

	// Use this for initialization
	void Awake () 
	{
		BreathJointSetup();
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(faceRight)
		{
			transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
		}
		else
		{
			transform.Translate(-Vector3.right * Time.deltaTime * moveSpeed);
		}	}

	private void BreathJointSetup ()
	{
		//Get Component
		breathHinge = GameObject.Find ("WolfAttachtoParticles").GetComponent<HingeJoint2D>();
		breathMotor = breathHinge.motor;
		
		breathMotor.motorSpeed = 90.0f;
		breathMotor.maxMotorTorque = 20.0f;	
		breathHinge.motor = breathMotor;
		
		Debug.Log("Motor Speed Set: "+breathHinge.motor.motorSpeed);
		
		Invoke ("BreathBack", 1.5f);
	}

	private void BreathBack ()
	{
		breathMotor.motorSpeed = -90.0f;
		breathMotor.maxMotorTorque = 50.0f;
		breathHinge.motor = breathMotor;
		
		Invoke ("BreathForward", 0.5f);
	}

	private void BreathForward ()
	{
		breathMotor.motorSpeed = 90.0f;
		breathMotor.maxMotorTorque = 1000.0f;
		breathHinge.motor = breathMotor;
		
		Invoke ("BreathBack", 0.5f);
	}
}
