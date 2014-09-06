using UnityEngine;
using System.Collections;

public class BreakBlocks : MonoBehaviour {

	void OnCollisionEnter2D (Collision2D thrownArrows) 
	{

		if(thrownArrows.gameObject.tag == "Arrow")
		{
			//Debug.Log ("Arrow Tag Detected");
			Destroy(thrownArrows.gameObject);
			Destroy(this.gameObject);
		}
	}
}
