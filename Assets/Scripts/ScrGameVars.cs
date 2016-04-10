using UnityEngine;
using System.Collections;

public class ScrGameVars : MonoBehaviour {
	private int health;
	private int score;

	private void Start() {
		health = 3;
		score = 0;
	}

	public void setHealth(int change) {
		health += change;
		Debug.Log (health);
	}

	public int getHealth() {
		return health;
	}

	public void SetScore(int change) {
		score += change;
		Debug.Log (score);
	}

	public int getScore() {
		return score;
	}
}
