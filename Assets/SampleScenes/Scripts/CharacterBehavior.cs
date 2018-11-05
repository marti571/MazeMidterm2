using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehavior : MonoBehaviour {
	private Animator anim;
	private bool PlayerClicked;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		//Walking Animation
		anim.SetFloat("speed", Input.GetAxis("Vertical"));
		anim.SetFloat("direction", Input.GetAxis("Horizontal"));
		//Punching Animation
		Punching();
	}	
	void Punching() {
		if(Input.GetButtonDown("Fire1"))
		{
			PlayerClicked = true;
		}
		if(Input.GetButtonUp("Fire1") && PlayerClicked == true)
		{
			anim.SetTrigger("Punch");
		}
	}
}