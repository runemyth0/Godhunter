using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMover : MonoBehaviour
{
	public float floorLength;

	void OnTriggerExit (Collider other)
	{
		Destroy(other.gameObject);
	}
}

// Moves the floor so that the level does not end.
