using UnityEngine;
using System.Collections;

public class CameraFollowNew : MonoBehaviour {

	public Transform target;
	public float smoothTime = 0.3f;
	public float lookDistance = 4.0f;
	private Transform thisTransform;
	private Vector2 velocity;
	private bool isDown = false;
	
	private void Start()
	{
		thisTransform = transform;
	}
	
	private void Update() 
	{
		if(Input.GetButton("LookDown"))
		{
			LookDown();
		}
		else
		{
			SmoothCamera();
		}
	}

	private void SmoothCamera ()
	{
		//set isDown to false
		isDown = false;
		//Continue with Camera
		Vector3 vec = thisTransform.position;
		vec.x = Mathf.SmoothDamp( thisTransform.position.x, 
		                         target.position.x, ref velocity.x, smoothTime);
		vec.y = Mathf.SmoothDamp( thisTransform.position.y, 
		                         target.position.y, ref velocity.y, smoothTime);
		thisTransform.position = vec;
	}

	private void LookDown ()
	{
		if(isDown == false)
		{
			isDown = true;
			//Debug.Log("get key true");
			iTween.MoveAdd(this.gameObject, new Vector3(0f, -lookDistance, 0f), 0.5f);
		}
	}
}
