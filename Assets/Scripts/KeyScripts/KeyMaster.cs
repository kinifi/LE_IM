using UnityEngine;
using System.Collections;

public class KeyMaster : MonoBehaviour {



	void OnTriggerEnter2D (Collider2D Player) 
	{
		Inventory keysOnRing = GameObject.Find("Player").GetComponent<Inventory>();
		if(keysOnRing.Keys > 0)
		{
			Destroy(this.gameObject);
			SteamManager.StatsAndAchievements.Unlock_Pick_Lock_Pro_Achievement();
			keysOnRing.Keys -= 1;
			keysOnRing.startCollectTimer = true;
			//Debug.Log (keysOnRing.keys);
		}
	}
}
