﻿
/// This is the GameController Script:
/// - Control The Waves of the asteroid and the enemies

using UnityEngine;
using System.Collections;

//Asteroid Properties
[System.Serializable]
public class Asteroid 
{
	public GameObject asteroidBigObj; 		//Object Prefab
	public int Count; 						//Number of the object in 1 wave
	public float SpawnWait; 				//Time to wait before a new spawn
	public float StartWait; 				//Time to Start spawning
	public float WaveWait; 					//Time to wait till a new wave
}

//EnemyBlue Properties
[System.Serializable]
public class EnemyBlue 
{
	public GameObject enemyBlueObj;			//Object Prefab
	public int Count;						//Number of the object in 1 wave
	public float SpawnWait;					//Time to wait before a new spawn
	public float StartWait;					//Time to Start spawning
	public float WaveWait;					//Time to wait till a new wave
}

//EnemyGreen Properties
[System.Serializable]
public class EnemyGreen 
{
	public GameObject enemyGreenObj;		//Object Prefab
	public int Count;						//Number of the object in 1 wave
	public float SpawnWait;					//Time to wait before a new spawn
	public float StartWait;					//Time to Start spawning
	public float WaveWait;					//Time to wait till a new wave
}

//EnemyRed Properties
[System.Serializable]
public class EnemyRed 
{
	public GameObject enemyRedObj;		//Object Prefab
	public int Count;					//Number of the object in 1 wave
	public float SpawnWait;				//Time to wait before a new spawn
	public float StartWait;				//Time to Start spawning
	public float WaveWait;				//Time to wait till a new wave
}

[System.Serializable]
public class Boss1 
{
	public GameObject Boss1obj;		    //Object Prefab
	public int Count;					//Number of the object in 1 wave
	public float SpawnWait;				//Time to wait before a new spawn
	public float StartWait;				//Time to Start spawning
	public float WaveWait;				//Time to wait till a new wave
}

[System.Serializable]
public class Boss2 
{
	public GameObject Boss2obj;		    //Object Prefab
	public int Count;					//Number of the object in 1 wave
	public float SpawnWait;				//Time to wait before a new spawn
	public float StartWait;				//Time to Start spawning
	public float WaveWait;				//Time to wait till a new wave
}

[System.Serializable]
public class Boss3 
{
	public GameObject Boss3obj;		    //Object Prefab
	public int Count;					//Number of the object in 1 wave
	public float SpawnWait;				//Time to wait before a new spawn
	public float StartWait;				//Time to Start spawning
	public float WaveWait;				//Time to wait till a new wave
}


public class GameController_Script : MonoBehaviour 
{	
	//Public Var
	public Asteroid asteroid;			//make an Object from Class asteroid
	public EnemyBlue enemyBlue;			//make an Object from Class enemyBlue
	public EnemyGreen enemyGreen;		//make an Object from Class enemyGreen
	public EnemyRed enemyRed;			//make an Object from Class enemyRed
	public Boss1 boss1;
	public Boss2 boss2;
	public Boss3 boss3;
	public Vector2 spawnValues;			//Store spawning (x,y) values

	// Use this for initialization
	void Start ()
	{
		StartCoroutine (asteroidSpawnWaves());  	//Start IEnumerator function
		StartCoroutine (enemyBlueSpawnWaves());		//Start IEnumerator function
		StartCoroutine (enemyGreenSpawnWaves());	//Start IEnumerator function
		StartCoroutine (enemyRedSpawnWaves());		//Start IEnumerator function
		StartCoroutine (boss1SpawnWaves());
		StartCoroutine (boss2SpawnWaves());
		StartCoroutine (boss3SpawnWaves());
	}

	// Update is called once per frame
	void Update () 
	{
		
	}

