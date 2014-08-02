using UnityEngine;
using System.Collections;

public class DeathBySpikes : MonoBehaviour {

	public GameObject deathMessage;
	public GameObject kill;


	void OnCollisionEnter2D (Collision2D Player) 
	{
		if(Player.gameObject.tag == "Player")
		{
			Transform currentTransform = GameObject.Find("Player").GetComponent<Transform>();
			if(kill == null)
			{
				kill = Instantiate(deathMessage, currentTransform.position, Quaternion.identity) as GameObject;
				kill.transform.parent = currentTransform;
				//Debug.Log ("You were killed by spikes!!");
				GameObject resetRobbe = GameObject.Find ("Player");
				Vector2 resetTransform = new Vector2(-3.95f, -1.0f);
				resetRobbe.transform.position = resetTransform;
				Destroy(kill, 2.5f);
			}
		}
	}
}
