using UnityEngine;
using System.Collections;

public class CollectKey : MonoBehaviour {

		
	void OnTriggerEnter2D (Collider2D Player) 
	{
		if(Player.gameObject.tag == "Player")
		{
			Destroy(this.gameObject);
			//Debug.Log("You found a key!");
			Inventory keyCount = GameObject.Find("Player").GetComponent<Inventory>();
			keyCount.Keys += 1;
			keyCount.startCollectTimer = true;
			Debug.Log (keyCount.Keys);
		}
	}
}