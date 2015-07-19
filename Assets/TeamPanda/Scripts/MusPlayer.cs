using UnityEngine;
using System.Collections;

public class MusPlayer : MonoBehaviour {

	public MusExhibit initialExhibit;
	public float tiltSpeed = 35f;

	private MusExhibit currentExhibit = null;
	private MusExhibit nextExhibit = null;

	private float walkSmoothTime = 0.3f;
	private Vector3 walkVelocity = Vector3.zero;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		// if the player has to be moved to the next exhibit
		if(nextExhibit) {

			Vector3 targetDir =  new Vector3(transform.position.x - nextExhibit.transform.position.x, 0, transform.position.z - nextExhibit.transform.position.z);
			targetDir = targetDir.normalized * nextExhibit.viewDistance;

			Vector3 targetPosition = new Vector3(nextExhibit.transform.position.x + targetDir.x, transform.position.y, nextExhibit.transform.position.z + targetDir.z);

			transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref walkVelocity, walkSmoothTime);

			// if target is reached
			if(walkVelocity == Vector3.zero) {
				attachToExhibit(nextExhibit);
			}
		
		// if the player is currently attached to an exhibit		
		} else if (currentExhibit) {
			// enable tilt controle
			tiltControlle();

		}

	}

	public void walkToExhibit(MusExhibit exh) {

		// if player isn't attached to this exhibit..
		if(currentExhibit != exh) {

			Debug.Log ("Player walking to " + exh);

			detachFromCurrentExhibit();
			nextExhibit = exh;


		} else {
			
			Debug.Log ("Player is already at " + exh);

		}

	}

	private void attachToExhibit(MusExhibit exh) {


		currentExhibit = exh;
		nextExhibit = null;

		Debug.Log ("reached " + currentExhibit);
		//exh.GetComponent<MusSelectableObject>().IsSelectable = true;

		currentExhibit.startAnim ();
	}

	private void detachFromCurrentExhibit() {
		// make it selectable again
		if(currentExhibit) {
			currentExhibit.GetComponent<MusSelectableObject>().IsSelectable = true;
			currentExhibit.stopAnim();
			currentExhibit = null;
		}
	}

	private void tiltControlle () {

		//float inputHorizontal = -Input.GetAxis("Horizontal");

		// acceleration input - normaly this should be the z-axis...
		// the forced landscape mode seems to ignore coordinate system adaption
		float inputHorizontal = -Input.acceleration.x;

		//Vector from exhibit to player
		Vector3 relPos = new Vector3(transform.position.x - currentExhibit.transform.position.x, 0, transform.position.z - currentExhibit.transform.position.z);
		relPos = relPos.normalized * currentExhibit.viewDistance;

		// turning angle
		float angle = inputHorizontal * Time.deltaTime * tiltSpeed;

		// get new player position
		Vector3 targetPos = Quaternion.AngleAxis(angle, Vector3.up) * relPos;
		targetPos = currentExhibit.transform.position + targetPos;
		targetPos.y = transform.position.y;

		transform.position = targetPos;


	}


}
