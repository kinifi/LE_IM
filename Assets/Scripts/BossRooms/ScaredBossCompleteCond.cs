using UnityEngine;
using System.Collections;

public class ScaredBossCompleteCond : MonoBehaviour {

	public bool scaredDead = false;

	// Update is called once per frame
	void Update () 
	{
		if(scaredDead == true)
		{
			Destroy(this.gameObject);
		}
	}
}
