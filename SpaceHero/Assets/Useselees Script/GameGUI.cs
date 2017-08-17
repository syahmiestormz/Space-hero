using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameGUI : MonoBehaviour
{
	private GUIStyle style = new GUIStyle ();
	private Rect pauseMenuPosition;
	private Rect quitButton;
	private Rect quitButtonTexture;
	private Rect resumeButton;
	private Rect resumeButtonTexture;
	private Rect restartButton;
	private Rect restartButtonTexture;
	private Rect mainMenuButton;
	private Rect mainMenuButtonTexture;
	private Texture2D pauseMenu;
	private Texture2D button;

	private Rect gameOverGUIPosition;
    private Texture2D gameOverGUI;

	public bool alive = true;
	private Rect resultatPosition;
	private int score;

	private int score1 = 0;
	private int score2 = 0;
	private int score3 = 0;
	private int score4 = 0;
	private int score5 = 0;

	private Rect score1Position;
	private Rect score2Position;
	private Rect score3Position;
	private Rect score4Position;
	private Rect score5Position;

	private string appData;

	// Use this for initialization
	void Start ()
	{
		appData = System.Environment.GetFolderPath (System.Environment.SpecialFolder.ApplicationData);
		setPauseGUIVisible (false);
		setGameOverGUIVisible (false);
		pauseMenu = (Texture2D)Resources.Load ("GUI/PauseMenu", typeof(Texture2D));
	    gameOverGUI = (Texture2D)Resources.Load ("GUI/GameOver", typeof(Texture2D));
		button = (Texture2D)Resources.Load ("GUI/Button", typeof(Texture2D));
		style.font = (Font)Resources.Load ("Font/Rebellion", typeof(Font));
		style.fontSize = 36;
		style.normal.textColor = Color.white;
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetButtonDown ("Start")) {
			if (Time.timeScale == 0) {
				Time.timeScale = 1;
				setPauseGUIVisible (false);
			} else {
				Time.timeScale = 0;
				setPauseGUIVisible (true);
			}
		}
	
	}

	private void setPauseGUIVisible (bool isVisible)
	{
		if (isVisible) {
			pauseMenuPosition = new Rect (0, 0, Screen.width, Screen.height);
			resumeButton = new Rect (Screen.width / 2 - 125 + 15, Screen.height / 2 - 150, 200, 100);
			resumeButtonTexture = new Rect (Screen.width / 2 - 125, Screen.height / 2 - 150, 250, 75);
			restartButton = new Rect (Screen.width / 2 - 125 + 15, Screen.height / 2 - 50, 200, 100);
			restartButtonTexture = new Rect (Screen.width / 2 - 125, Screen.height / 2 - 50, 250, 75);
			mainMenuButton = new Rect (Screen.width / 2 - 125 + 15, Screen.height / 2 + 50, 200, 100);
			mainMenuButtonTexture = new Rect (Screen.width / 2 - 125, Screen.height / 2 + 50, 250, 75);
			quitButton = new Rect (Screen.width / 2 - 125 + 15, Screen.height / 2 + 150, 200, 100);
			quitButtonTexture = new Rect (Screen.width / 2 - 125, Screen.height / 2 + 150, 250, 75);
			resultatPosition = new Rect (1000, 10, 300, 100);

		} else {
			pauseMenuPosition = new Rect (1000, 0, Screen.width, Screen.height);
			resumeButton = new Rect (1000 + Screen.width / 2 - 125 + 15, Screen.height / 2 - 100, 300, 100);
			resumeButtonTexture = new Rect (1000 + Screen.width / 2 - 125, Screen.height / 2 - 100, 250, 75);
			restartButton = new Rect (1000 + Screen.width / 2 - 125 + 15, Screen.height / 2, 300, 100);
			restartButtonTexture = new Rect (1000 + Screen.width / 2 - 125, Screen.height / 2, 250, 75);
			mainMenuButton = new Rect (1000 + Screen.width / 2 - 125 + 15, Screen.height / 2 + 50, 300, 100);
			mainMenuButtonTexture = new Rect (1000 + Screen.width / 2 - 125, Screen.height / 2 + 50, 250, 75);
			quitButton = new Rect (1000 + Screen.width / 2 - 125 + 15, Screen.height / 2 + 100, 300, 100);
			quitButtonTexture = new Rect (1000 + Screen.width / 2 - 125, Screen.height / 2 + 100, 250, 75);
			resultatPosition = new Rect (10, 10, 300, 100);

			
		}
	}

	public void setGameOverGUIVisible (bool isVisible)
	{
		if (isVisible) {
			manageScore ();
			gameOverGUIPosition = new Rect (0, 0, Screen.width, Screen.height);
			restartButton = new Rect (Screen.width / 2 - 125 + 15, Screen.height / 2 - 50, 200, 100);
			restartButtonTexture = new Rect (Screen.width / 2 - 125, Screen.height / 2 - 50, 250, 75);
			mainMenuButton = new Rect (Screen.width / 2 - 125 + 15, Screen.height / 2 + 50, 200, 100);
			mainMenuButtonTexture = new Rect (Screen.width / 2 - 125, Screen.height / 2 + 50, 250, 75);
			quitButton = new Rect (Screen.width / 2 - 125 + 15, Screen.height / 2 + 150, 200, 100);
			quitButtonTexture = new Rect (Screen.width / 2 - 125, Screen.height / 2 + 150, 250, 75);
			resultatPosition = new Rect (Screen.width / 2 - 180, Screen.height / 2 - 230, 300, 100);
			score1Position = new Rect (Screen.width / 2 - 180, Screen.height / 2 - 170, 300, 100);
			score2Position = new Rect (Screen.width / 2 - 180, Screen.height / 2 - 120, 300, 100);	
			score3Position = new Rect (Screen.width / 2 - 180, Screen.height / 2 - 70, 300, 100);
			score4Position = new Rect (Screen.width / 2 - 180, Screen.height / 2 - 20, 300, 100);
			score5Position = new Rect (Screen.width / 2 - 180, Screen.height / 2 + 30, 300, 100);
		} else {
			gameOverGUIPosition = new Rect (1000, 0, Screen.width, Screen.height);
			restartButton = new Rect (1000 + Screen.width / 2 - 125 + 15, Screen.height / 2, 300, 100);
			restartButtonTexture = new Rect (1000 + Screen.width / 2 - 125, Screen.height / 2, 250, 75);
			mainMenuButton = new Rect (1000 + Screen.width / 2 - 125 + 15, Screen.height / 2 + 50, 300, 100);
			mainMenuButtonTexture = new Rect (1000 + Screen.width / 2 - 125, Screen.height / 2 + 50, 250, 75);
			quitButton = new Rect (1000 + Screen.width / 2 - 125 + 15, Screen.height / 2 + 100, 300, 100);
			quitButtonTexture = new Rect (1000 + Screen.width / 2 - 125, Screen.height / 2 + 100, 250, 75);
			resultatPosition = new Rect (10, 10, 300, 100);
			score1Position = new Rect (1000 + Screen.width / 2 - 180, Screen.height / 2 - 200, 300, 100);
			score2Position = new Rect (1000 + Screen.width / 2 - 180, Screen.height / 2 - 150, 300, 100);
			score3Position = new Rect (1000 + Screen.width / 2 - 180, Screen.height / 2 - 100, 300, 100);
			score4Position = new Rect (1000 + Screen.width / 2 - 180, Screen.height / 2 - 50, 300, 100);
			score5Position = new Rect (1000 + Screen.width / 2 - 180, Screen.height / 2, 300, 100);

		}
	}

	public void addScore (int point)
	{
		if (alive) {
			score += point;
		}
	}

	private void manageScore ()
	{
		Score scores;
		try
		{
			scores=Score.Load(appData+"/SpaceHero/scores.xml");
		}
		catch
		{
			System.IO.Directory.CreateDirectory (appData + "SpaceHero");
			scores = new Score ();

		}
		scores.newScore (score);
		scores.save(appData+"/SpaceHero/scores.xml");

		score1 = scores.score1;
		score2 = scores.score2;
		score3 = scores.score3;
		score4 = scores.score4;
		score5 = scores.score5;

	}





	void OnGUI ()
	{
		GUI.DrawTexture (pauseMenuPosition, pauseMenu);
		GUI.DrawTexture (resumeButtonTexture, button);
		GUI.DrawTexture (restartButtonTexture, button);
		GUI.DrawTexture (mainMenuButtonTexture, button);
		GUI.DrawTexture (quitButtonTexture, button);
      	GUI.DrawTexture (gameOverGUIPosition, gameOverGUI);

		GUI.Label (resultatPosition, "SCORE : " + score, style);
		GUI.Label (score1Position, "1 : " + score1, style);
		GUI.Label (score2Position, "2 : " + score2, style);
		GUI.Label (score3Position, "3 : " + score3, style);
		GUI.Label (score4Position, "4 : " + score4, style);
		GUI.Label (score5Position, "5 : " + score5, style);

		if (GUI.Button (resumeButton, "RESUME", style)) {
			Time.timeScale = 1;
			setPauseGUIVisible (false);
		}
		if (GUI.Button (restartButton, "RESTART", style)) {
			SceneManager.LoadScene ("Level1");
			Time.timeScale = 1;
		}
		if (GUI.Button (mainMenuButton, "MENU", style)) {
			SceneManager.LoadScene ("MainMenu");
			Time.timeScale = 1;
		}
		if (GUI.Button (quitButton, "QUIT", style)) {
			Application.Quit ();
		}




		
	}
}
