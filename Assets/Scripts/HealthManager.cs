using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {

	public int maxPlayerHealth;

	public static int playerHealth;

	public Slider healthBar;

	private LevelManager levelManager;

	public bool isDead;

	private LifeManager lifeSystem;

	void Start () 
	{
		healthBar = GetComponent<Slider>();

		playerHealth = PlayerPrefs.GetInt ("PlayerCurrentHealth");

		levelManager = FindObjectOfType<LevelManager>();

		lifeSystem = FindObjectOfType<LifeManager> ();

		isDead = false;
	}

	void Update () 
	{
		if (playerHealth <= 0 && !isDead) 
		{
			playerHealth = 0;
			lifeSystem.TakeLife ();
			levelManager.RespawnPlayer ();
			isDead = true;
		}

		if (playerHealth > maxPlayerHealth)
			playerHealth = maxPlayerHealth;

		healthBar.value = playerHealth;
	}

	public static void HurtPlayer (int damageToGive)
	{
		playerHealth -= damageToGive;

		PlayerPrefs.SetInt ("PlayerCurrentHealth", playerHealth);
	}

	public void FullHealth()
	{
		playerHealth = PlayerPrefs.GetInt ("PlayerMaxHealth");

		PlayerPrefs.SetInt ("PlayerCurrentHealth", playerHealth);
	}
}
