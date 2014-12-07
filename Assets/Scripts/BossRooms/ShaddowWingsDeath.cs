using UnityEngine;
using System.Collections;

public class ShaddowWingsDeath : MonoBehaviour {

	//Components to get
	private int _wingsLeft;

	//Audio Configs
	public AudioClip[] shaddowWingsSounds;
	
	//Death Configs
	public GameObject kill;
	public GameObject deathSplash;
	public GameObject bowGolden;
	
	private void OnTriggerEnter2D (Collider2D other)
	{
		if(other.gameObject.tag == "Player")
		{
			//Stop all movement of the bad guy!!
			this.gameObject.rigidbody2D.isKinematic = true;
			
			if(kill == null)
			{
				//Debug.Log ("You were killed by a bad guy!!");
				
				//Failsafe enable movement
				GameObject.Find("Player").GetComponent<RobbeController>().DelayAllowMovement();
				
				//Instantiate the death splash and overlay Robbe.  Destroy it and call the movement function.
				GameObject resetRobbe = GameObject.Find ("Player");
				kill = Instantiate(deathSplash, resetRobbe.transform.position, Quaternion.identity) as GameObject;
				kill.transform.OverlayPosition(resetRobbe.transform);
				kill.transform.localScale = new Vector3(50.0f,50.0f,1.0f);
				
				Destroy(kill, 1.0f);
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
				_wingsLeft = GameObject.Find ("DepthsBossProfile").GetComponent<DepthsBossMovement>().perlWings;
				_wingsLeft -= 1;
				GameObject.Find ("DepthsBossProfile").GetComponent<DepthsBossMovement>().perlWings = _wingsLeft;
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
