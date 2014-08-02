using UnityEngine;
using System.Collections;

public class CollectBow : MonoBehaviour {

	private string objectToFind = "Player";
	private int bowCounter = 0;
	void OnCollisionEnter2D (Collision2D Player) 
	{
		if(Player.gameObject.tag == "Player")
		{
			Destroy(this.gameObject);
			//Debug.Log("You grabbed a bow!");
			Quiver bowCount = GameObject.Find(objectToFind).GetComponent<Quiver>();
			bowCount.bow += 1;
			bowCount.addArrows(1);

			bowCounter +=1;
			//Debug.Log (bowCount.bow + bowCounter);
		}
	}
}
