using UnityEngine;
using System.Collections;

public class PlayerStatController : MonoBehaviour {

	public float StartSpeed = 80f;

	private int level = 0;
	private float speed;


	// Use this for initialization
	void Start () {
		setSpeed (StartSpeed);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void setSpeed(float newSpeed) {
		speed = newSpeed;

		// TODO set speed for cam
	}
}
