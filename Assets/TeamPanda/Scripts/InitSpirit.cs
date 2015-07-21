using UnityEngine;
using System.Collections;

//Grenzen in x-,y- und z-Achse setzen - sollen nicht direkt im Inspector 
//angezeigt werden, da keine Variablen die ständig geändert werden müssen
[System.Serializable]
public class Boundary {

	public float xMin, xMax, yMin, yMax, zMin, zMax;

}

public class InitSpirit : MonoBehaviour {

	public float speed; 			//Geschwindigkeit anpassen
	public float turn;  			//Neigung der Rotation anpassen
	public Boundary b; 				// auf die Variablen der Klasse Boundary zugreifen
	public GameObject SpiritObject;		// auf GameObjekte aus dem Prefab-Ordner zugreifen
	public GameObject [] spiritsArray;	

	void Start () {

		//Spirits erzeugen 
		spiritsArray = new GameObject[2];
		for (int i = 0; i < spiritsArray.Length; i++) {

			GameObject clone = (GameObject)Instantiate(SpiritObject, new Vector3(Random.value,Random.value,Random.value), Quaternion.identity);
			spiritsArray [i]= clone;
		
		}
	}


	void fixedUpdate (){
 


		Vector3 moving = new Vector3 (Random.value, Random.value, Random.value);

		foreach (GameObject obj in  spiritsArray){

		Rigidbody rb = obj.GetComponent <Rigidbody>();
			
		rb.velocity = moving * speed;

		rb.position = new Vector3
			(
				Mathf.Clamp (rb.position.x, b.xMin, b.xMax),
				Mathf.Clamp (rb.position.y, b.yMin, b.yMax),
				Mathf.Clamp (rb.position.z, b.zMin, b.zMax)
			);

		rb.angularVelocity = Random.insideUnitSphere * turn;

	}

}
}