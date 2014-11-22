using UnityEngine;
using System.Collections;

public class RobbeAnimate : MonoBehaviour {

	//Robbe animation configs
	Animator anim;
	Animator polaroidAnim;
	private GameObject _robbe;
	private GameObject _photoPoint;
	public ParticleSystem _photo;

	//Robbe text configs
	public GameObject[] textObjects;
	private GameObject textOff;
	
	public Transform photoPosition;
	private Vector3 nextPosition;
	private float speed = 5.0f;
	private bool moveRobbe = false;
	private bool stopUpdateCall = false;

	// Use this for initialization
	void Start () 
	{
		//Get Componenets and Objects
		_robbe = GameObject.Find ("Robbe_Intro");
		anim = GameObject.Find ("Robbe_Intro").GetComponent<Animator>();
		polaroidAnim = GameObject.Find ("PolaroidGrow").GetComponent<Animator>();
		_photoPoint = GameObject.Find ("PointofPhoto");

		//Upkeep
		moveRobbe = false;

		//Begin Scene Animations
		Invoke ("SetRobbe", 1.0f);	
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Moves Robbe to the right and controls the run animation
		if(moveRobbe == true)
		{
			anim.SetBool("PhotoInTarget", true); //the photo particle is at the target and robbe is running
			nextPosition = GameObject.Find ("Robbe_Intro").transform.position;
			nextPosition.x = (nextPosition.x + speed * Time.deltaTime);
			GameObject.Find ("Robbe_Intro").transform.position = nextPosition;
		}

		//Once Robbe moves to the photo, controls bend animation, and starts large polaroid
		if(nextPosition.x >= photoPosition.position.x && stopUpdateCall != true)
		{
			//Stops Robbe's movement and running animation
			moveRobbe = false;
			anim.SetBool("PhotoInTarget", false); //Robbe needs to stop running

			anim.SetBool("RobbeToPhoto", true); //Robbe is at the photo and needs to bend
			//Invokes Act 3
			Invoke ("PolaroidGrow", 1.0f);
			//prevents this from running again
			stopUpdateCall = true;
		}
	}

	//Act1
	private void SetRobbe ()
	{
		//Displays first text
		TurnOnText(textObjects[0]);
		//Starts the photo particle
		_photo.Play();
		Debug.Log ("The photo is falling!");
		//Invokes Act 2
		Invoke("Polaroid", 4.0f);
	}

	//Act 2 part 1
	private void Polaroid ()
	{
		//Displays the second text
		TurnOnText(textObjects[1]);
		//Moves robbe after a time
		Invoke ("MoveRobbe", 3.0f);
	}

	//Act 2 part 2
	private void MoveRobbe ()
	{
		//Stops the photo particle
		_photo.Stop();
		//Starts Robbe's movement controlled in update
		moveRobbe = true;
	}

	//Act 3 part 1
	private void PolaroidGrow ()
	{
		anim.SetBool("RobbeBendToPhoto", true); //Robbe has bent to the photo and needs to return to idel state

		//Grows large polaroid
		polaroidAnim.enabled = true;
		Debug.Log ("The large polaroid should be growing");

		//Displays the third text
		TurnOnText(textObjects[2]);
		//Turns off the large polaroid
		Invoke ("PolaroidReset", 5.0f);
	}
	//Act 3 part 2
	private void PolaroidReset ()
	{
		moveRobbe = true;
		//Starts first dungeon
		Invoke("LaunchGame", 2.0f);
	}

	//Starts first dungeon
	private void LaunchGame ()
	{
		Debug.Log("Launching first Dungeon");
	}

	//Controls the Sprite Renderer state - on
	private void TurnOnText (GameObject textOn)
	{
		textOn.GetComponent<SpriteRenderer>().enabled = true;
		textOff = textOn;
		Invoke("TurnOffText", 2.0f);
	}

	//Controls the Sprite Renderer state - off
	private void TurnOffText ()
	{
		textOff.GetComponent<SpriteRenderer>().enabled = false;
	}

}
