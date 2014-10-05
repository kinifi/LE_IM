using UnityEngine;
using System.Collections;

public class CollectBow : MonoBehaviour {

<<<<<<< HEAD
	//private string objectToFind = "Player";
=======
	//Componenets to get
	Inventory _arrowCount;
	Quiver _bowCount;

>>>>>>> origin/Testing-Branch
	void OnTriggerEnter2D (Collider2D Player) 
	{
		if(Player.gameObject.tag == "Player")
		{
<<<<<<< HEAD
			Debug.Log("You found a bow!");
			Inventory arrowCount = GameObject.Find("Player").GetComponent<Inventory>();
			arrowCount.Arrows += 1;
			arrowCount.startCollectTimer = true;
			Debug.Log (arrowCount.Arrows);
=======

			//Inventory add
			//Debug.Log("You found a bow!");
			_arrowCount = GameObject.Find("Player").GetComponent<Inventory>();
			_arrowCount.Arrows += 1;
			_arrowCount.startCollectTimer = true;
			Debug.Log ("Your Arrow as been inventoried!!!"+_arrowCount.Arrows);
>>>>>>> origin/Testing-Branch

			//Quiver add
			//Debug.Log("You grabbed a bow!");
<<<<<<< HEAD
			Quiver bowCount = GameObject.Find("Player").GetComponent<Quiver>();
			bowCount.bow += 1;
			//bowCount.addArrows(1);
=======
			_bowCount = GameObject.Find("Player").GetComponent<Quiver>();
			_bowCount.bow += 1;

			//Destroy object
			Destroy(this.gameObject);
>>>>>>> origin/Testing-Branch
		}
	}
}
