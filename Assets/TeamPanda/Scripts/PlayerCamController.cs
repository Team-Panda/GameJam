using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerCamController : MonoBehaviour {

	public float maxSpeed = 200f;
	public float velocity = 10f;

	public float yawSpeed = 150f;
	public float tiltSpeed = 100f;
	public float pitchSpeed = 150f;

	private Rigidbody rb;
	private Transform vrHead;
	private float currentSpeed = 0f;

	public float CurrentSpeed {
		get { return currentSpeed; }
	}

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		vrHead = transform.FindChild ("VROneSDKHead");
	}
	


	void Update() {


		Vector3 localVrHeadForward = transform.InverseTransformDirection (vrHead.forward);
		Vector3 localZ = transform.InverseTransformDirection (transform.forward);


		transform.Rotate (Vector3.up * headYaw (localZ, localVrHeadForward) * yawSpeed * Time.deltaTime);
		transform.Rotate (Vector3.right * headPitch (localZ, localVrHeadForward) * pitchSpeed * Time.deltaTime);
		transform.Rotate (Vector3.forward * headTilt () * tiltSpeed * Time.deltaTime);


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



	}

	void OnGUI()
	{
		GUI.Label (new Rect (0, 0, 300, 20), "ANG:" + vrHead.rotation.eulerAngles);
	}


	private float headTilt() {
		
//		Vector3 newXY = new Vector3 (target.x, target.y, 0);	
//		int sign = Vector3.Cross(reference, target).z < 0 ? -1 : 1;		
//		float xyAngle = sign * Vector3.Angle (reference, newXY);
//
//		Debug.Log (xyAngle);
//		return Mathf.Clamp (xyAngle / 90, -1, 1);

		return -Input.acceleration.x;
	}

	private float headYaw(Vector3 reference, Vector3 target) {

		Vector3 newXZ = new Vector3 (target.x, 0, target.z);	
		int sign = Vector3.Cross(reference, target).y < 0 ? -1 : 1;		
		float xzAngle = sign * Vector3.Angle (reference, newXZ);

		return Mathf.Clamp (xzAngle / 90, -1, 1);
	}


	private float headPitch(Vector3 reference, Vector3 target) {
		
		Vector3 newYZ = new Vector3 (0, target.y, target.z);	
		int sign = Vector3.Cross(reference, target).x < 0 ? -1 : 1;		
		float yzAngle = sign * Vector3.Angle (reference, newYZ);
		
		return Mathf.Clamp (yzAngle / 90, -1, 1);
	}


}
