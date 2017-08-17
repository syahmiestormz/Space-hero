using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

	public Transform MainMenu, PauseMenu,Level;
	public void LoadScene(string name)
	{
		SceneManager.LoadScene (name);
	}

	public void QuitGame()
	{
		Application.Quit();
	}

	public void Pause(bool clicked)
	{
		if (clicked == true) {
			PauseMenu.gameObject.SetActive (clicked);	
			Level.gameObject.SetActive (false);
		} 
		else 
		{
			PauseMenu.gameObject.SetActive (clicked);	
			Level.gameObject.SetActive (true);
		}
	}
		
}
