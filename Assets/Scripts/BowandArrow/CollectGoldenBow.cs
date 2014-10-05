using UnityEngine;
using System.Collections;

public class CollectGoldenBow : MonoBehaviour {

	private int bowCounter = 0;
	void OnTriggerEnter2D (Collider2D Player) 
	{
		if(Player.gameObject.tag == "Player")
		{
			//Debug.Log("You grabbed a golden bow!");
			Inventory arrowCount = GameObject.Find("Player").GetComponent<Inventory>();
			arrowCount.Arrows += 5;
			arrowCount.startCollectTimer = true;
			Debug.Log (arrowCount.Arrows);


			Quiver bowCount = GameObject.Find("Player").GetComponent<Quiver>();
			bowCount.bow += 5;
			//bowCount.addArrows(5);
			bowCounter +=5;
			//Debug.Log (bowCount.bow + bowCounter);
		}
	}
}
