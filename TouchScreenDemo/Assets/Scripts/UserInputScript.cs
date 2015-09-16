using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

public class UserInputScript : MonoBehaviour {
	
	public Transform strokePrefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	/*
	 * This function collects the trace of mouse
	 * when it is clicked
	 */
	IEnumerator OnMouseDown () {
		Vector3 targetScreenSpace = Camera.main.WorldToScreenPoint (transform.position);  
		while (Input.GetMouseButton (0)) {
			Vector3 mouseScreenSpace = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, targetScreenSpace.z);
			Vector3 mouseWorldSpace = Camera.main.ScreenToWorldPoint(mouseScreenSpace);
			mouseTrace.Enqueue(mouseWorldSpace);
			yield return new WaitForFixedUpdate ();
		}
	}

	void FixedUpdate () {
		while (mouseTrace.Count > 0) {
			Vector3 popedPosition = mouseTrace.Dequeue ();
			Transform newStrokePartical = Instantiate (strokePrefab) as Transform;
			newStrokePartical.position = popedPosition;
			strokeParticals.Enqueue(newStrokePartical.gameObject);
		}
		while (true) {
			if (strokeParticals.Count == 0)
				break;
			GameObject partical = strokeParticals.Peek ();
			if (partical == null) {
				strokeParticals.Dequeue ();
				continue;
			}
			var currentTime = Time.time;
			if (currentTime - partical.GetComponent<StrokePartical> ().startTime > 4.0f)
				strokeParticals.Dequeue ();
			else
				break;
		}
	}
		
	public Queue<Vector3> mouseTrace = new Queue<Vector3> ();
	public Queue<GameObject> strokeParticals = new Queue<GameObject> ();
}
