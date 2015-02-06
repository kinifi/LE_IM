using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject m_target;
	public Vector3 m_cameraOffset;
	public bool m_cameraSet = false;

	// Use this for initialization
	void Start () {
	
	}

	public void resetPlayerPosition()
	{

	}



	public void setTarget()
	{
		Invoke("lateSetTarget", 0.2f);
	}

	private void lateSetTarget()
	{
		m_target = GameObject.Find("Player");
		
		if(m_target == null)
		{
			Debug.LogError("Could not find camera!");
		}
		else
		{
			Debug.Log("Set PlayMode Camera");
			this.transform.camera.orthographicSize = 3.0f;
			this.transform.position = new Vector3(-2.0f, 17.72f, -5.0f);
			m_cameraSet = true;
		}
	}

	public void disableTarget()
	{
		m_target = null;
		Debug.Log("Disabled PlayMode Camera");
		m_cameraSet = false;
		this.transform.camera.orthographicSize = 11.0f;
		this.transform.position = new Vector3(5.75f, 9.0f, -5.0f);
		GameObject _player = GameObject.Find("Player");
		_player.transform.position = new Vector2(-2.0f, 17.72f);
	}

	// Update is called once per frame
	void Update () {

		if(m_cameraSet)
		{
			this.transform.position = new Vector3(m_target.transform.position.x + m_cameraOffset.x, m_target.transform.position.y + m_cameraOffset.y, m_target.transform.position.z + m_cameraOffset.z);
		}

	}
}
