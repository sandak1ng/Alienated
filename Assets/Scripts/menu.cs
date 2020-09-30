using UnityEngine;
using System.Collections;

public class menu : MonoBehaviour
{

	public Animator dialog;
	public string levelName;
	public int playerLives;

	public void StartGame ()
	{

		PlayerPrefs.SetInt ("PlayerCurrentLives", playerLives);

		PlayerPrefs.SetInt ("CurrentPlayerScore", 0);

		Application.LoadLevel ("MainGame");
	}

	public void ExitGame ()
	{
		Application.Quit ();          
	}


	public void OpenSettings ()
	{
		dialog.SetBool ("isHidden", false);
	}


	public void CloseSettings ()
	{
//		startButton.SetBool ("isHidden", false);
//		settingsButton.SetBool ("isHidden", false);
		dialog.SetBool ("isHidden", true);
	}
}
