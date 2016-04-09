using UnityEngine;
using System.Collections;

public class ScrObsDestroyer : MonoBehaviour {

	public GameObject sc;

	private void OnTriggerEnter2D(Collider2D other) {
		Destroy (other.gameObject);
		Debug.Log ("Destroyed");
	}
}
