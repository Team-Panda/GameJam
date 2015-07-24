using UnityEngine;
using System.Collections;

public class SpiritCollisionController : MonoBehaviour 
{
	private SpiritStateController spiritState;
	private Rigidbody rb;

	void Start ()
	{
	
		spiritState = GetComponent <SpiritStateController> ();
		rb = GetComponent<Rigidbody> ();
	
	}

	void OnCollisionEnter(Collision other) 
	{

		// stoße ich mit einem Spirit zusammen?
		if (other.gameObject.GetComponent<SpiritStateController> ()) 
		{	
			//Debug.Log("Colliding");
			spiritState.collideWithSpirit(other.gameObject,other.contacts[0]);

		}
	}

	void OnTriggerExit(Collider other) {

		if (other.gameObject.tag == "SpiritBoundingBox") {
			spiritState.destroy();
		}

	}

	public void DriftTo(GameObject target) {

		Vector3 targetPos = target.transform.position;
		Vector3 targetDir = transform.position + targetPos * 0.02f;
		Debug.Log (targetDir);
		rb.AddForce (targetDir);

	}
}