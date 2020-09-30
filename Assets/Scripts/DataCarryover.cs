using UnityEngine;
using System.Collections;

public class DataCarryover : MonoBehaviour {

	public int playerLives;

	public int playerScore;

	public int playerHealth;

	// Use this for initialization
	void Start () {

		PlayerPrefs.SetInt ("PlayerCurrentHealth", playerHealth);

		PlayerPrefs.SetInt ("PlayerMaxHealth", playerHealth);

		PlayerPrefs.SetInt ("PlayerCurrentLives", playerLives);

		PlayerPrefs.SetInt ("CurrentPlayerScore", playerScore);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
