using UnityEngine;
using System.Collections;

public class ShotScript : MonoBehaviour {

	public bool isEnermyShot = false;
	public int damage = 1;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, 10);
	}
}
