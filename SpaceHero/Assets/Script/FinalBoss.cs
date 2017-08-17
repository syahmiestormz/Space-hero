using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FinalBoss : MonoBehaviour
{
	//Public Var
	public float speed;						//Enemy Ship Speed
	public int health;						//Enemy Ship Health
	public Slider HealthEnemy;		//LaserGreenHit Prefab
	public GameObject Explosion;			//Explosion Prefab
	public int scoreValue;                  //How much the Enemy Ship give score after explosion
	public ScoreManager scoreManager;
	public GameObject GameOverPanel;

	public GameObject shot;					//Fire Prefab
	public Transform shotSpawn;				//Where the Fire Spawn
	public Transform shotSpawn1;	
	public Transform shotSpawn2;	
	public float fireRate = 0.5F;			//Fire Rate between Shots

	//Private Var
	private float nextFire = 0.0F;			//First fire & Next fire Time

	// Use this for initialization
	void Start () 
	{
		scoreManager=FindObjectOfType<ScoreManager>();  //find score manager
		GetComponent<Rigidbody>().velocity = -1 * transform.up * speed;	//Enemy Ship Movement

	}

	// Update is called once per frame
	void Update () 
	{

		HealthEnemy.value = health;

		//Excute When the Current Time is bigger than the nextFire time
		if (Time.time > nextFire)
		{
			nextFire = Time.time + fireRate; 									//Increment nextFire time with the current system time + fireRate
			Instantiate (shot , shotSpawn.position ,shotSpawn.rotation); 		//Instantiate fire shot 
			Instantiate (shot , shotSpawn1.position ,shotSpawn1.rotation);
			Instantiate (shot , shotSpawn2.position ,shotSpawn2.rotation);
			GetComponent<AudioSource>().Play ();														//Play Fire sound
		}
	}

	//Called when the Trigger entered
	void OnTriggerEnter(Collider col)
	{
		if ((col.tag == "PlayerShipTag") || (col.tag == "Shoot1Tag")) 
		{
			//Check the Health if greater than 0
			if(health > 0)
				health--; 	 //Decrement Health by 1
			GetComponent<Animator> ().SetTrigger ("Damage");
			//Check the Health if less or equal 0
			if(health <= 0)
			{

				PlayExplosion ();
				GameOverPanel.SetActive (true);
				Destroy (this.gameObject);      //Destroy The Object (Enemy Ship)
				scoreManager.score+=scoreValue=400;//add points when destroy


			}

		}
			
	}

	void PlayExplosion()
	{
		GameObject explosion = (GameObject)Instantiate (Explosion);
		explosion.transform.position = transform.position;
	}
}
