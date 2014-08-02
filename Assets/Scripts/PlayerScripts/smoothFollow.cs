using UnityEngine;
using System.Collections;

public class smoothFollow : MonoBehaviour {
	
	public float deadZone;
	public bool followVertical = false;
	public bool followHorizontal = true;
	
	public GameObject cam;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		var camX = cam.transform.position.x;
		var camY = cam.transform.position.y;
		var objX = transform.position.x;
		var objY = transform.position.y;
		
		//If Follow Horizontal is checked in inspector, the camera follows player horizonally with the deadzone.
		if(followHorizontal == true){
			if (camX >= objX + deadZone){
				camX = objX + deadZone;
			}
			if (camX <= objX - deadZone){
				camX = objX - deadZone;
			}
		}
		
		//If Follow Vertical is checked in inspector, the camera follows player vertically with the deadzone.
		if(followVertical == true){
			if (camY >= objY + deadZone){
				camY = objY + deadZone;
			}
			if (camY <= objY - deadZone){
				camY = objY - deadZone;
			}
		}
		
	}
}