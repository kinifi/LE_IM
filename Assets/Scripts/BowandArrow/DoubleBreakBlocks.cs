using UnityEngine;
using System.Collections;

public class DoubleBreakBlocks : MonoBehaviour {

	private int hits = 0;

	void OnCollisionEnter2D (Collision2D thrownArrows) 
	{

		if(thrownArrows.gameObject.tag == "Arrow")
		{
			hits +=1;

			//Debug.Log ("Arrow Tag Detected");
			Destroy(thrownArrows.gameObject);

			 if(hits >= 2)
			{
				Destroy(this.gameObject);
			}
		}
	}
}
