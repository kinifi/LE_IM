using UnityEngine;
using System.Collections;

public class LevelSpawnItem : MonoBehaviour {

	// On 'Start' instantiate an item to aid the player.
	void Start () 
	{
		RoomTypeZero getTileofRoom = GameObject.Find("Matrix00").GetComponent<RoomTypeZero>();
		//Instantiates golden bow block.
		Instantiate(getTileofRoom.tileOfRoom[23], this.gameObject.transform.position, Quaternion.identity);

	}
}
