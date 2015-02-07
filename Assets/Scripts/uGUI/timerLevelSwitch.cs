using UnityEngine;
using System.Collections;

public class timerLevelSwitch : MonoBehaviour {

	public string levelNameToLoad;
	public float m_Timer = 1.0f;
	private bool m_timerDone = false;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		if(!m_timerDone)
		{
			m_Timer -= Time.deltaTime;
		
			if(m_Timer < 0)
			{
				m_timerDone = false;
				onTimerComplete();
			}
		}
	}

	private void onTimerComplete()
	{
		Debug.Log("Timer Completed");
		Application.LoadLevel(levelNameToLoad);
	}
}
