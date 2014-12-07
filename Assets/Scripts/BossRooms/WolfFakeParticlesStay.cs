using UnityEngine;
using System.Collections;

public class WolfFakeParticlesStay : MonoBehaviour {
	
	public GameObject particleBreath;
	
	public Transform breath;
	//position configs
	private Vector3 breathPosition;
	private Vector3 breathVelocity = new Vector3 (-1.75f, -0.05f, 0.0f);
	private Vector3 breathPositionB;
	private Vector3 breathVelocityB = new Vector3 (0.0f, -0.05f, 0.0f);
	private Vector3 breathPositionC;
	private Vector3 breathVelocityC = new Vector3 (+1.75f, -0.05f, 0.0f);
	private Vector3 breathPositionD;
	private Vector3 breathVelocityD = new Vector3 (+1.0f, -0.05f, 0.0f);
	private Vector3 breathPositionE;
	private Vector3 breathVelocityE = new Vector3 (+2.5f, -0.05f, 0.0f);
	private Vector3 breathPositionF;
	private Vector3 breathVelocityF = new Vector3 (-0.75f, -0.05f, 0.0f);
	//scale configs
	private float randomScale;
	private float randomScaleB;
	private float randomScaleC;
	private float randomScaleD;
	private float randomScaleE;
	private float randomScaleF;
	
	private Vector3 breathScale;
	private Vector3 breathScaleB;
	private Vector3 breathScaleC;
	private Vector3 breathScaleD;
	private Vector3 breathScaleE;
	private Vector3 breathScaleF;
	
	//death rate config
	private float randomDeathRate;
	private float randomDeathRateB;
	private float randomDeathRateC;
	private float randomDeathRateD;
	private float randomDeathRateE;
	private float randomDeathRateF;

	//Invoke Float Configs
	private float breathAInvoke = 0.50f;
	private float breathBInvoke = 0.25f;
	private float breathCInvoke = 0.75f;
	private float breathDInvoke = 1.0f;
	private float breathEInvoke = 0.15f;
	private float breathFInvoke = 0.65f;
	
	// Use this for initialization
	void Start () 
	{
		InvokeRepeating("BreathA", 0.15f, breathAInvoke);
		InvokeRepeating("BreathB", 0.15f, breathBInvoke);
		InvokeRepeating("BreathC", 0.15f, breathCInvoke);
		InvokeRepeating("BreathD", 0.15f, breathCInvoke);
		InvokeRepeating("BreathE", 0.15f, breathCInvoke);
		InvokeRepeating("BreathF", 0.15f, breathCInvoke);
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		//gets the current position
		breathPosition = breath.position;
	}
	//FIRST PARTICLE!!!--------------------
	private void BreathA ()
	{
		breathAInvoke = Random.Range (0.25f, 0.75f);
		GameObject breathed = Instantiate(particleBreath, breathPosition, Quaternion.identity) as GameObject;
		//position
		breathed.transform.position = breathPosition;
		//scale
		randomScale = Random.Range (0.10f, 1.0f);
		breathScale = (breathed.transform.localScale * randomScale);
		breathed.transform.localScale = breathScale;
		//color
		breathed.GetComponent<SpriteRenderer>().color = new Color (0.70f, 0.86f, 0.59f, 1.0f);
		//velocity
		breathed.rigidbody2D.AddForce(breathVelocity*0.45f);
		//PARTICLE DEATHS!!!!!
		randomDeathRate = Random.Range (6.0f, 9.0f);
		Destroy (breathed, randomDeathRate);
	}
	
	//SECOND PARTICLE!!!--------------------
	private void BreathB ()
	{
		breathBInvoke = Random.Range (0.25f, 1.0f);
		GameObject breathedB = Instantiate(particleBreath, breathPosition, Quaternion.identity) as GameObject;
		//position
		breathPositionB = breathPosition;
		breathPositionB.x = breathPosition.x - 0.50f;
		breathedB.transform.position = breathPositionB;
		//scale
		randomScaleB = Random.Range (0.10f, 1.0f);
		breathScaleB = (breathedB.transform.localScale * randomScaleB);
		breathedB.transform.localScale = breathScaleB;
		//color
		breathedB.GetComponent<SpriteRenderer>().color = new Color (0.11f, 0.15f, 0.07f, 1.0f);
		//velocity
		breathedB.rigidbody2D.AddForce(breathVelocityB * 0.45f);
		//PARTICLE DEATHS!!!!!
		randomDeathRateB = Random.Range (3.0f, 6.0f);
		Destroy (breathedB, randomDeathRateB);
	}
	
