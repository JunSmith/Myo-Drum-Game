using UnityEngine;
using System.Collections;
using LockingPolicy = Thalmic.Myo.LockingPolicy;
using Pose = Thalmic.Myo.Pose;
using UnlockType = Thalmic.Myo.UnlockType;
using VibrationType = Thalmic.Myo.VibrationType;

public class ScrInput : MonoBehaviour {
	public GameObject myo = null;
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
		if (Input.GetKey (KeyCode.W)) {
			pose = Pose.Fist;
			Debug.Log (pose.ToString ());
		} else if (Input.GetKey (KeyCode.S)) {
			pose = Pose.FingersSpread;
			Debug.Log (pose.ToString ());
		} else if (Input.GetKey (KeyCode.A)) {
			pose = Pose.WaveIn;
			Debug.Log (pose.ToString ());
		} else if (Input.GetKey (KeyCode.D)) {
			pose = Pose.WaveOut;
			Debug.Log (pose.ToString ());
		} else {
			pose = Pose.Unknown;
		}
	}
}

