using UnityEngine;
using System.Collections;

public class ringSpawn : MonoBehaviour {

	// Use this for initialization
	void Start () {

		fadeIn();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void fadeIn() {

		float _time = Random.Range(1.0f, 5.0f);
		//Debug.Log(_time);
		//iTween.FadeTo(this.gameObject, 0, _time);
		iTween.FadeTo(this.gameObject, iTween.Hash("alpha", 0,"time", _time, "oncompletetarget", this.gameObject, "oncomplete", "fadeOut"));
	}

	private void fadeOut() {
		float _time = Random.Range(1.0f, 2.0f);
		//Debug.Log(_time);
		iTween.FadeTo(this.gameObject, iTween.Hash("alpha", 0.6f, "time", _time, "oncompletetarget", this.gameObject, "oncomplete", "fadeIn"));
	}
}