	//THIRD PARTICLE!!!--------------------
	private void BreathC ()
	{
		breathCInvoke = Random.Range (0.25f, 0.50f);
		GameObject breathedC = Instantiate(particleBreath, breathPosition, Quaternion.identity) as GameObject;
		//position
		breathPositionC = breathPosition;
		breathPositionC.x = breathPosition.x + 0.35f;
		breathedC.transform.position = breathPositionC;
		//scale
		randomScaleC = Random.Range (0.10f, 1.0f);
		breathScaleC = (breathedC.transform.localScale * randomScaleC);
		breathedC.transform.localScale = breathScaleC;
		//color
		breathedC.GetComponent<SpriteRenderer>().color = new Color (0.74f, 0.61f, 0.00f, 1.0f);
		//velocity
		breathedC.rigidbody2D.AddForce(breathVelocityC * 0.45f);
		//PARTICLE DEATHS!!!!!
		randomDeathRateC = Random.Range (2.9f, 6.0f);
		Destroy (breathedC, randomDeathRateC);
	}
	
	//THIRD PARTICLE!!!--------------------
	private void BreathD ()
	{
		breathDInvoke = Random.Range (0.25f, 0.50f);
		GameObject breathedD = Instantiate(particleBreath, breathPosition, Quaternion.identity) as GameObject;
		//position
		breathPositionD = breathPosition;
		breathPositionD.x = breathPosition.x + 0.35f;
		breathedD.transform.position = breathPositionD;
		//scale
		randomScaleD = Random.Range (0.10f, 1.0f);
		breathScaleD = (breathedD.transform.localScale * randomScaleD);
		breathedD.transform.localScale = breathScaleD;
		//color
		breathedD.GetComponent<SpriteRenderer>().color = new Color (0.20f, 0.28f, 0.10f, 1.0f);
		//velocity
		breathedD.rigidbody2D.AddForce(breathVelocityC * 0.45f);
		//PARTICLE DEATHS!!!!!
		randomDeathRateD = Random.Range (3.5f, 6.0f);
		Destroy (breathedD, randomDeathRateD);
	}
	
	//FOURTH PARTICLE!!!--------------------
	private void BreathE ()
	{
		breathEInvoke = Random.Range (0.25f, 0.50f);
		GameObject breathedE = Instantiate(particleBreath, breathPosition, Quaternion.identity) as GameObject;
		//position
		breathPositionE = breathPosition;
		breathPositionE.x = breathPosition.x + 0.65f;
		breathedE.transform.position = breathPositionE;
		//scale
		randomScaleE = Random.Range (0.10f, 1.0f);
		breathScaleE = (breathedE.transform.localScale * randomScaleE);
		breathedE.transform.localScale = breathScaleE;
		//color
		breathedE.GetComponent<SpriteRenderer>().color = new Color (0.20f, 0.28f, 0.00f, 1.0f);
		//velocity
		breathedE.rigidbody2D.AddForce(breathVelocityE * 0.45f);
		//PARTICLE DEATHS!!!!!
		randomDeathRateE = Random.Range (2.5f, 6.5f);
		Destroy (breathedE, randomDeathRateE);
	}
	
	//FIFTH PARTICLE!!!--------------------
	private void BreathF ()
	{
		breathFInvoke = Random.Range (0.25f, 0.50f);
		GameObject breathedF = Instantiate(particleBreath, breathPosition, Quaternion.identity) as GameObject;
		//position
		breathPositionF = breathPosition;
		breathPositionF.x = breathPosition.x - 0.65f;
		breathedF.transform.position = breathPositionF;
		//scale
		randomScaleF = Random.Range (0.10f, 1.0f);
		breathScaleF = (breathedF.transform.localScale * randomScaleF);
		breathedF.transform.localScale = breathScaleF;
		//color
		breathedF.GetComponent<SpriteRenderer>().color = new Color (0.82f, 0.86f, 0.20f, 1.0f);
		//velocity
		breathedF.rigidbody2D.AddForce(breathVelocityF * 0.45f);
		//PARTICLE DEATHS!!!!!
		randomDeathRateF = Random.Range (2.0f, 6.0f);
		Destroy (breathedF, randomDeathRateF);
	}


}
