using UnityEngine;
using System.Collections;
//using UnityEngine.SceneManagement;

public class ScrMenu : MonoBehaviour {

	public void BtnPlay_click() {
		//SceneManager.LoadScene (1);
		Application.LoadLevel (1);
	}

	public void BtnMenu_click() {
		//SceneManager.LoadScene(0);
		Application.LoadLevel (0);
	}
}
