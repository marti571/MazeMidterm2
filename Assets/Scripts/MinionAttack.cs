using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionAttack : MonoBehaviour {

	public float timeBetweenAttacks = 0.5f;  //Time in seconds between each attack
	public int attackDamage = 5;			 //The amount of health taken away per attack

	Animator anim;							 //reference to minion's animator controller
	GameObject player;						 //reference to maze warrior
	WarriorHealth playerHealth;				 //reference to the player's health
	MinionHealth minionHealth;				 //reference to the enemy's health
	bool playerInRange;
	float timer;
	
	void Awake () {
		player = GameObject.FindGameObjectWithTag ("Player");
		minionHealth = GetComponent<MinionHealth> (); 
		playerHealth = player.GetComponent <WarriorHealth> ();
		anim = GetComponent <Animator> ();
		
	}
	
	
	void OnTriggerEnter (Collider other) {
		//if the collider is the player
		if(other.gameObject == player)
		{
			//if the player is range
			playerInRange = true;
		}
	}
	void OnTriggerExit (Collider other) {
		//if the player is not in range
		if(other.gameObject == player)
		{
			playerInRange = false;
		}
	}
	void Update ()
	{
		//Add a time since update was last called to the timer
		timer += Time.deltaTime;

		//if the timer exceeds the time between attacks, the player is in range and this enemy is alive
		if(timer >= timeBetweenAttacks && playerInRange && minionHealth.currentHealth >0)
		{
			Attack();
		}
		if(playerHealth.currentHealth <= 0)
		{
			anim.SetTrigger ("PlayerDead");
		}
	}
	void Attack ()
	{
		//reset the timer
		timer = 0f;
		//if the player has health to lose
		if(playerHealth.currentHealth > 0)
		{
			//anim.SetTrigger("Attack");
			//damage player
			playerHealth.TakeDamage (attackDamage);
		}
	}
}
