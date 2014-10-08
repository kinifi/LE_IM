using UnityEngine;
using System.Collections;

public class KeyMaster : MonoBehaviour {

	//Componenets to get
	Inventory _keyCount;
	KeyRing _ringCount;
	RobbeController _playerclips;

	//configs
	private bool canCollect = true;

	void OnTriggerEnter2D (Collider2D other) 
	{
		if(other.gameObject.tag == "Player")
		{
			//Components to get
			_keyCount = GameObject.Find("Player").GetComponent<Inventory>();
			if(_keyCount.Keys > 0 && canCollect == true)
			{
				//Log to steam Achievements
				SteamManager.StatsAndAchievements.Unlock_Pick_Lock_Pro_Achievement();

				//Inventory subtract
				_keyCount.Keys -= 1;
				canCollect = false;
				_keyCount.startCollectTimer = true;
				Debug.Log ("Your key has been removed from the inventory! " + _keyCount.Keys);
				Invoke ("DestroyDoor", 0.5f);
			}
		}
	}

	private void DestroyDoor ()
	{
		//Destroy object
		Destroy(this.gameObject);
	}
}
