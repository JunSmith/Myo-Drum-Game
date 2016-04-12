using UnityEngine;
using System.Collections;
//using UnityEngine.SceneManagement;

public class ScrObsDestroyer : MonoBehaviour {
	public ScrGameVars scrGameVars;

	private void OnTriggerEnter2D(Collider2D other) {
		Destroy (other.gameObject);
		scrGameVars.setHealth (-1);

		if(scrGameVars.getHealth() <= 0) {
			//SceneManager.LoadScene(2);
			PlayerPrefs.SetInt("Score", scrGameVars.getScore());
			Application.LoadLevel (2);
		}
	}
}
