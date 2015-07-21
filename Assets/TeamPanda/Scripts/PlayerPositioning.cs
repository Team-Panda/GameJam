using UnityEngine;
using System.Collections;

public class PlayerPositioning : MonoBehaviour {

	public float viewDistance = 5f;

	private PlayerCamController playerCam;
	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		playerCam = GameObject.FindWithTag ("PlayerCam").GetComponent<PlayerCamController>();
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		// distance to cam, according to flight speed
		Debug.Log (
		Vector3 targetPos = playerCam.transform.position + playerCam.transform.forward * viewDistance * playerCam.CurrentSpeed/100;

		rb.MovePosition (targetPos);
	
	}
}
