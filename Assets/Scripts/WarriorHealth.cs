using System.Collections;
//using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.CoreModule;


public class WarriorHealth : MonoBehaviour {
	//Health variables
	public int maxHealth = 100;
	public int currentHealth;
	public Slider healthSlider;
	public Color32 flashcolor = new Color(1f,0f,0f,0.1f);

	public Image damageImage;
	

	//add a death audio public AudioClip deathClip;
	public float flashSpeed = 5f;
	

	Animator anim;
	CharacterBehavior characterBehavior;
	bool isDead;
	bool damaged;
	// Use this for initialization
	void Awake () {
		//setting up the references
		anim = GetComponent <Animator> ();
		characterBehavior = GetComponent <CharacterBehavior> ();

		//Set initial health of player
		currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		//if the player has just been damaged
		if(damaged)
		{
			damageImage.GetComponent<Image>().color = flashcolor;
			//set the color of damageImage
			//damageImage.color = flashcolor;
		}
		else
		{
			//back to clear
			//damageImage.color = Color.Lerp (damageImage.Color, Color.clear, flashSpeed * Time.deltaTime);
			damageImage.GetComponent<Image>().color = Color.Lerp (damageImage.GetComponent<Image>().color, Color.clear, flashSpeed * Time.deltaTime);
		}
		//reset damage flag
		damaged = false;
	}

	public void TakeDamage (int amount)
	{
		//Set the damaged flag so the screen will flash
		damaged = true;

		//reduce health
		currentHealth -= amount;

		//set the health bar's value to current health
		healthSlider.value = currentHealth;

		//Play hurt sound effect

		if(currentHealth <= 0 && !isDead)
		{
			Death();
		}
	}
	void Death()
	{
		//set flag so this fuunction wont be called again
		isDead = true;
		anim.SetTrigger("Death");

		//set audiosource to play death clip to stop sound of hurt

		//stop the charcter from moving or punching
		characterBehavior.enabled = false;
        SceneManager.LoadScene("GameOver");
    }
}
