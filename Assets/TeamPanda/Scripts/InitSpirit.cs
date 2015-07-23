using UnityEngine;
using System.Collections;

//Grenzen in x-,y- und z-Achse setzen - sollen nicht direkt im Inspector 
//angezeigt werden, da keine Variablen die ständig geändert werden müssen
[System.Serializable]
public class RandomWerte {

	public float xMin, xMax, yMin, yMax, zMin, zMax;

}

public class InitSpirit : MonoBehaviour {

	public float speed; 				//Geschwindigkeit anpassen
	public RandomWerte b; 					// auf die Variablen der Klasse Boundary zugreifen
	public GameObject SpiritObject;		// auf GameObjekte aus dem Prefab-Ordner zugreifen
	private GameObject [] spiritsArray;	// SpiritArray

	void Start()
	{
		InvokeRepeating("CreateObject", 1.0f, 1.0f);
	}

	void CreateObject () {

		//Spirits erzeugen 
		spiritsArray = new GameObject[1];
		for (int i = 0; i < spiritsArray.Length; i++) {

			GameObject clone = (GameObject)Instantiate(SpiritObject, transform.position + new Vector3 (Random.value, Random.value, Random.value), Quaternion.identity);

			//Debug.Log("Create");

			Vector3 moving = new Vector3 (Random.Range(-b.xMin,b.xMax),Random.Range(-b.yMin,b.yMax),Random.Range(-b.zMin,b.zMax));
				
				Rigidbody rb = clone.GetComponent <Rigidbody>();
				
			//rb.AddForce (new Vector3 (Random.Range(-b.xMin,b.xMax),Random.Range(-b.yMin,b.yMax),Random.Range(-b.zMin,b.zMax)));
					
			rb.velocity = moving * speed;
				//Debug.Log (rb.angularVelocity);


			spiritsArray [i]= clone;

			//Debug.Log(transform.position);
		


	
	}

	}

}
