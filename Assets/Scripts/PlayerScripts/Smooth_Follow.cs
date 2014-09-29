using UnityEngine;
using System.Collections;



public class Smooth_Follow : MonoBehaviour
{
	public Transform target;
	public float smoothDampTime = 0.2f;
	[HideInInspector]
	public new Transform transform;
	public Vector3 cameraOffset;
	public bool useFixedUpdate = false;
	
	private RobbeController _playerController;
	private Vector3 _smoothDampVelocity;
	public bool movingCamera = false;
	
	void Awake()
	{
		transform = gameObject.transform;
		_playerController = target.GetComponent<RobbeController>();
	}
	
	
	void LateUpdate()
	{
		if( !useFixedUpdate )
			updateCameraPosition();
	}
	
	
	void FixedUpdate()
	{
		if( useFixedUpdate )
			updateCameraPosition();
	}
	
	
	void updateCameraPosition()
	{
		if(!movingCamera)
		{
			if( _playerController == null )
			{
				transform.position = Vector3.SmoothDamp( transform.position, target.position - cameraOffset, ref _smoothDampVelocity, smoothDampTime );
				return;
			}
			
			if( _playerController.rigidbody2D.velocity.x > 0 )
			{
				transform.position = Vector3.SmoothDamp( transform.position, target.position - cameraOffset, ref _smoothDampVelocity, smoothDampTime );
			}
			else
			{
				var leftOffset = cameraOffset;
				leftOffset.x *= -1;
				transform.position = Vector3.SmoothDamp( transform.position, target.position - leftOffset, ref _smoothDampVelocity, smoothDampTime );
			}
		}
	}
	
}