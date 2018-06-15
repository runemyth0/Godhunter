using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
	public float healthPoints;
	public float damagePoints;

	private float currentHealthPoints;

	void Start ()
	{
		currentHealthPoints = healthPoints;
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Attack")
		{
			currentHealthPoints -= damagePoints;
			if (currentHealthPoints <= 0.0f)
			{
				Destroy (gameObject);
			}
		}
	}
}
