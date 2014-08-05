using UnityEngine;
using System.Collections;

public class LevelComplete_Continue : MonoBehaviour {

	public GameObject completeMessage;
	public GameObject robbeContinues;
	private Vector3 correctContinueView;
	
	
	void OnCollisionEnter2D (Collision2D Player) 
	{

		if(Player.gameObject.tag == "Player")
		{
			Transform currentTransform = GameObject.Find("Player").GetComponent<Transform>();
			if(currentTransform.position.x == -1)
			{
				correctContinueView = currentTransform.position * -1;
			}
			else
			{
				correctContinueView = currentTransform.position;
			}			
			if(robbeContinues == null)
			{
				robbeContinues = Instantiate(completeMessage, correctContinueView, Quaternion.identity) as GameObject;
				//robbeContinues.transform.parent = currentTransform;
				robbeContinues.transform.OverlayPosition(currentTransform);
				DontDestroyOnLoad(robbeContinues);

				Vector2 resetTransform = new Vector2(-3.95f, -1.0f);
				currentTransform.position = resetTransform;

				Destroy(robbeContinues, 2.0f);
				Debug.Log ("You completed the level!!");
				Application.LoadLevel("Map_Level_Gen");
			}
		}
	}
}