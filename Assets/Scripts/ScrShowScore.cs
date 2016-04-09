using UnityEngine;
using System.Collections;

public class ScrShowScore : MonoBehaviour {

	private float score;
	private ScrGameVars playerScore;
	public GUIStyle labelStyle;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		score = playerScore.getScore();
	}

	void OnGUI ()
	{
		// make the text bigger
		labelStyle.fontSize = 45;
		labelStyle.fontStyle = FontStyle.Bold;
		labelStyle.normal.textColor = Color.black;

		GUI.Label (new Rect (10, 90, 100, 30), "Score: " + (int)(score), labelStyle);

	}
}
