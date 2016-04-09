using UnityEngine;
using System.Collections;

public class ScrObstacle : MonoBehaviour {

	private Vector2 target;
	private float speed;

	void Start () {
		target = new Vector2 (13f, this.transform.position.y);
		speed = 2f;
	}

	void Update () {
		this.transform.position = Vector2.MoveTowards (new Vector2 (transform.position.x, transform.position.y), target, speed * Time.deltaTime); //This can be used given we just want random enemy spawns (i.e. no actual [Spoons Rattling])
	}
}