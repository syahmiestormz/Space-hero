
/// This is the EnemyBlue Script:
/// - Enemy Ship Movement/Health/Score
/// - Explosion Trigger 


using UnityEngine;
using System.Collections;

public class EnemyBlue_Script : MonoBehaviour 
{
	//Public Var
	public float speed; //Enemy Ship Speed
	public int health; //Enemy Ship Health
	//public GameObject LaserGreenHit; //LaserGreenHit Prefab
	public GameObject Explosion; //Explosion Prefab
	public int scoreValue; //How much the Enemy Ship give score after explosion
	public ScoreManager scoreManager;


	// Use this for initialization
	void Start () 
	{
		GetComponent<Rigidbody>().velocity = -1 * transform.up * speed; //Enemy Ship Movement
		scoreManager=FindObjectOfType<ScoreManager>();  //find score manager
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
				scoreManager.score+=scoreValue=100;//add points when destroy
			}

		}
	}

	void PlayExplosion()
	{
		GameObject explosion = (GameObject)Instantiate (Explosion);
		explosion.transform.position = transform.position;
	}
}