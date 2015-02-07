using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StoryTextBehaviour : MonoBehaviour {

	//Configs
	public float speed = 0.15f;

	//Sine wave configs
	float amplitudeX = 10.0f;
	float amplitudeY = 5.0f;
	float omegaX = 1.0f;
	float omegaY = 5.0f;
	float index;

	//story GameObject configs
	private Text storyText;
	private int nextChar = 0;

	//story chapter configs
	private string storyString = "The ball shot up in the air, but Jack fell flat on his back. 'Are you okay?!' Robbe rushed over. 'Ha ha! Ya, I'm fine' Jack replied still lying on the ground.";
	private char[] storyChar;
	private int storyCharLength;

	// Use this for initialization
	void Start () 
	{
		Debug.Log ("We've started");

		storyText = GetComponent<Text>();

		storyChar = storyString.ToCharArray();
		storyCharLength = storyChar.Length;

		InvokeRepeating("PrintStory", 0.5f, speed);
	}
	
	// Update is called once per frame
	void PrintStory () 
	{


		if(nextChar < storyCharLength)
		{
			storyText.text += storyChar[nextChar];

			index += 0.125f;
			float x = amplitudeX*Mathf.Cos (omegaX*index);
			float y = Mathf.Abs (amplitudeY*Mathf.Sin (omegaY*index));

			storyText.transform.localPosition = new Vector3(x,y,0);

			nextChar += 1;

		}
		else
		{
			OnComplete();
		}

	}

	void OnComplete()
	{
		CancelInvoke();
		Debug.Log ("We're finished!!!");
		InvokeRepeating("MovingText", 0.025f, speed);
	}

	private void MovingText ()
	{
		index += 0.025f;
		float x = amplitudeX*Mathf.Cos (omegaX*index);
		float y = Mathf.Abs (amplitudeY*Mathf.Sin (omegaY*index));
		
		storyText.transform.localPosition = new Vector3(x,y,0);
	}
}
