using UnityEngine;
using System.Collections;

public class moveToPoints : MonoBehaviour {

	public Transform[] points;
	public int startPoint = 0;
	public float speedToMove = 10.0f;

	// Use this for initialization
	void Start () {
	
		MoveToPoints();

	}
	
	// Update is called once per frame
	void Update () {
	

	}

	void OnTriggerEnter2D(Collider2D other) {

		//Debug.Log("hit");

	}

	void MoveToPoints () {

		iTween.MoveTo(this.gameObject, iTween.Hash("position", points[0], "speed", speedToMove, "oncompletetarget", this.gameObject, "oncomplete", "MoveToPoints2"));

	}

	void MoveToPoints2 () {
		
		iTween.MoveTo(this.gameObject, iTween.Hash("position", points[1], "speed", speedToMove, "oncompletetarget", this.gameObject, "oncomplete", "MoveToPoints"));
		
	}
}
