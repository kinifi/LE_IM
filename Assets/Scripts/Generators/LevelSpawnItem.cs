using UnityEngine;
using System.Collections;

public class LevelSpawnItem : MonoBehaviour {

	// On 'Start' instantiate an item to aid the player.
	void Start () 
	{
		RoomTypeZero getTileofRoom = GameObject.Find("Matrix00").GetComponent<RoomTypeZero>();
		int itemSpawn = Random.Range(1,101);
		if(itemSpawn < 51)
		{
			//Instantiates bow block.
			Instantiate(getTileofRoom.tileOfRoom[21], this.gameObject.transform.position, Quaternion.identity);
		}
		else if(itemSpawn > 50 && itemSpawn < 91)
		{
			//Instantiates key block.
			Instantiate(getTileofRoom.tileOfRoom[11], this.gameObject.transform.position, Quaternion.identity); 
		}
		else if(itemSpawn > 90)
		{
			//Instantiates golden bow block.
			Instantiate(getTileofRoom.tileOfRoom[23], this.gameObject.transform.position, Quaternion.identity);
		}
	}
}
