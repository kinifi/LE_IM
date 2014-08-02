using UnityEngine;
using System.Collections;

public class ColisionBreak : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
			Destroy(other.gameObject);
	}

}
