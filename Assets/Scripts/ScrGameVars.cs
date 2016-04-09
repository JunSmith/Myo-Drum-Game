using UnityEngine;
using System.Collections;

public class ScrGameVars : MonoBehaviour {
	private int health;
	private int score;

	private void Start() {
		health = 100;
		score = 0;
	}

	public void setHealth(int change) {
		health += change;
	}

	public int getHealth() {
		return health;
	}

	public void SetScore(int change) {
		score += change;
	}

	public int getScore() {
		return score;
	}
}
