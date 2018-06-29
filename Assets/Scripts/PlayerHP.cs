using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
	public Text hpText;

	private Health health;

	void Awake ()
	{
		// Get player's health script, in order to access hp values
		health = GetComponent<Health>();
	}

	void Update ()
	{
		// Set text
		hpText.text = health.currentHP + "/" + health.maxHP;
	}
}
