using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour 
{
	public int score;//score
	private int BestScore=0;
	public Text ScoreText;

	// Use this for initialization
	void Awake ()
	{
		
		ScoreText = GetComponent<Text> ();//find the text
		BestScore = PlayerPrefs.GetInt ("bestScore");//retrive data from best score
		score = 0;

	}



	// Update is called once per frame
	void Update () 
	{
		ScoreText.text = "Score: " + score;
		if (score > BestScore) 
		{
			BestScore = score;//score>best score so we can have new one

		}

		/*if (score >= 10000)
		{
			SceneManager.LoadScene ("Level2");
			//DontDestroyOnLoad (this); //Ensures we don't lose our variables, playerPrefs work good for this too
		}*/

		GameObject.Find ("Score").GetComponent<Text> ().text = "Score: " + score;//Update score text
		GameObject.Find ("Best").GetComponent<Text> ().text = "Best: " + PlayerPrefs.GetInt("bestScore");//update
	}

	void OnDestroy()
	{
		PlayerPrefs.SetInt ("bestScore", BestScore);
		PlayerPrefs.Save ();
	}
}
