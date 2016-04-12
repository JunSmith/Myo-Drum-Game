using UnityEngine;
using System.Collections;

public class ScrShowScore : MonoBehaviour {
	private int score;
	public ScrGameVars playerScore;
	public GUIStyle labelStyle;

	private void Update () {
		score = playerScore.getScore();
	}

	private void OnGUI () {
		labelStyle.fontSize = 30;
		labelStyle.fontStyle = FontStyle.Bold;
		labelStyle.normal.textColor = Color.white;

		GUI.Label (new Rect (10, 90, 100, 30), "Score: " + (int)(score), labelStyle);
	}
}
