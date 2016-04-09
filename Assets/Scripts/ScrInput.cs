using UnityEngine;
using System.Collections;
using LockingPolicy = Thalmic.Myo.LockingPolicy;
using Pose = Thalmic.Myo.Pose;
using UnlockType = Thalmic.Myo.UnlockType;
using VibrationType = Thalmic.Myo.VibrationType;

public class ScrInput : MonoBehaviour {
	public GameObject myo = null;
	public ScrGameVars vars;
	public ScrSpawner spawner;
	private Quaternion antiYaw = Quaternion.identity;
	private float referenceRoll = 0.0f;
	private Pose pose = Pose.Unknown;
	private ThalmicMyo thalmicMyo;

	private void Start() {
		try {
			thalmicMyo = myo.GetComponent<ThalmicMyo> (); // This will fail if there is no Myo
		}
		catch {
			Debug.Log ("No Myo found");
		}
	}

	private void Update() {
		if (Input.GetKeyDown (KeyCode.W)) {
//			pose = Pose.Fist;
//			Debug.Log (pose.ToString ());
			spawner.DestroyObstacle(0);
		} else if (Input.GetKeyDown (KeyCode.S)) {
//			pose = Pose.FingersSpread;
//			Debug.Log (pose.ToString ());
			spawner.DestroyObstacle(1);
		} else if (Input.GetKeyDown (KeyCode.A)) {
//			pose = Pose.WaveIn;
//			Debug.Log (pose.ToString ());
			spawner.DestroyObstacle(2);
		} else if (Input.GetKeyDown (KeyCode.D)) {
//			pose = Pose.WaveOut;
//			Debug.Log (pose.ToString ());
			spawner.DestroyObstacle(3);
		} else {
			pose = Pose.Unknown;
		}
	}
}

