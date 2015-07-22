using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject [] spiritPrefabs;

	// Use this for initialization
	void Start () {
		// TODO initialize stuff
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void FuseSpirits(int level, Vector3 position) {
		// TODO get level of both spirits, get collision position, create one next level spirit at collision position


		Instantiate(spiritPrefabs [level + 1], position, Quaternion.identity);
		//Debug.Log ("In Level: " + level + "an Position: " + position);
	}
}
