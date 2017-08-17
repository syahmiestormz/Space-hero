using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class MovePlayer : MonoBehaviour 
{



	public float speed=0.2f;//speed of player ship
	//public GameObject PExplosion;
	private Vector3 position;

	private float dist;
	private bool dragging = false;
	private Vector3 offset;
	private Transform toDrag;

	public GameObject shot;			//Fire Prefab
	public Transform shotSpawn;		//Where the Fire Spawn
	public Transform shotSpawn1;
	public Transform shotSpawn2;
	public float fireRate = 0.5F;	//Fire Rate between Shots
	public GameObject Explosion;	//Explosion Prefab
	public Slider HealthBarPlayer;  //player healthbar
	public int HP;                  //player life
	public GameObject RestartPanel;
	public bool doubleShot;
	//Private Var
	private float nextFire = 0.0F;	//First fire & Next fire Time

	public GameObject intro;
	//public GameObject HTP;

	void Start()
	{
		StartGame ();

		doubleShot = false;//set false when game start
	}
	// Update is called once per frame
	void Update () 
	{

		HealthBarPlayer.value = HP;   

		//Excute When the Current Time is bigger than the nextFire time
		if (Time.time > nextFire) 
		{
			if (doubleShot)
			{
				FireBullet ();
				StartCoroutine ("DoubleCountdown", 0);
				
			}
			nextFire = Time.time + fireRate; 								//Increment nextFire time with the current system time + fireRate
			Instantiate (shot , shotSpawn.position ,shotSpawn.rotation); 	//Instantiate fire shot 
			GetComponent<AudioSource>().Play (); 													//Play Fire sound
		}
	}
	

	void FixedUpdate () 
	{
		position.x = Mathf.Clamp(Input.GetAxis ("Horizontal") * speed + this.gameObject.transform.position.x,-3.25f,3.25f);
		position.y=Mathf.Clamp(Input.GetAxis  ("Vertical") * speed + this.gameObject.transform.position.y,-4.6f,4.1f);
		position.z=this.gameObject.transform.position.z;

		this.gameObject.transform.position = position;

	Vector3 v3;

		if (Input.touchCount != 1) {
			dragging = false; 
			return;
		}

		Touch touch = Input.touches[0];
		Vector3 pos = touch.position;

		if(touch.phase == TouchPhase.Began) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(pos); 
			if(Physics.Raycast(ray, out hit) && (hit.collider.tag == "PlayerShipTag"))
			{
				Debug.Log ("Here");
				toDrag = hit.transform;
				dist = hit.transform.position.z - Camera.main.transform.position.z;
				v3 = new Vector3(pos.x, pos.y, dist);
				v3 = Camera.main.ScreenToWorldPoint(v3);
				offset = toDrag.position - v3;
				dragging = true;
			}
		}
		if (dragging && touch.phase == TouchPhase.Moved) {
			v3 = new Vector3(Input.mousePosition.x, Input.mousePosition.y, dist);
			v3 = Camera.main.ScreenToWorldPoint(v3);
			toDrag.position = v3 + offset;
		}
		if (dragging && (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)) {
			dragging = false;
		}

	}


	/*void DragObject(Vector2 deltaPosition)
	{
		cachedTransform.position=new Vector3(Mathf.Clamp((deltaPosition.Equals.x*dragSpeed)+cachedTransform.position,startingPos.x-_horizontalLimit,startingPos.x+_horizontalLimit,Mathf.Clamp(deltaPosition.y*dragSpeed)+cachedTransform.position.y,startingPos.y-_verticalLimit,startingPos.y+_verticalLimit),cachedTransform.position.z);
	}*/

	void OnTriggerEnter(Collider col)
	{
		if ((col.tag == "EnemyShipTag") || (col.tag == "AsteroidTag" || col.tag == "EnemyShot") || (col.tag == "LBoss")  || (col.tag == "Boss")) 
		{
			HP--;
			GetComponent<Animator> ().SetTrigger ("Damage");//change player animation when hit

		}
			if (HP == 0)
			{
				PlayExplosion ();
				Destroy (gameObject);
				RestartPanel.SetActive (true);
			}

		if (col.tag == "WPUP") 
		{
			doubleShot = true;//collide get power up
			Destroy(col.gameObject);
		}

		if (col.tag == "HPUP") 
		{
			if (HP <= 10)
			{
				HP++;
			}
			Destroy(col.gameObject);
		}
	}

	void PlayExplosion()
	{
		GameObject explosion = (GameObject)Instantiate (Explosion);
		explosion.transform.position = transform.position;
	}


	void FireBullet()
	{
		GameObject Bullet1 = (GameObject)Instantiate (shot);
		Bullet1.transform.position = shotSpawn1.transform.position;

		GameObject Bullet2 = (GameObject)Instantiate (shot);
		Bullet2.transform.position = shotSpawn2.transform.position;
	}

	IEnumerator DoubleCountdown()
	{
		yield return new WaitForSeconds (10f);//how long it can last
		doubleShot=false;                     //comebak to normal
		
	}
	void StartGame ()
	{
		//HTP.SetActive (true); 
		intro.SetActive (true);
		StartCoroutine (TextIn ());
	}

	IEnumerator TextIn ()
	{
		yield return new WaitForSeconds (3f);
		intro.SetActive (false);
		//HTP.SetActive (false);
	}
}
