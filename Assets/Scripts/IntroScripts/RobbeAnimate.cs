using UnityEngine;
using System.Collections;

public class RobbeAnimate : MonoBehaviour {

	//Animation configs
	Animator anim;
	Animator polaroidAnim;
	Animator guideAnim;
	//Game Object configs
	private GameObject _robbe;
	private GameObject _photoPoint;

	//Large Polaroid
	private SpriteRenderer _largePolaroidSprite;
	public ParticleSystem _photo;

	//Quick Guide
	private SpriteRenderer _guideSprite;
	public ParticleSystem _guide;
	private bool scaleGuide = false;
	private float smooth = 2.0f;


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
		//Robbe's initialization
		_robbe = GameObject.Find ("Robbe_Intro");
		anim = GameObject.Find ("Robbe_Intro").GetComponent<Animator>();
		//Polaroid initialization
		polaroidAnim = GameObject.Find ("PolaroidGrow").GetComponent<Animator>();
		_largePolaroidSprite = GameObject.Find ("PolaroidGrow").GetComponent<SpriteRenderer>();
		//Guide initialization
		guideAnim = GameObject.Find ("GuideGrow").GetComponent<Animator>();
		_guideSprite = GameObject.Find ("GuideGrow").GetComponent<SpriteRenderer>();
		//Other initalization
		_photoPoint = GameObject.Find ("PointofPhoto");

		//Upkeep
		moveRobbe = false;
		scaleGuide = false;

		//Begin Scene Animations
		Invoke ("StartRobbe", 1.5f);	
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

		//scales guide down
		if(scaleGuide == true)
		{
			//gets the local scale of the guide
			float gX = GameObject.Find ("GuideGrow").transform.localScale.x;
			float gY = GameObject.Find ("GuideGrow").transform.localScale.y;
			float gZ = GameObject.Find ("GuideGrow").transform.localScale.z;

			//checks the scale is not negative
			if(gX > 0.0f)
			{
				//shrinks the value
				gX -= 0.15f;
				gY -= 0.15f;
			}

			//sets the updated value to a temp variable
			Vector3 guideScaleUpdate = new Vector3(gX, gY, gZ);

			//gets the curent position
			Vector3 gPos = GameObject.Find ("GuideGrow").transform.position;
			Vector3 rPos = GameObject.Find ("Robbe_Intro").transform.position;
			//sets the updated position to a temp variable
			GameObject.Find ("GuideGrow").transform.position = Vector3.Lerp(gPos, rPos, smooth * Time.deltaTime);

			//updates the local scale of the guide
			GameObject.Find ("GuideGrow").transform.localScale = guideScaleUpdate;

		}
	}

	//Act1 part1
	private void StartRobbe ()
	{
		//Displays first text
		TurnOnText(textObjects[0]);
		//Starts the photo and guide particle
		_photo.Play();
		Debug.Log ("The photo is falling!");
		_guide.Play ();
		Debug.Log ("The guide is falling!");
		//Invokes Act 1 part 2
		Invoke("StartRobbeB", 2.5f);
	}

	//Act1 part2
	private void StartRobbeB()
	{
		//Displays second text
		TurnOnText(textObjects[1]);
		//Invokes Act 2
		Invoke("Polaroid", 3.0f);
	}

	//Act 2 part 1
	private void Polaroid ()
	{
		//Displays the second text
		TurnOnText(textObjects[2]);
		//Moves robbe after a time Invokes Act 2 part 2
		Invoke ("MoveRobbe", 3.0f);
	}

	//Act 2 part 2
	private void MoveRobbe ()
	{
		//Stops the photo particle
		_photo.Stop();
		//Stops the guide particle
		_guide.Stop();
		//Starts Robbe's movement controlled in update
		moveRobbe = true;
	}

	//Act 3 part 1a
	private void PolaroidGrow ()
	{
		anim.SetBool("RobbeBendToPhoto", true); //Robbe has bent to the photo and needs to return to idel state

		//Grows large polaroid
		_largePolaroidSprite.enabled = true;
		polaroidAnim.enabled = true;
		Debug.Log ("The large polaroid should be growing");

		//Displays the third text
		TurnOnText(textObjects[3]);
		//Turns off the large polaroid
		Invoke ("PolaroidGrowB", 2.5f);
	}

	//Act 3 part 1b
	private void PolaroidGrowB ()
	{
		//Displays the fourth text
		TurnOnText(textObjects[4]);
		//Invokes GuideGrow Act3 part2
		Invoke("GuideGrow", 2.5f);
	}

	//Act 3 part 2a
	private void GuideGrow ()
	{
		//Turns off the large polaroid
		_largePolaroidSprite.enabled = false;
		//Grows guide
		_guideSprite.enabled = true;
		guideAnim.enabled = true;
		Debug.Log ("The guide should be growing");
		
		//Displays the fifth text
		TurnOnText(textObjects[5]);
		//Invokes next text
		Invoke ("GuideGrowB", 2.5f);
	}

	//Act 3 part 2b
	private void GuideGrowB ()
	{
		//Displays the fifth text
		TurnOnText(textObjects[6]);
		//Invokes the Guide to Shrink
		Invoke ("GuideShrink", 2.5f);
	}

	private void GuideShrink ()
	{
		//Shrings guide
		guideAnim.SetBool("TimeToShrink", true);
		Debug.Log ("Guide should be shrinking.");
		//Sets the update bool to true so the guide shrinks
		scaleGuide = true;
		//Invokes turns off the guide
		Invoke ("GuideReset", 2.5f);
	}

	//Act 3 part 2c
	private void GuideReset ()
	{
		//Sets the update bool to false
		scaleGuide = false;
		//Turn off the guide
		_guideSprite.enabled = false;
		//Display last text and move robbe off
		TurnOnText(textObjects[7]);
		Invoke ("DecideToLeave", 1.75f);
	}
	//Moves Robbe out of the scene and starts the campaign level
	private void DecideToLeave()
	{
		moveRobbe = true;
		//Starts first dungeon
		Invoke("LaunchGame", 1.5f);
	}

	//Starts first dungeon
	private void LaunchGame ()
	{
		Debug.Log("Launching first Dungeon");
		Application.LoadLevel("Tutorial_Dungeon");
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
