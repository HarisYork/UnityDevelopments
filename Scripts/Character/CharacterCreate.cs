using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterCreate : MonoBehaviour
{
    public InputField inputName;
    public string playerName;
    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void GetName()
    {
        if(inputName.text!=null)
        {
            playerName=inputName.text;
            Debug.Log("Welcome "+playerName);
        }
    }
    public void ToGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    	public void GetRotate(float speed)
	{
		transform.localRotation *= Quaternion.Euler(0f, speed, 0f);
	}
}
