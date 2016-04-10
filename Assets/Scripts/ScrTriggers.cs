using UnityEngine;
using System.Collections;

public class ScrTriggers : MonoBehaviour {
	public BoxCollider2D blColl;
	public BoxCollider2D rdColl;
	public BoxCollider2D grColl;
	public BoxCollider2D prColl;

	private void Start() {

		rdColl.enabled = false;
		blColl.enabled = false;
		grColl.enabled = false;
		prColl.enabled = false;
	}

	public void enable(int index) {
		switch (index) {
		case 0:
			rdColl.enabled = true;
			blColl.enabled = false;
			grColl.enabled = false;
			prColl.enabled = false;
			break;

		case 1:
			rdColl.enabled = false;
			blColl.enabled = true;
			grColl.enabled = false;
			prColl.enabled = false;
			break;

		case 2:
			rdColl.enabled = false;
			blColl.enabled = false;
			grColl.enabled = true;
			prColl.enabled = false;
			break;

		case 3:
			rdColl.enabled = false;
			blColl.enabled = false;
			grColl.enabled = false;
			prColl.enabled = true;
			break;
		}
		Debug.Log (index);
	}
}
