using UnityEngine;
using System.Collections;

public class testWebcam : MonoBehaviour {

	public UITexture MyWebcam;

	// Use this for initialization
	void Start () {

		WebCamTexture webcamTexture = new WebCamTexture();
		webcamTexture.Play();
		MyWebcam.GetComponent<UITexture>().mainTexture = webcamTexture;

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
