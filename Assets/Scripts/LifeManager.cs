using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour {

	private int lifeCounter;

	private Text theText;

	public GameObject gameOverScreen;

	public PlayerController player;

	public string mainMenu;

	public float waitAfterGameOver;

	void Start () 
	{
		theText = GetComponent<Text>();

		lifeCounter = PlayerPrefs.GetInt("PlayerCurrentLives");

		player = FindObjectOfType<PlayerController> ();
	}


	void Update () 
	{
		if (lifeCounter < 0) 
		{
			gameOverScreen.SetActive (true);
			player.gameObject.SetActive (false);
		}

		theText.text = "x " + lifeCounter;

		if (gameOverScreen.activeSelf) 
		{
			waitAfterGameOver -= Time.deltaTime;
		}

		if (waitAfterGameOver < 0) 
		{
			Application.LoadLevel ("MainMenu");
		}
	}

	public void GiveLife()
	{
		lifeCounter++;

		PlayerPrefs.SetInt ("PlayerCurrentLives", lifeCounter);
	}

	public void TakeLife()
	{
		lifeCounter--;

		PlayerPrefs.SetInt ("PlayerCurrentLives", lifeCounter);
	}
}
