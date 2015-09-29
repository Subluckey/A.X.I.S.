using UnityEngine;
using System.Collections;

public class StrokePartical : MonoBehaviour {

	public  float lifeCycle = 2;
	public  float startTime;
	private float transparency;
	private SpriteRenderer thisRenderer;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, lifeCycle);
		startTime = Time.time;
		thisRenderer = gameObject.GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		float currentTime = Time.time;
		transparency = Mathf.SmoothStep(1f, 0f, (currentTime - startTime) / lifeCycle);
	}

	void FixedUpdate () {
		thisRenderer.color = new Color (1.0f, 1.0f, 1.0f, transparency);
		transform.localScale = new Vector3(transparency, transparency, 1f);
	}
}
