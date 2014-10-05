using UnityEngine;
using System.Collections;

public class ShaddowSpotSpread : MonoBehaviour {

	//Configs
	public GameObject[] spot;
	public Transform spotSpawn;
	public float fireRate;
	private float nextFire;

	// Use this for initialization
	void Start () 
	{
		Invoke("SpreadShot", 1.0f);
	}
	
	// Update is called once per frame
	void SpreadShot () 
	{
		if (Time.time > nextFire && this.gameObject.tag == "spotspread")
		{
			nextFire = Time.time + fireRate;

			GameObject spotShot1 = Instantiate(spot[0], spotSpawn.position, Quaternion.identity) as GameObject;
			spotShot1.gameObject.tag = "spotspread";
			GameObject spotShot2 = Instantiate(spot[1], spotSpawn.position, Quaternion.identity) as GameObject;
			spotShot2.gameObject.tag = "spotspread";
			spotShot2.gameObject.name = "topSpot";
			GameObject spotShot3 = Instantiate(spot[2], spotSpawn.position, Quaternion.identity) as GameObject;
			spotShot3.gameObject.tag = "spotspread";
			spotShot3.gameObject.name = "bottomSpot";
			//Debug.Log ("Shot fired!");
		}
		if (Time.time > nextFire && this.gameObject.tag == "spotspreadtop")
		{
			nextFire = Time.time + fireRate;

			GameObject spotShot1 = Instantiate(spot[0], spotSpawn.position, Quaternion.identity) as GameObject;
			spotShot1.gameObject.tag = "spotspreadtop";
			GameObject spotShot2 = Instantiate(spot[1], spotSpawn.position, Quaternion.identity) as GameObject;
			spotShot2.gameObject.tag = "spotspreadtop";
			spotShot2.gameObject.name = "topSpot";
			GameObject spotShot3 = Instantiate(spot[2], spotSpawn.position, Quaternion.identity) as GameObject;
			spotShot3.gameObject.tag = "spotspreadtop";
			spotShot3.gameObject.name = "bottomSpot";
			//Debug.Log ("Shot fired!");
		}
		if (Time.time > nextFire && this.gameObject.tag == "spotspreadleft")
		{
			nextFire = Time.time + fireRate;

			GameObject spotShot1 = Instantiate(spot[0], spotSpawn.position, Quaternion.identity) as GameObject;
			spotShot1.gameObject.tag = "spotspreadleft";
			GameObject spotShot2 = Instantiate(spot[1], spotSpawn.position, Quaternion.identity) as GameObject;
			spotShot2.gameObject.tag = "spotspreadleft";
			spotShot2.gameObject.name = "topSpot";
			GameObject spotShot3 = Instantiate(spot[2], spotSpawn.position, Quaternion.identity) as GameObject;
			spotShot3.gameObject.tag = "spotspreadleft";
			spotShot3.gameObject.name = "bottomSpot";
			//Debug.Log ("Shot fired!");
		}
		if (Time.time > nextFire && this.gameObject.tag == "spotspreadright")
		{
			nextFire = Time.time + fireRate;

			GameObject spotShot1 = Instantiate(spot[0], spotSpawn.position, Quaternion.identity) as GameObject;
			spotShot1.gameObject.tag = "spotspreadright";
			GameObject spotShot2 = Instantiate(spot[1], spotSpawn.position, Quaternion.identity) as GameObject;
			spotShot2.gameObject.tag = "spotspreadright";
			spotShot2.gameObject.name = "topSpot";
			GameObject spotShot3 = Instantiate(spot[2], spotSpawn.position, Quaternion.identity) as GameObject;
			spotShot3.gameObject.tag = "spotspreadright";
			spotShot3.gameObject.name = "bottomSpot";
			//Debug.Log ("Shot fired!");
		}
		Invoke("SpreadShot", 1.5f);
	}
}
