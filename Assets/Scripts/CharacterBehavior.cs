using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterBehavior : MonoBehaviour {
	private Animator anim;
	private bool PlayerClicked;
    public AudioClip punch;
    AudioSource punchSound;
    GameObject obj1;
    public AudioClip kick;
    AudioSource kickSound;
    GameObject obj2;
    //the damage to inflict on Minion
    public int damagePerPunch = 25;
	public int damagePerKick = 30;
	public float timeBetweenHits = 0.15f;
	float timer;
	//minion parameters
	MinionHealth minionHealth;
	bool minionInRange;
<<<<<<< HEAD
	public GameObject minion;


    // Use this for initialization
    void Awake()
    {
        anim = GetComponent<Animator>();
        if (minion.activeInHierarchy == true)
        {

            minion = GameObject.FindGameObjectWithTag("Minion");
            minionHealth = minion.GetComponent<MinionHealth>();
        }
		
	}
    void Start()
    {
        obj1 = GameObject.Find("PunchAudioObj");
        obj2 = GameObject.Find("KickAudioObj");
        if (obj1 != null)
        {
            punchSound = obj1.GetComponent<AudioSource>(); // get component once @ Start more efficient.

        }
        if (obj2 != null)
        {
            kickSound = obj2.GetComponent<AudioSource>(); // get component once @ Start more efficient.

        }

    }

    // Update is called once per frame
    void Update () {
=======
	GameObject minion;
	//pause control parameters
	private int count;
	public bool paused;
	GameObject[] pausedObjects;
	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
		pausedObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
		hidePaused();
		minion = GameObject.FindGameObjectWithTag ("Minion");	
		minionHealth = minion.GetComponent <MinionHealth> ();
		anim = GetComponent<Animator> ();
	} 
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.P))
		{
			if(Time.timeScale == 1)
			{
				Time.timeScale = 0;
				showPaused();
				//onClick();
			}
			else if(Time.timeScale == 0)
			{
				Time.timeScale = 1;
				hidePaused();
			}
		}
>>>>>>> master
		timer += Time.deltaTime;
		//Walking Animation
		anim.SetFloat("speed", Input.GetAxis("Vertical"));
		anim.SetFloat("direction", Input.GetAxis("Horizontal"));
		//Punching Animation
		
		
		Punching();
		Kicking();
	}
	public void pauseControl()
	{
		if(Time.timeScale == 1)
		{
			Time.timeScale = 0;
			showPaused();
			paused=true;
		}
		else if(Time.timeScale == 0)
		{
			Time.timeScale = 1;
			hidePaused();
			paused=false;
		}
	}
	public void showPaused(){
		foreach(GameObject g in pausedObjects){
			g.SetActive(true);
		}
	}
	public void hidePaused(){
		foreach(GameObject g in pausedObjects){
			g.SetActive(false);
		}
	}	
	void Punching() {
        if(Input.GetKeyDown("fire1"))
		{
			PlayerClicked = true;
		}
        if(Input.GetKeyUp("fire1") && PlayerClicked == true)
		{
            punchSound.clip = punch; //once the character punch, makes sound
            punchSound.Play();

            anim.SetTrigger("Punch");
            if (minionInRange)
			{
				Punch();
               
            }
			//punch audio	
		}
	}
	void Kicking() {
		
		if(Input.GetKeyDown("space"))
		{
			PlayerClicked = true;
			//Kicking animation		
		}
		if(Input.GetKeyUp("space") && PlayerClicked == true)
		{
            kickSound.clip = kick; //once the character kicks, makes sound
            kickSound.Play();

            anim.SetTrigger("Kick");
			if(minionInRange)
			{
				Kick();
			}
			
		}
	}
	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject == minion)
		{
			minionInRange = true;
		}
	}
	void OnTriggerExit (Collider other)
	{
		if(other.gameObject == minion)
		{
			minionInRange = false;
		}
	}
	void Punch ()
	{
		timer = 0f;
		if(minionHealth.currentHealth > 0)
			{
				minionHealth.TakeDamage(damagePerPunch);
			}
	}
	void Kick ()
	{
		timer = 0f;
		if(minionHealth.currentHealth > 0)
			{
				minionHealth.TakeDamage(damagePerKick);
			}
	}

}