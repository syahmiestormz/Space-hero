using UnityEngine;
using System.Collections;

public class MoveAsteroid : MonoBehaviour 
{
	public float speedY = -1;
	public float rotationSpeed=1;
	public GameObject EExplosion;
	private Vector3 position;
	private float randomSpeedX;
	private float randomSpeedY;
	private float randomRotation;
	public int scoreValue;//enemy points
	public ScoreManager scoreManager;



	// Use this for initialization
	void Start ()
	{
		randomSpeedX = Random.Range (-0.05f, 0.05f);
		randomSpeedY = Random.Range (0.1f, 1);
		randomRotation = Random.Range (-1, 1);
	
		gameObject.GetComponent<Rigidbody>().angularVelocity = new Vector3 (0, 0, randomRotation * rotationSpeed);
		scoreManager=FindObjectOfType<ScoreManager>();
	

	}
	

	void FixedUpdate () 
	{
		position.x = this.gameObject.transform.position.x + randomSpeedX * 0.1f;
		position.y = this.gameObject.transform.position.y +speedY * randomSpeedY;
		position.z = 0;

		this.gameObject.transform.position = position;
	
	}

	void OnTriggerEnter(Collider col)
	{
		if ((col.tag == "PlayerShipTag") || (col.tag == "Shoot1Tag")) 
		{
			PlayExplosion ();
			Destroy (gameObject);
			scoreManager.score+=scoreValue=50;//add points when destroy
		}
	}
	void PlayExplosion()
	{
		GameObject explosion = (GameObject)Instantiate (EExplosion);
		explosion.transform.position = transform.position;
	}
}
