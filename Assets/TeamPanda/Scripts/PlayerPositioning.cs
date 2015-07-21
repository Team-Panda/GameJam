using UnityEngine;
using System.Collections;

public class PlayerPositioning : MonoBehaviour {

	public float viewDistance = 5f;
	public float minSpeedMultiplier = 1f;
	public float maxSpeedMultiplier = 4f;

	public float swayXMax = 1f;
	public float swayYMax = 1f;
	public float swayPause = 2f;

	private float swayTimer = 0f;
	
	private PlayerCamController playerCam;
	private Rigidbody rb;


	void Start () {
		playerCam = GameObject.FindWithTag ("PlayerCam").GetComponent<PlayerCamController>();
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		swayTimer += Time.deltaTime;

		// distance to cam, according to flight speed
	
		float speedMult = Mathf.Clamp (playerCam.CurrentSpeed / 100, minSpeedMultiplier, maxSpeedMultiplier);
		Vector3 targetPos = playerCam.transform.position + playerCam.transform.forward * viewDistance * speedMult;


		if (swayTimer > swayPause) {
			Debug.Log ("Sway");
			rb.AddForce(new Vector3(Random.Range (-swayXMax, swayXMax) * Time.smoothDeltaTime, Random.Range (-swayYMax, swayYMax) *Time.smoothDeltaTime, 0 ));
			swayTimer = 0f;
		}

		// organic random "drift"
//		targetPos.x += Random.Range (-swayXMax, swayXMax) * Time.smoothDeltaTime; 
//		targetPos.y += Random.Range (-swayYMax, swayYMax) *Time.smoothDeltaTime; 


		Debug.Log (speedMult);

		rb.MovePosition (targetPos);
	
	}
}
