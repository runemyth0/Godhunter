using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour
{
	public bool complete;

	void Start ()
	{
		complete = false;
	}

	void OnTriggerEnter2D (Collider2D other) // When the player hits the trigger, flips the flag from false to true
	{
		if (other.tag == "Player")
		{
			Debug.Log ("Level Complete");
			complete = true;
		}
	}
}
