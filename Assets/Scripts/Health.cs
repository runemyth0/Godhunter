﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
	public float maxHP;

	public float currentHP;

	public GameObject bar;

	private Slider healthBar;

	private bool alive;

	void Awake ()
	{
		alive = true;
		healthBar = bar.GetComponent<Slider>();
		currentHP = maxHP;
	}

	void Update ()
	{
		healthBar.value = currentHP;

		if (currentHP <= 0.0f)
		{
			alive = false;
			Destroy(this.gameObject);
		}
	}

	public void changeHP (float dHP)
	{
		currentHP += dHP;
	}
}
