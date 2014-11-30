using UnityEngine;
using System.Collections;

public class BlurSideSquig : MonoBehaviour {

	public float squigMove;

	private Vector3 startPosition;
	private Vector3 nextPosition;
	
	void Start ()
	{
		startPosition = transform.position;
		SquigLeft();
	}
	
	private void SquigLeft ()
	{
		float randTime = Random.Range(0.15f, 0.75f);
		squigMove = Random.Range (0.00f, 0.10f);

		nextPosition = startPosition;
		nextPosition.x -= squigMove;

		transform.position = nextPosition;

		Invoke ("SquigRight", randTime);
	}

	private void SquigRight ()
	{
		float randTime = Random.Range(0.15f, 0.75f);
		squigMove = Random.Range (0.00f, 0.10f);

		nextPosition = startPosition;
		nextPosition.x += squigMove;
		
		transform.position = nextPosition;

		Invoke ("SquigLeft", randTime);
	}
}
