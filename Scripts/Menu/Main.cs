using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.UI;
public class Main : MonoBehaviour 
{
	public Text tipsText;
	public List<string> tipsList;
	void Start()
	{
		tipsText.text=tipsList[Random.Range(0, tipsList.Count)];
	}
	public void StartGame()
		{
			SceneManager.LoadScene("Sample");
		}
	public void EndGame()
		{
			Application.Quit();
		}
}
