using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShootOutTargetBehaviour : MonoBehaviour {

	void OnCollisionEnter2D (Collision2D thrownArrows) 
	{
		
		if(thrownArrows.gameObject.tag == "Arrow")
		{
			GameObject.Find ("TargetCount").GetComponent<ShootOutTargetCount>().TargetHit();

			//Debug.Log ("Arrow Tag Detected");
			Destroy(thrownArrows.gameObject);
			Destroy(this.gameObject, 0.15f);
		}
	}
}
