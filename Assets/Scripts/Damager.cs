using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
	public float dHP;

	private Health healthInstance;

	void Start ()
	{
		this.gameObject.GetComponent<RangedRemover>();
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		this.healthInstance = other.GetComponent<Health>();
		this.healthInstance.changeHP(-dHP);

		if (other.tag == "Enemy" && this.gameObject.tag == "Ranged")
		{
			Destroy(this.gameObject);
		}
	}
}
