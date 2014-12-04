using UnityEngine;
using System.Collections;

public class CollectBow : MonoBehaviour {

	//Componenets to get
	Inventory _arrowCount;
	Quiver _bowCount;

	void OnTriggerEnter2D (Collider2D Player) 
	{
		if(Player.gameObject.tag == "Player")
		{
			Debug.Log ("There should be a bow collected");

			/*//Inventory add
			//Debug.Log("You found a bow!");
			_arrowCount = GameObject.Find("Player").GetComponent<Inventory>();
			_arrowCount.Arrows += 1;
			Debug.Log ("Your Arrow as been inventoried!!!"+_arrowCount.Arrows);

			//Quiver add
			//Debug.Log("You grabbed a bow!");
			_bowCount = GameObject.Find("Player").GetComponent<Quiver>();
			_bowCount.bow += 1;
			Debug.Log ("This is the bow count" + _bowCount.bow);

			_arrowCount.InventoryOnTimer();*/
		}
	}
}