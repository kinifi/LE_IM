using UnityEngine;
using System.Collections;

public class KeyMaster : MonoBehaviour {



	void OnCollisionEnter2D (Collision2D Player) 
	{
		Inventory keysOnRing = GameObject.Find("Player").GetComponent<Inventory>();
		if(keysOnRing.Keys > 0)
		{
			Destroy(this.gameObject);
			keysOnRing.Keys -= 1;
			keysOnRing.startCollectTimer = true;
			//Debug.Log (keysOnRing.keys);
		}
	}
}
