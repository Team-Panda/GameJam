using UnityEngine;
using System.Collections;

public class SpiritCollisionController : MonoBehaviour 
{
	private SpiritStateController spiritState;

	void Start ()
	{
	
		spiritState = GetComponent <SpiritStateController> ();
	
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
			Destroy (this.gameObject);
		}

	}
}