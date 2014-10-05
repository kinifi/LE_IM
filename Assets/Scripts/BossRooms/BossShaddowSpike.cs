using UnityEngine;
using System.Collections;

public class BossShaddowSpike : MonoBehaviour {

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	
	private float nextFire;

	//Config for Audio
	AudioClip[] _depthClips;

	void Start ()
	{
		_depthClips = GameObject.Find("DepthsBossProfile").GetComponent<DepthsBossMovement>().depthClips;
	}

	// Update is called once per frame
	void Update () 
	{
		if (Time.time > nextFire && this.gameObject.tag == "spike")
		{
			nextFire = Time.time + fireRate;
			GameObject spikeShot = Instantiate(shot, shotSpawn.position, Quaternion.identity) as GameObject;
			spikeShot.gameObject.tag = "spike";
			audio.PlayOneShot(_depthClips[2], 0.75f);
			//Debug.Log ("Shot fired!");
		}
		if (Time.time > nextFire && this.gameObject.tag == "topspike")
		{
			nextFire = Time.time + fireRate;
			GameObject spikeShot = Instantiate(shot, shotSpawn.position, Quaternion.identity) as GameObject;
			spikeShot.gameObject.tag = "topspike";
			audio.PlayOneShot(_depthClips[2], 0.75f);
			//Debug.Log ("Shot fired!");
		}
		if (Time.time > nextFire && this.gameObject.tag == "leftspike")
		{
			nextFire = Time.time + fireRate;
			GameObject spikeShot = Instantiate(shot, shotSpawn.position, Quaternion.identity) as GameObject;
			spikeShot.gameObject.tag = "leftspike";
			audio.PlayOneShot(_depthClips[2], 0.75f);
			//Debug.Log ("Shot fired!");
		}
		if (Time.time > nextFire && this.gameObject.tag == "rightspike")
		{
			nextFire = Time.time + fireRate;
			GameObject spikeShot = Instantiate(shot, shotSpawn.position, Quaternion.identity) as GameObject;
			spikeShot.gameObject.tag = "rightspike";
			audio.PlayOneShot(_depthClips[2], 0.75f);
			//Debug.Log ("Shot fired!");
		}
		if (Time.time > nextFire && this.gameObject.tag == "bossspike")
		{
			nextFire = Time.time + fireRate;
			GameObject spikeShot = Instantiate(shot, shotSpawn.position, shotSpawn.rotation) as GameObject;
			spikeShot.gameObject.tag = "bossspike";
			audio.PlayOneShot(_depthClips[2], 0.75f);
			//Debug.Log ("Shot fired!");
		}
	
	}
}
