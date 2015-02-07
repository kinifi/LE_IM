using UnityEngine;
using System.Collections;

public class ShaddowWingsDeath : MonoBehaviour {

	//Components to get
	private int _perlWings;

	//Audio Configs
	public AudioClip[] shaddowWingsSounds;
	
	//Death Configs
	public GameObject kill;
	public GameObject bowGolden;
	
	void Awake ()
	{
		_perlWings = GameObject.Find ("DepthsBossProfile").GetComponent<DepthsBossMovement>().perlWings;
	}

	private void OnTriggerEnter2D (Collider2D other)
	{
		if(other.gameObject.tag == "Player")
		{
			//Stop all movement of the bad guy!!
			this.gameObject.rigidbody2D.isKinematic = true;
			
			if(kill == null)
			{
				//Let me know you were killed by Shaddow Wings
				Debug.Log ("You were killed by Shaddow Wings!!");
				//Call Death Script on Player
				GameObject.Find("Player").GetComponent<RobbeController>().DelayAllowMovement();
			}
		}
		
		else if(other.gameObject.tag == "Arrow")
		{
			//Play audio
			audio.PlayOneShot(shaddowWingsSounds[0], 1.0f);
			//Get position for bow drop
			Vector3 pos = transform.position;
			//Destroy Arrow
			Destroy(other.gameObject);
			//Check if Boss Level
			if(GameObject.Find ("DepthsBossProfile") != null)
			{
				_perlWings -= 1;
				Debug.Log ("The number of wings left is: " + _perlWings);
			}
			//chance of drop
			int drop = Random.Range(1,6);
			//drop
			if(drop == 5)
			{
				Instantiate(bowGolden, pos, Quaternion.identity);
			}
			//Destroy object
			Invoke ("DestroyObject", 1.0f);
		}
	}
	
	private void DestroyObject ()
	{
		Destroy (this.gameObject);
	}
}
