using UnityEngine;
using System.Collections;

public class ScrShowScore : MonoBehaviour {
	private float score;
	public ScrGameVars playerScore;
	public GUIStyle labelStyle;

	void Update () {
		score = playerScore.getScore();
	}

	void OnGUI () {
		labelStyle.fontSize = 45;
		labelStyle.fontStyle = FontStyle.Bold;
		labelStyle.normal.textColor = Color.black;

		GUI.Label (new Rect (10, 90, 100, 30), "Score: " + (int)(score), labelStyle);
	}
}
