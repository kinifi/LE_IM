using UnityEngine;
using System.Collections;

public class ShaddowSpike : MonoBehaviour {

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	
	private float nextFire;

	// Update is called once per frame
	void Update () 
	{
		if (Time.time > nextFire && this.gameObject.tag == "spike")
		{
			nextFire = Time.time + fireRate;
			GameObject spikeShot = Instantiate(shot, shotSpawn.position, Quaternion.identity) as GameObject;
			spikeShot.gameObject.tag = "spike";
			//Debug.Log ("Shot fired!");
		}
		if (Time.time > nextFire && this.gameObject.tag == "topspike")
		{
			nextFire = Time.time + fireRate;
			GameObject spikeShot = Instantiate(shot, shotSpawn.position, Quaternion.identity) as GameObject;
			spikeShot.gameObject.tag = "topspike";
			//Debug.Log ("Shot fired!");
		}
		if (Time.time > nextFire && this.gameObject.tag == "leftspike")
		{
			nextFire = Time.time + fireRate;
			GameObject spikeShot = Instantiate(shot, shotSpawn.position, Quaternion.identity) as GameObject;
			spikeShot.gameObject.tag = "leftspike";
			//Debug.Log ("Shot fired!");
		}
		if (Time.time > nextFire && this.gameObject.tag == "rightspike")
		{
			nextFire = Time.time + fireRate;
			GameObject spikeShot = Instantiate(shot, shotSpawn.position, Quaternion.identity) as GameObject;
			spikeShot.gameObject.tag = "rightspike";
			//Debug.Log ("Shot fired!");
		}
	
	}
}
