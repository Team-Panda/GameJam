using UnityEngine;
using System.Collections;

public class PlayerCamController : MonoBehaviour {

	public float maxSpeed = 200f;
	public float velocity = 10f;
	public float rotationSpeed = 2f;

	private Rigidbody rb;
	private Transform vrHead;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		vrHead = transform.FindChild ("VROneSDKHead");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate() {

		// get angle diffrence between vrHead in PlayerCamController
		//transform.rotation = vrHead.localRotation.y;

			//Debug.Log (transform.rotation.y + " | " + vrHead.localRotation.eulerAngles.y +  " | " + (transform.rotation.y - vrHead.localRotation.y));
		/*Vector3 outer = vrHead.forward;
		Vector3 inner = 

		int sign = Vector3.Cross(v1, v2).z < 0 ? -1 : 1;
		Debug.Log(sign * Vector3.Angle(v1, v2));


		int sign = Vector3.Cross(transform.forward, vrHead.forward).z < 0 ? -1 : 1;
		Debug.Log(sign * Vector3.Angle(transform.forward, vrHead.forward));
		**/
		Vector3 localVrHeadForward = transform.InverseTransformDirection (vrHead.forward);

		// angle left right
		Vector3 newXZ = new Vector3 (localVrHeadForward.x, 0, localVrHeadForward.z);

		int sign = Vector3.Cross(newXZ, transform.forward).y < 0 ? -1 : 1;

		float xzAngle = sign * Vector3.Angle (transform.forward, newXZ);


		Debug.Log(transform.forward);
		//Debug.Log(Vector3.Angle(transform.forward, newXZ));


		//Debug.Log (transform.InverseTransformDirection(vrHead.forward));

		if (rb.velocity.magnitude > maxSpeed) {
			rb.velocity = rb.velocity.normalized * maxSpeed;
		} else {
			rb.AddForce (vrHead.forward * velocity);
		}

		
	}

	public static float DeltaYaw(Transform source, Vector3 destination)
	{
		var destination2 = source.InverseTransformPoint(destination);
		return (Mathf.Atan2(destination2.z,destination2.x) * Mathf.Rad2Deg) - 90;
	}
}
