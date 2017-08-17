
/// This is the EnemyGreen Script:
/// - Enemy Ship Movement/Health/Score
/// - Explosion Trigger


using UnityEngine;
using System.Collections;

public class EnemyGreen_Script : MonoBehaviour 
{

	//Public Var
	public float speed;						//Enemy Ship Speed
	public int health;						//Enemy Ship Health
	//public GameObject LaserGreenHit;		//LaserGreenHit Prefab
	public GameObject Explosion;			//Explosion Prefab
	public int scoreValue; //How much the Enemy Ship give score after explosion
	public ScoreManager scoreManager;

	public GameObject shot; 				//Fire Prefab
	public Transform shotSpawn;				//Where the Fire Spawn
	public float fireRate = 1F;				//Fire Rate between Shots

	//Private Var
	private float nextFire = 0.0F; 			//First fire & Next fire Time


	// Use this for initialization
	void Start () 
	{
		scoreManager=FindObjectOfType<ScoreManager>();  //find score manager
		GetComponent<Rigidbody>().velocity = -1 * transform.up * speed;	//Enemy Ship Movement
	}

	// Update is called once per frame
	void Update () 
	{
		//Excute When the Current Time is bigger than the nextFire time
		if (Time.time > nextFire)
		{
			nextFire = Time.time + fireRate; 									//Increment nextFire time with the current system time + fireRate
			Instantiate (shot , shotSpawn.position ,shotSpawn.rotation); 		//Instantiate fire shot 
			GetComponent<AudioSource>().Play (); 														//Play Fire sound
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
				Destroy (this.gameObject);      //Destroy The Object (Enemy Ship)
				scoreManager.score+=scoreValue=200;//add points when destroy
			}

		}
	}

	void PlayExplosion()
	{
		GameObject explosion = (GameObject)Instantiate (Explosion);
		explosion.transform.position = transform.position;
	}
}
