using UnityEngine;
using System.Collections;

public class DoubleBreakBlocks : MonoBehaviour {

	private int hits = 0;
	private Color originalColor;

	void Start ()
	{
		originalColor = GetComponent<SpriteRenderer>().color;
	}

	void OnCollisionEnter2D (Collision2D thrownArrows) 
	{

		if(thrownArrows.gameObject.tag == "Arrow")
		{
			hits +=1;

			//Debug.Log ("Arrow Tag Detected");
			Destroy(thrownArrows.gameObject);
			GetComponent<SpriteRenderer>().color = Color.grey;
			Invoke ("RestoreColor", 0.10f);

			 if(hits >= 2)
			{
				Destroy(this.gameObject);
			}
		}
	}

	private void RestoreColor ()
	{
		GetComponent<SpriteRenderer>().color = originalColor;
	}
}
