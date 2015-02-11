using UnityEngine;
using System.Collections;

public class companionAnimations : MonoBehaviour {

	private Animator _anim;

	// Use this for initialization
	void Start () {
	
		_anim = GetComponent<Animator>();
		playIdle();
	}

	private void playIdle()
	{
		_anim.SetTrigger("Idle");
		Invoke("playHappy", 5.0f);
	}

	private void playHappy()
	{
		_anim.SetTrigger("Happy");
		Invoke("playIdle", 5.0f);
	}

}
