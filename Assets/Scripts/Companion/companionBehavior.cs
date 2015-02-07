using UnityEngine;
using System.Collections;

public class companionBehavior : MonoBehaviour {

	private GameObject m_Player;
	public float m_followSpeed = 5.0f;
	public float m_maxDistanceFromPlayer = 8.0f;
	public float _currentDistanceFromPlayer;

	// Use this for initialization
	void Start () {
	
		#region find player in scene
		//find the player
		m_Player = GameObject.Find("Player");
		//Check to see if we found the player successfully
		if(m_Player == null)
		{
			Debug.LogError("Can't Find Player");
		}
		else
		{
			Debug.Log("Found Player");
		}

		#endregion

	}
	
	// Update is called once per frame
	void Update () {
	
		//get the distance from the player
		_currentDistanceFromPlayer = Vector2.Distance(this.transform.position, m_Player.transform.position);

		//Check if the current distance from the player is greater than the max distance from the player
		if (_currentDistanceFromPlayer >= m_maxDistanceFromPlayer)
		{
			this.transform.position += this.transform.forward * m_followSpeed * Time.deltaTime;
		}
		else
		{

		}

		//play up and down animation

	}
}
