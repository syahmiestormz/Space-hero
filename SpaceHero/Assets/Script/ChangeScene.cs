using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

	// Use this for initialization
	public void LoadScene(string levelToLoad)
	{
		SceneManager.LoadScene (levelToLoad);
	}

	public void Quit()
	{
		Application.Quit ();
	}
}
