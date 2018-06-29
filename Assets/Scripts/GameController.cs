using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
	private bool restart;

	public Text levelWinText;
	public Text levelLossText;
	public Text restartText;

	private GameObject player;
	private GameObject end;

	private LevelEnd levelFinish;
	private Health health;

	void Awake ()
	{
		// Set text variables to blank
		restartText.text = "";
		levelWinText.text = "";
		levelLossText.text = "";
		// Find the player gameobject and get the Health script
		player = GameObject.FindWithTag("Player");
		health = player.GetComponent<Health>();
		// Find the level end trigger and get the LevelEnd script
		end = GameObject.FindWithTag("Finish");
		levelFinish = end.GetComponent<LevelEnd>();
	}

	void Update ()
	{
		if (restart == true)
		{
			if (Input.GetKeyDown (KeyCode.R))
			{
				Debug.Log ("Restarting level...");
				SceneManager.LoadScene ("Demo",LoadSceneMode.Single); // Restart level
				StopCoroutine (RestartMessage ());
			}
		}
	}

	void LateUpdate ()
	{
		// Victory Screen
		if (levelFinish.complete == true) // If the player reaches the end of the level and triggers the flag, end the level
		{
			Debug.Log ("You Win!");
			levelWinText.text = "Victory!"; // Play victory screen
			StartCoroutine (RestartMessage ()); // Offer restart
		}

		// Loss Screen
		if (health.alive == false) // If the player is not alive, then end the level
		{
			Debug.Log ("Game Over");
			levelLossText.text = "Defeat"; // Play loss screen
			StartCoroutine (RestartMessage ()); // Offer restart
		}
	}

	IEnumerator RestartMessage () // Changes the message of the restartText object
	{
		yield return new WaitForSeconds (3);
		if (levelFinish.complete == true)
		{
			restartText.text = "Press 'R' to restart";
		}
		else
		{
			restartText.text = "Press 'R' to try again.";
		}
		restart = true;
		StopCoroutine (RestartMessage ());
	}
}
