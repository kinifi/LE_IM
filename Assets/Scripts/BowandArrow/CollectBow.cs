using UnityEngine;
using System.Collections;

public class CollectBow : MonoBehaviour {

	//private string objectToFind = "Player";
	void OnTriggerEnter2D (Collider2D Player) 
	{
		if(Player.gameObject.tag == "Player")
		{
			Debug.Log("You found a bow!");
			Inventory arrowCount = GameObject.Find("Player").GetComponent<Inventory>();
			arrowCount.Arrows += 1;
			arrowCount.startCollectTimer = true;
			Debug.Log (arrowCount.Arrows);

			//Debug.Log("You grabbed a bow!");
			Quiver bowCount = GameObject.Find("Player").GetComponent<Quiver>();
			bowCount.bow += 1;
			//bowCount.addArrows(1);
		}
	}
}
