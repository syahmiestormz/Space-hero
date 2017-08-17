using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
	
	public GameObject playButton;
	public GameObject playerShip;
	public GameObject enemySpawner;
	public GameObject GameOverGO;
	public GameObject scoreUITextGO;

	public enum GameManagerState
	{
		Opening,
		Gameplay,
		GameOver,

	}

	GameManagerState GMState;

	void Start ()
	{
		GMState = GameManagerState.Opening;
	}


	void UpdateGameManagerState () 
	{
		switch (GMState) 
		{
		case GameManagerState.Opening:

			GameOverGO.SetActive (false);
			playButton.SetActive (true);

			break;
		case GameManagerState.Gameplay:

			scoreUITextGO.GetComponent<GameScore>().Score=0;

			playButton.SetActive (false);



			//enemySpawner.GetComponent<EnemySpawn> ().ScheduleEnemySpawner ();


			break;
		case GameManagerState.GameOver:

			//enemySpawner.GetComponent<EnemySpawn> ().UnscheduleEnemySpawner ();

			GameOverGO.SetActive (true);

			Invoke ("ChangeToOpeningState", 8f);
			break;

		}

	}

	public void SetGameManagerState(GameManagerState state)
	{
		GMState = state;
		UpdateGameManagerState ();
	}

	public void StartGameplay()
	{
		GMState = GameManagerState.Gameplay;
		UpdateGameManagerState ();
	}
	public void ChangeToOpeningState()
	{
		SetGameManagerState (GameManagerState.Opening);
	}
}
