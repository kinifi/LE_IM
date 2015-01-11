using UnityEngine;
using System.Collections;

public class SplashEnd : MonoBehaviour {

	// Use this for initialization
	void Start () {

		Invoke ("KillMe", 0.55f);
	
	}
	
	public void KillMe ()
	{
		Destroy(this.gameObject);
	}
}
