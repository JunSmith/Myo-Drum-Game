using UnityEngine;
using System.Collections;
using LockingPolicy = Thalmic.Myo.LockingPolicy;
using Pose = Thalmic.Myo.Pose;
using UnlockType = Thalmic.Myo.UnlockType;
using VibrationType = Thalmic.Myo.VibrationType;

public class ScrInput : MonoBehaviour {
	public GameObject myo;
	public ScrGameVars vars;
	public ScrSpawner spawner;
	public ScrTriggers triggers;

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
		try {
			pose = thalmicMyo.pose;

			if (pose == Pose.WaveIn) {
				triggers.enable (0);
			} else if (pose == Pose.DoubleTap) {
				triggers.enable (1);
			} else if (pose == Pose.Fist) {
				triggers.enable (2);
			} else if (pose == Pose.FingersSpread) {
				triggers.enable (3);
			}
		} catch {
			Debug.Log ("Myo not found");
		}

//		if (Input.GetKeyDown (KeyCode.W)) {
////			destroy(0);
//			triggers.enable(0);
//		} else if (Input.GetKeyDown (KeyCode.S)) {
////			destroy(1);
//			triggers.enable(1);
//		} else if (Input.GetKeyDown (KeyCode.A)) {
////			destroy(2);
//			triggers.enable(2);
//		} else if (Input.GetKeyDown (KeyCode.D)) {
////			destroy(3);
//			triggers.enable(3);
//		}


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
