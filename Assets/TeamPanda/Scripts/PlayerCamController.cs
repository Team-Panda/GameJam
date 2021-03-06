﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerCamController : MonoBehaviour {


	public float velocity = 10f;

	public float yawSpeed = 150f;
	public float tiltSpeed = 100f;
	public float pitchSpeed = 150f;

	public float CurrentSpeed {
		get { return currentSpeed; }
	}
	
	public float MaxSpeed {
		set { maxSpeed = value; }
	}

	private Rigidbody rb;
	private PlayerPositioning playerPos;
	private Transform vrHead;
	private float maxSpeed = 0f;
	private float currentSpeed = 0f;



	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		playerPos = GameObject.FindWithTag ("Player").GetComponent<PlayerPositioning>();
		vrHead = transform.FindChild ("VROneSDKHead");
	}
	


	void Update() {


		Vector3 localVrHeadForward = transform.InverseTransformDirection (vrHead.forward);
		Vector3 localZ = transform.InverseTransformDirection (transform.forward);

		float yaw = HeadYaw (localZ, localVrHeadForward);
		float pitch = HeadPitch (localZ, localVrHeadForward);
		float tilt = HeadTilt ();

		transform.Rotate (Vector3.up * yaw * yawSpeed * Time.deltaTime);
		transform.Rotate (Vector3.right * pitch * pitchSpeed * Time.deltaTime);
		transform.Rotate (Vector3.forward * tilt * tiltSpeed * Time.deltaTime);


		// increase speed to maxspeed
		if (currentSpeed < maxSpeed) {
			currentSpeed = currentSpeed + velocity;
		}
		// lower speed to maxspeed
		if (maxSpeed < currentSpeed) {
			currentSpeed =  currentSpeed - velocity;
		}

		Vector3 newPos = transform.position + transform.forward * Time.deltaTime * currentSpeed;
		transform.position = newPos;


		// adjust player turning angle
		playerPos.transform.localRotation = Quaternion.Euler( pitch * playerPos.turnAngle , yaw * playerPos.turnAngle, 0); 

	}

//	void OnGUI()
//	{
//		GUI.Label (new Rect (0, 0, 300, 20), "ANG:" + vrHead.rotation.eulerAngles);
//	}


	private float HeadTilt() {

		return -Input.acceleration.x;
	}

	private float HeadYaw(Vector3 reference, Vector3 target) {

		Vector3 newXZ = new Vector3 (target.x, 0, target.z);	
		int sign = Vector3.Cross(reference, target).y < 0 ? -1 : 1;		
		float xzAngle = sign * Vector3.Angle (reference, newXZ);

		return Mathf.Clamp (xzAngle / 90, -1, 1);
	}


	private float HeadPitch(Vector3 reference, Vector3 target) {
		
		Vector3 newYZ = new Vector3 (0, target.y, target.z);	
		int sign = Vector3.Cross(reference, target).x < 0 ? -1 : 1;		
		float yzAngle = sign * Vector3.Angle (reference, newYZ);
		
		return Mathf.Clamp (yzAngle / 90, -1, 1);
	}



}
