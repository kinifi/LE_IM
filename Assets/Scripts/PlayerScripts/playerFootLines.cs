using UnityEngine;
using System.Collections;

public class playerFootLines : MonoBehaviour {

	public Transform Foot;

	// Use this for initialization
	void Start () {
	
	}

	void OnDrawGizmosSelected() {
		if(Foot != null)
		{
			Gizmos.color = Color.blue;
			Gizmos.DrawLine(transform.position, Foot.transform.position);
		}
		else
		{
			Debug.Log("Assign a Foot Transform to " + this.transform.name);
		}
	}

}
