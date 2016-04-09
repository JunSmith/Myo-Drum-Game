using UnityEngine;
using System.Collections;

public class ScrObsDestroyer : MonoBehaviour {
	public ScrGameVars scrGameVars;

	private void OnTriggerEnter2D(Collider2D other) {
		Destroy (other.gameObject);
		scrGameVars.setHealth (-1);
	}
}
