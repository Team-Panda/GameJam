using UnityEngine;
using System.Collections;

public class PlayerCollisionController : MonoBehaviour {

	
	private PlayerStateController playerState;

	// Use this for initialization
	void Start () {
		playerState = GetComponent<PlayerStateController> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision other) {
		
		// check if collisionTarget is a Spirit
		if (other.gameObject.GetComponent<SpiritStateController> ()) {
			// then dispatch to state controller
			playerState.CollideWithSpirit (other.gameObject);
			// colliding  with environtment etc.
		} else {
			playerState.TakeDamage();
		}
		
	}

//	void OnTriggerEnter(Collider other) {
//
//		// check if collisionTarget is a Spirit
//		if (other.gameObject.GetComponent<SpiritStateController> ()) {
//			// then dispatch to state controller
//			playerState.CollideWithSpirit (other.gameObject);
//		// colliding  with environtment etc.
//		} else {
//			playerState.TakeDamage();
//		}
//
//	}
}
