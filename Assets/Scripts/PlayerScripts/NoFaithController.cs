using UnityEngine;
using System.Collections;

public class NoFaithController : MonoBehaviour {

	public GameObject target;
	public bool moving = false;
	public float lookDistance = 12.0f;
	public bool canMove = true;
	private float downAxis;

	void Update () 
	{
		if(moving == false)
		{
			UpdateCameraPosition();
		}
	}

	private void UpdateCameraPosition()
	{
		if(canMove)
		{
			
			if(Input.GetButton("LookDown"))
			{
				moving = true;
				//Debug.Log("get key true");
				iTween.MoveAdd(this.gameObject, new Vector3(0f, -lookDistance, 0f), 0.2f);

			}
			if(Input.GetButtonUp("LookDown"))
			{
				smoothFollowFalse();
			}
		}
	}

	private void smoothFollowFalse() 
	{
		moving = false;
		//Debug.Log("get key false");
		iTween.MoveTo(this.gameObject, iTween.Hash("position", new Vector3(target.transform.position.x, target.transform.position.y, -10), "time", 0.2, "oncompletetarget", this.gameObject, "oncomplete", "smoothFollowFalse"));
		moving = false;
	}
}
