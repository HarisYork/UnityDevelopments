using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
	public static bool GameIsPaused = false;
	public GameObject pauseMenuUI;

	// Update is called once per frame
	void Update () 
	{
		
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			if (GameIsPaused) 
			{Resume ();} 
			else 
			{Pause();}
		}	
	}


	public void Resume()
		{
		pauseMenuUI.SetActive (false);
		GameIsPaused = false;
		Time.timeScale=1f;
		// FindObjectOfType<PlayerController> ().enabled = true;
		// FindObjectOfType<PlayerMotor> ().enabled = true;
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		}
	public void Pause()
		{
		// FindObjectOfType<PlayerController> ().enabled = false;
		// FindObjectOfType<PlayerMotor> ().enabled = false;

		//ЗАМЕНИЛ В КОНТРОЛЛЕРЕ НА 	
		//if(PauseMenu.GameIsPaused)
		//{
		//	return;
		//}
		pauseMenuUI.SetActive (true);
		GameIsPaused = true;
		Time.timeScale=0f;
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		}
		public void LoadMenu()
		{
			Time.timeScale=1f;
			SceneManager.LoadScene("Menu");
		}
		public void QuitGame()
		{
			Application.Quit();
		}
}
