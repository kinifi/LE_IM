using UnityEngine;
using System.Collections;

public class WolfStenchDeath : MonoBehaviour {

	//Death Configs
	public GameObject kill;

	private void OnTriggerEnter2D (Collider2D other)
	{
		if(other.gameObject.tag == "Player")
		{
			//Stop all movement of the bad guy!!
			this.gameObject.rigidbody2D.isKinematic = true;
			
			if(kill == null)
			{
				//Let me know you were killed by Wolf Stench
				Debug.Log ("You were killed by Wolf Stench!!");
				//Call Death Script on Player
				GameObject.Find("Player").GetComponent<RobbeController>().DelayAllowMovement();
			}
		}
	}

	private void OnCollisionEnter2D (Collision2D other)
	{
		if(other.gameObject.tag == "Player")
		{
			//Stop all movement of the bad guy!!
			this.gameObject.rigidbody2D.isKinematic = true;
			
			if(kill == null)
			{
				//Let me know you were killed by the Wolf Stench
				Debug.Log ("You were killed by the Wolf Stench!!");
				//Call Death Script on Player
				GameObject.Find("Player").GetComponent<RobbeController>().DelayAllowMovement();
			}
		}
	}
}
