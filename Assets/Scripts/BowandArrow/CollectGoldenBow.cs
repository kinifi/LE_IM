using UnityEngine;
using System.Collections;

public class CollectGoldenBow : MonoBehaviour {

	private int bowCounter = 0;
	void OnTriggerEnter2D (Collider2D Player) 
	{
		if(Player.gameObject.tag == "Player")
		{
			Destroy(this.gameObject);
			//Debug.Log("You grabbed a golden bow!");
			Quiver bowCount = GameObject.Find("Player").GetComponent<Quiver>();
			bowCount.bow += 5;
			//bowCount.addArrows(5);
			bowCounter +=5;
			//Debug.Log (bowCount.bow + bowCounter);
		}
	}
}
