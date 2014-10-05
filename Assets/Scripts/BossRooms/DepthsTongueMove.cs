using UnityEngine;
using System.Collections;

public class DepthsTongueMove : MonoBehaviour {


	//Components to get transform 
	//public Transform _playerTrans;
	public Transform target;
	private Vector3 v_diff;
	private float atan2;


	// Use this for initialization
	void Start () 
	{
		//_playerTrans = GameObject.Find("Player").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		v_diff = (target.position - transform.position);    
		atan2 = Mathf.Atan2 ( -v_diff.y, -v_diff.x );
		transform.rotation = Quaternion.Euler(0f, 0f, atan2 * Mathf.Rad2Deg );
	}
}
