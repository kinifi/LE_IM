using UnityEngine;
using System.Collections;

public class SortingLayerParticleAddon : MonoBehaviour {

	// Use this for initialization
	void Start () {

		// Set the sorting layer of the particle system.
		particleSystem.renderer.sortingLayerName = "Level Tiles";
		particleSystem.renderer.sortingOrder = 2;
	
	}

}
