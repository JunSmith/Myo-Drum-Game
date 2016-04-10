using UnityEngine;
using System.Collections;

public class ScrArea : MonoBehaviour {
	public ScrGameVars scrGameVars;

	private void OnTriggerEnter2D(Collider2D other) {
		Destroy (other.gameObject);
		scrGameVars.SetScore (10);
	}
}
