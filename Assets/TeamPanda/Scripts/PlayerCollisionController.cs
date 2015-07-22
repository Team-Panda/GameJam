﻿using UnityEngine;
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

	void OnTriggerEnter(Collider other) {

		// check if collisionTarget is a Spirit
		if (other.gameObject.GetComponent<SpiritStateController> ()) {
			// then dispatch to state controller
			playerState.collideWithSpirit(other.gameObject);

		}
	}
}