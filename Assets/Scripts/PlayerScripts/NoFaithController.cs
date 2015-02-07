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

		if(canMove)
		{

			if(Input.GetButton("LookDown"))
			{
				if(moving == false)
				{
					//Debug.Log("get key true");
					iTween.MoveAdd(this.gameObject, new Vector3(0f, -lookDistance, 0f), 0.2f);
					moving = true;
				}
			}
			if(Input.GetButton("LookDown") == false)
			{
				if(moving == true)
				{
					//Debug.Log("get key false");
					iTween.MoveTo(this.gameObject, iTween.Hash("position", new Vector3(target.transform.position.x, target.transform.position.y, -10), "time", 0.2, "oncompletetarget", this.gameObject, "oncomplete", "smoothFollowFalse"));
					moving = false;
				}
			}
		}
	}

	private void smoothFollowFalse() 
	{
		moving = false;
	}
}
