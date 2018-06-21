using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
	public float maxHP;
	public float dHP;

	private float currentHP;

	public GameObject bar;

	private Slider healthBar;

	void Awake ()
	{
		healthBar = bar.GetComponent<Slider>();
		currentHP = maxHP;
	}

	void Update ()
	{
		healthBar.value = currentHP;
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Attack")
		{
			changeHP (dHP);
			if (currentHP <= 0.0f)
			{
				Destroy (gameObject);
			}
		}
	}

	void changeHP (float dHP)
	{
		currentHP += dHP;
	}
}
