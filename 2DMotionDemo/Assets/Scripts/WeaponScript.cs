using UnityEngine;
using System.Collections;

public class WeaponScript : MonoBehaviour {

	public Transform shotPrefab;
	public float shootRate = 0.25f;
	private float coolDown; 

	// Use this for initialization
	void Start () {
		coolDown = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (coolDown > 0) {
			coolDown -= Time.deltaTime;
		}
	}

	public void Attach(bool isEnermy) {
		if (CanAttack) {
			coolDown = shootRate;
			var shotTransform = Instantiate(shotPrefab) as Transform;
			shotTransform.position = transform.position;
			ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();
			if (shot != null) {
				shot.isEnermyShot = isEnermy;
			}
			MoveScript move = shotTransform.gameObject.GetComponent<MoveScript>();
			if (move != null) {
				move.direction = this.transform.right;
			}
		}
	}

	public bool CanAttack {
		get {
			return coolDown <= 0;
		}
	}
}
