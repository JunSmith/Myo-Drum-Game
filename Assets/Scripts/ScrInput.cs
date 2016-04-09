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
		int obsDest;

		if (Input.GetKeyDown (KeyCode.W)) {
			destroy(0);
		} else if (Input.GetKeyDown (KeyCode.S)) {
			destroy(1);
		} else if (Input.GetKeyDown (KeyCode.A)) {
			destroy(2);
		} else if (Input.GetKeyDown (KeyCode.D)) {
			destroy(3);
		}
	}

	private void destroy(int index) {
		if (spawner.DestroyObstacle (index))
			vars.SetScore (10);
	}
}

//pose = Pose.WaveIn; 
//pose = Pose.DoubleTap;
//pose = Pose.Fist;
//pose = Pose.FingersSpread;
//pose = Pose.Unknown;