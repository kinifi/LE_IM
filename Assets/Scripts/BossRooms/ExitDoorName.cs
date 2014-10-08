using UnityEngine;
using System.Collections;

public class ExitDoorName : MonoBehaviour {



	// Use this for initialization
	void Start () {

		string _names = this.gameObject.name;
		//Debug.Log("MY NAME IS: "+_names);
		switch (_names)
		{
		case "NExit":
			this.gameObject.name = "4";
			Debug.Log("MY NAME IS: "+this.gameObject.name);
			break;
		case "DepthsExit":
			this.gameObject.name = "3";
			Debug.Log("MY NAME IS: "+this.gameObject.name);
			break;
		case "GoblinExit":
			this.gameObject.name = "1";
			Debug.Log("MY NAME IS: "+this.gameObject.name);
			break;
		}

	
	}
}
