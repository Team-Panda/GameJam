using UnityEngine;
using System.Collections;

public class PlayerPositioning : MonoBehaviour {

	public float viewDistance = 5f;
	public float minSpeedMultiplier = 1f;
	public float maxSpeedMultiplier = 4f;

	public float swayXMax = 1f;
	public float swayYMax = 1f;
	public float swayPause = 2f;
	public float swaySmoothTime = 1f;

	private Vector3 swayVelocity = Vector3.zero;
	
	private PlayerCamController playerCam;
	private Rigidbody rb;


	void Start () {
		playerCam = GameObject.FindWithTag ("PlayerCam").GetComponent<PlayerCamController>();
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		// distance to cam, according to flight speed
		float speedMult = Mathf.Clamp (playerCam.CurrentSpeed / 100, minSpeedMultiplier, maxSpeedMultiplier);
		Vector3 targetPos = playerCam.transform.position + playerCam.transform.forward * viewDistance * speedMult;

		// organic random "drift"
		targetPos.x += Random.Range (-swayXMax, swayXMax); 
		targetPos.y += Random.Range (-swayYMax, swayYMax); 

		transform.position =  Vector3.SmoothDamp(transform.position, targetPos, ref swayVelocity, swaySmoothTime);

	
	}
}
