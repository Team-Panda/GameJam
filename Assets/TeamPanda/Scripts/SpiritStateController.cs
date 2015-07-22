using UnityEngine;
using System.Collections;

public class SpiritStateController : MonoBehaviour {

	public void collideWithSpirit (GameObject spirit){
		Debug.Log ("colliding with spirit");
	}

	public int Level = 0;
	public int CollectionsPoints { get { return collectionPoints; } }

	private int collectionPoints;



	// Use this for initialization
	void Start () {
		collectionPoints = GameRules.LevelConditions [Level];
	}
	
	// Update is called once per frame
	void Update () {
	}





}

