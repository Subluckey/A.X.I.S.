﻿using UnityEngine;
using System.Collections;

public class SimpleMoveScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (10f, 10f);
	}
	
	// Update is called once per frame
	void Update () {

	}
}