using UnityEngine;
using System.Collections;

public class BoundaryCheck : MonoBehaviour {

	public float friction = 0.1f;
	public float bounce = 0.9f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		string description = other.gameObject.GetComponent<ObjectDescription> ().description;
		if (description == "") {
			description = gameObject.GetComponent<ObjectDescription> ().description;
			Vector2 currentVelocity = other.gameObject.GetComponent<Rigidbody2D> ().velocity;
			if (description == "UpBoundary" || description == "DownBoundary") {
				currentVelocity.x *= (1 - friction);
				currentVelocity.y = - currentVelocity.y * bounce;
				if (description == "DownBoundary" && currentVelocity.y < 1) {
					currentVelocity.y = 0;
					currentVelocity.x = 0;
					other.gameObject.GetComponent<Rigidbody2D> ().gravityScale = 0;
				}
			} else if (description == "LeftBoundary" || description == "RightBoundary") {
				currentVelocity.x = - currentVelocity.x * bounce;
				currentVelocity.y *= (1 - friction);
			}
			other.gameObject.GetComponent<Rigidbody2D> ().velocity = currentVelocity;
		}
	}
}
