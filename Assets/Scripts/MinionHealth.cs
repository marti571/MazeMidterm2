using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinionHealth : MonoBehaviour {

	public Slider minionSlider;
	public int startingHealth = 100;
	public int currentHealth;
	// public float sinkSpeed = 2.5f;
	Animator anim;
	CapsuleCollider capsuleCollider;
	bool isDead;
//	bool isSinking;
	GameObject minion;
	void Awake () {
		anim = GetComponent <Animator> ();
		capsuleCollider = GetComponent <CapsuleCollider> ();
		minion = GameObject.FindGameObjectWithTag("Minion");
		//setting the current health to starting health when enemy spawns
		currentHealth = startingHealth;
		
	}
	// void Update ()
	// {
	// 	//if minion is sinking
	// 	if(isSinking)
	// 	{
	// 		transform.Translate (-Vector3.up * sinkSpeed * Time.deltaTime);
	// 	}
	// }
	public void TakeDamage (int amount)
	{
		if(isDead)
		{
			return;
		}
		//ADD AUDIO
		//reduce the health
		currentHealth -= amount;
		minionSlider.value = currentHealth;
		if(currentHealth <= 0)
		{
			Death();
		}
	}
	void Death ()
	{
		isDead = true;
		//turn the collider into a trigger so punches and kicks can go through
		capsuleCollider.isTrigger = true;
		anim.SetTrigger ("Death");
		minion.SetActive(false);
		//StartSinking();
	}
	// public void StartSinking ()
	// {
	// 	//Find and disable the Nav Mesh Agent
	// 	GetComponent <UnityEngine.AI.NavMeshAgent> ().enabled = false;
	// 	//find the rigidbody component and make it kinematic
	// 	GetComponent <Rigidbody> ().isKinematic = true;
	// 	isSinking = true;
	// 	//after 2 seconds destroy enemy
	// 	Destroy (gameObject, 2f);
	// }
}
