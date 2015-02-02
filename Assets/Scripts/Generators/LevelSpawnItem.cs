using UnityEngine;
using System.Collections;

public class LevelSpawnItem : MonoBehaviour {

	// On 'Start' instantiate an item to aid the player.
	void Start () 
	{
		RoomTypeZero getTileofRoom = GameObject.Find("Matrix00").GetComponent<RoomTypeZero>();
		int randomPlayerHelper = Random.Range (0,3);
		{
			switch(randomPlayerHelper)
			{
			case 0:
				//Instantiates golden bow block.
				Instantiate(getTileofRoom.tileOfRoom[23], this.gameObject.transform.position, Quaternion.identity);
				break;
			case 1:
				//Instantiates key block.
				Instantiate(getTileofRoom.tileOfRoom[11], this.gameObject.transform.position, Quaternion.identity);
				break;
			case 2:
				//Instantiates bow block.
				Instantiate(getTileofRoom.tileOfRoom[21], this.gameObject.transform.position, Quaternion.identity);
				break;
			default:
				//Instantiates bow block.
				Instantiate(getTileofRoom.tileOfRoom[21], this.gameObject.transform.position, Quaternion.identity);
				break;
			}
		}
	}
}
