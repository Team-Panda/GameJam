using UnityEngine;
using System.Collections;

public class SpiritCollisionController : MonoBehaviour 
{
	private SpiritStateController spiritState;

	void Start ()
	{
	
		spiritState = GetComponent <SpiritStateController> ();
	
	}

	void OnTriggerEnter(Collider other) 
	{
		
		// stoße ich mit einem Spirit zusammen
		if (other.gameObject.GetComponent<SpiritStateController> ()) 
		{
		
			spiritState.collideWithSpirit(other.gameObject);

		}
	}
}