	//Asteroid IEnumerator Coroutine
	IEnumerator asteroidSpawnWaves()
	{
		yield return new WaitForSeconds (asteroid.StartWait); 															//Wait for Seconds before start the wave

		//Infinite Loop
		while (true)
		{
			//Spawn Specific number of Objects in 1 wave
			for (int i = 0; i < asteroid.Count; i++)
			{
				Vector2 spawnPosition = new Vector2 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y);		//Random Spawn Position
				Quaternion spawnRotation = Quaternion.identity;							 								//Default Rotation
				Instantiate (asteroid.asteroidBigObj, spawnPosition, spawnRotation); 									//Instantiate Object
				yield return new WaitForSeconds (asteroid.SpawnWait); 													//Wait for seconds before spawning the next object
			}
			yield return new WaitForSeconds (asteroid.WaveWait); 														//wait for seconds before the next wave
		}
	}

	//EnemyBlue IEnumerator Coroutine
	IEnumerator enemyBlueSpawnWaves()
	{
		yield return new WaitForSeconds (enemyBlue.StartWait);															//Wait for Seconds before start the wave

		//Infinite Loop
		while (true)
		{
			//Spawn Specific number of Objects in 1 wave
			for (int i = 0; i < enemyBlue.Count; i++)
			{
				Vector2 spawnPosition = new Vector2 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y);		//Random Spawn Position
				Quaternion spawnRotation = Quaternion.identity;															//Default Rotation
				Instantiate (enemyBlue.enemyBlueObj, spawnPosition, spawnRotation);										//Instantiate Object
				yield return new WaitForSeconds (enemyBlue.SpawnWait);													//Wait for seconds before spawning the next object
			}
			yield return new WaitForSeconds (enemyBlue.WaveWait);														//wait for seconds before the next wave
		}
	}

	//EnemyGreen IEnumerator Coroutine
	IEnumerator enemyGreenSpawnWaves()
	{
		yield return new WaitForSeconds (enemyGreen.StartWait);															//Wait for Seconds before start the wave

		//Infinite Loop
		while (true)
		{
			//Spawn Specific number of Objects in 1 wave
			for (int i = 0; i < enemyGreen.Count; i++)
			{
				Vector2 spawnPosition = new Vector2 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y);		//Random Spawn Position
				Quaternion spawnRotation = Quaternion.identity;															//Default Rotation
				Instantiate (enemyGreen.enemyGreenObj, spawnPosition, spawnRotation);									//Instantiate Object
				yield return new WaitForSeconds (enemyGreen.SpawnWait);													//Wait for seconds before spawning the next object
			}
			yield return new WaitForSeconds (enemyGreen.WaveWait);														//wait for seconds before the next wave
		}
	}

	//EnemyRed IEnumerator Coroutine
	IEnumerator enemyRedSpawnWaves()
	{
		yield return new WaitForSeconds (enemyRed.StartWait);															//Wait for Seconds before start the wave

		//Infinite Loop
		while (true)
		{
			//Spawn Specific number of Objects in 1 wave
			for (int i = 0; i < enemyRed.Count; i++)
			{
				Vector2 spawnPosition = new Vector2 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y);		//Random Spawn Position
				Quaternion spawnRotation = Quaternion.identity;															//Default Rotation
				Instantiate (enemyRed.enemyRedObj, spawnPosition, spawnRotation);										//Instantiate Object
				yield return new WaitForSeconds (enemyRed.SpawnWait);													//Wait for seconds before spawning the next object
			}
			yield return new WaitForSeconds (enemyRed.WaveWait);														//wait for seconds before the next wave
		}
	}
	IEnumerator boss1SpawnWaves()
	{
		yield return new WaitForSeconds (enemyRed.StartWait);															//Wait for Seconds before start the wave

		//Infinite Loop
		while (true)
		{
			//Spawn Specific number of Objects in 1 wave
			for (int i = 0; i < boss1.Count; i++)
			{
				Vector2 spawnPosition = new Vector2 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y);		//Random Spawn Position
				Quaternion spawnRotation = Quaternion.identity;															//Default Rotation
				Instantiate (boss1.Boss1obj, spawnPosition, spawnRotation);										//Instantiate Object
				yield return new WaitForSeconds (boss1.SpawnWait);													//Wait for seconds before spawning the next object
			}
			yield return new WaitForSeconds (boss1.WaveWait);														//wait for seconds before the next wave
		}
	}

	IEnumerator boss2SpawnWaves()
	{
		yield return new WaitForSeconds (boss2.StartWait);															//Wait for Seconds before start the wave

		//Infinite Loop
		while (true)
		{
			//Spawn Specific number of Objects in 1 wave
			for (int i = 0; i < boss2.Count; i++)
			{
				Vector2 spawnPosition = new Vector2 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y);		//Random Spawn Position
				Quaternion spawnRotation = Quaternion.identity;															//Default Rotation
				Instantiate (boss2.Boss2obj, spawnPosition, spawnRotation);										//Instantiate Object
				yield return new WaitForSeconds (boss2.SpawnWait);													//Wait for seconds before spawning the next object
			}
			yield return new WaitForSeconds (boss2.WaveWait);														//wait for seconds before the next wave
		}
	}


	IEnumerator boss3SpawnWaves()
	{
		yield return new WaitForSeconds (boss3.StartWait);															//Wait for Seconds before start the wave

		//Infinite Loop
		while (true)
		{
			//Spawn Specific number of Objects in 1 wave
			for (int i = 0; i < boss3.Count; i++)
			{
				Vector2 spawnPosition = new Vector2 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y);		//Random Spawn Position
				Quaternion spawnRotation = Quaternion.identity;															//Default Rotation
				Instantiate (boss3.Boss3obj, spawnPosition, spawnRotation);										//Instantiate Object
				yield return new WaitForSeconds (boss3.SpawnWait);													//Wait for seconds before spawning the next object
			}
			yield return new WaitForSeconds (boss3.WaveWait);														//wait for seconds before the next wave
		}
	}
		
}