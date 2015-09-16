using UnityEngine;
using System.Collections;

public class MoveScript : MonoBehaviour {

	public Vector2 speed = new Vector2(10, 10);
	public Vector2 direction = new Vector2(-1, 0);
	private Vector2 movement;
	public bool isEnermy = false;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		movement = new Vector2 (
			speed.x * direction.x,
			speed.y * direction.y
		);
	}
	
	void FixedUpdate() {
		GetComponent<Rigidbody2D>().velocity = movement;
	}

	void OnCollisionEnter2D (Collision2D collision) {
		if (isEnermy)
			Destroy (gameObject);
	}
}
