using UnityEngine;
using System.Collections;

public class ParticlesOnLevelTilesLayer : MonoBehaviour {

	void Awake ()
	{
		particleSystem.renderer.sortingLayerName = "Player";
	}
}
