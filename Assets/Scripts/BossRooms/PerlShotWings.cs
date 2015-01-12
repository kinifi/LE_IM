using UnityEngine;
using System.Collections;

public class PerlShotWings : MonoBehaviour {

	//Components to get
	private HingeJoint2D wingHinge;
	private JointMotor2D wingMotor;
	private int _perlWings;

	//AI Configs
	private float nextFlight = 1.0f;

	//Audio Configs
	public AudioClip[] wingsSounds;

	//Death Configs
	public GameObject kill;
	public GameObject deathSplash;
	public GameObject bowGolden;

	void Awake ()
	{
		_perlWings = GameObject.Find ("DepthsBossProfile").GetComponent<DepthsBossMovement>().perlWings;
	}

	// Use this for initialization
	void Start () 
	{
		//Get Motor Components
		wingHinge = GameObject.Find ("ShaddowWingsBack").GetComponent<HingeJoint2D>();
		wingMotor = wingHinge.motor;
		
		//Set Motor Configs
		wingMotor.motorSpeed = 50.0f;
		wingMotor.maxMotorTorque = 5000.0f;	
		wingHinge.motor = wingMotor;
		
		//Debug
		//Debug.Log("Motor Speed Set: "+wingHinge.motor.motorSpeed);
		
		//Invoke WingsDown
		Invoke ("WingsFlightDown", 1.5f);
	}
	
	private void WingsFlightDown ()
	{
		//Change Motor Configs
		wingMotor.motorSpeed = -50.0f;
		wingMotor.maxMotorTorque = 1000.0f;
		//Set Motor
		wingHinge.motor = wingMotor;
		//Invoke WingsUp
		Invoke ("WingsFlightUp", nextFlight);
	}

	private void WingsFlightUp ()
	{
		//Change Motor Configs
		wingMotor.motorSpeed = 50.0f;
		wingMotor.maxMotorTorque = 5000.0f;
		//Set Motor
		wingHinge.motor = wingMotor;
		//Invoke WingsUp
		Invoke ("WingsFlightDown", nextFlight);	
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
		
		else if(other.gameObject.tag == "Arrow")
		{
			//Play audio
			audio.PlayOneShot(wingsSounds[0]);
			//Get position for bow drop
			Vector3 pos = transform.position;
			//Destroy Arrow
			Destroy(other.gameObject);
			//Decrease perlwings count
			if(GameObject.Find ("DepthsBossProfile") != null)
			{
				_perlWings -= 1;
				Debug.Log ("The number of wings left is: " + _perlWings);
			}
			//chance of drop
			int drop = Random.Range(1,6);
			//drop
			if(drop == 5)
			{
				Instantiate(bowGolden, pos, Quaternion.identity);
			}
			//Destroy object
			Invoke ("DestroyObject", 0.45f);
		}
	}

	private void DestroyObject ()
	{
		Destroy (this.gameObject);
	}
	                          
}
