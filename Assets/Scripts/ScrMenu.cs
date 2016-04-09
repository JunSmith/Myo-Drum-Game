using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ScrMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	public void BtnPlay_click() {
		SceneManager.LoadScene (1);
	}
}
