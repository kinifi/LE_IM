using UnityEngine;
using System.Collections;

public class NoFaithController : MonoBehaviour {

	public GameObject target;
	public bool moving = false;
	private Smooth_Follow _smoothFollow;
	public float lookDistance = 12.0f;
	public bool canMove = true;
	private float downAxis;

	void Start() {
		_smoothFollow = GetComponent<Smooth_Follow>();
	}

	void Update () 
	{

		if(canMove)
		{

			if(Input.GetButton("Fire3"))
			{
				if(moving == false)
				{
					//Debug.Log("get key true");
					iTween.MoveAdd(this.gameObject, new Vector3(0f, -lookDistance, 0f), 0.2f);
					moving = true;
					_smoothFollow.movingCamera = true;
				}
			}
			if(Input.GetButton("Fire3") == false)
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

	private void smoothFollowFalse() {
		_smoothFollow.movingCamera = false;
		moving = false;
	}
}
