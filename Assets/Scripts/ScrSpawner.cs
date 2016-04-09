using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScrSpawner : MonoBehaviour {
	public GameObject obstacle;
	private float[] spawnInterval = { 0.25f, 2f };
	private float[] ySpawnPts = { 4.15f, 2.15f, -0.6f, -2.75f};

	private Queue<Object> obsQueue0;
	private Queue<Object> obsQueue1;
	private Queue<Object> obsQueue2;
	private Queue<Object> obsQueue3;

	private IEnumerator Start () {

		obsQueue0 = new Queue<Object> ();
		obsQueue1 = new Queue<Object> ();
		obsQueue2 = new Queue<Object> ();
		obsQueue3 = new Queue<Object> ();
		yield return StartCoroutine("Spawn"); 
	}

//	private void Update() {
//		if (Input.GetKey (KeyCode.A) && obsQueue0.Count > 0) {
//			Object curObs = obsQueue0.Dequeue ();
//			Destroy (curObs);
//		}
//	}

	IEnumerator Spawn() {
		int row;

		while (true) {
			row = Random.Range (0, 4);

			switch (row) {
			case 0:
				try {
					obsQueue0.Enqueue (Instantiate (obstacle, new Vector2 (-10f, ySpawnPts [row]), Quaternion.identity));
				} catch {
					Debug.Log ("Unable to spawn");
				}

				break;

			case 1:
				try {
					obsQueue1.Enqueue (Instantiate (obstacle, new Vector2 (-10f, ySpawnPts [row]), Quaternion.identity));
				} catch {
					Debug.Log ("Unable to spawn");
				}
				break;

			case 2:
				try {
					obsQueue2.Enqueue (Instantiate (obstacle, new Vector2 (-10f, ySpawnPts [row]), Quaternion.identity));
				} catch {
					Debug.Log ("Unable to spawn");
				}
				break;


			case 3:
				try {
					obsQueue3.Enqueue (Instantiate (obstacle, new Vector2 (-10f, ySpawnPts [row]), Quaternion.identity));
				} catch {
					Debug.Log ("Unable to spawn");
				}
				break;
			}

			// Try to implement single array of 4 queues later

			yield return new WaitForSeconds (Random.Range (spawnInterval [0], spawnInterval [1]));
		}
	}

	public bool DestroyObstacle(int index) {
		Object curObs;

		switch (index) {
		case 0:
			if (obsQueue0.Count > 0) {
				curObs = obsQueue0.Dequeue ();
				Destroy (curObs);
				return true;
			}
			break;
		case 1:
			if (obsQueue1.Count > 0) {
				curObs = obsQueue1.Dequeue ();
				Destroy (curObs);
				return true;
			}
			break;
		case 2:
			if (obsQueue2.Count > 0) {
				curObs = obsQueue2.Dequeue ();
				Destroy (curObs);
				return true;
			}
			break;
		case 3:
			if (obsQueue3.Count > 0) {
				curObs = obsQueue3.Dequeue ();
				Destroy (curObs);
				return true;
			}
			break;
		default:
			break;
		}
		// Call after obstacle touches collision mesh at far right of screen
		// Remove the current first entry of the relevant list (maybe make it a queue)
		return false;
	}
}
