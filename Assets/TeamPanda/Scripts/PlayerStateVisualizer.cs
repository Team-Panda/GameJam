using UnityEngine;
using System.Collections;

public class PlayerStateVisualizer : MonoBehaviour {

	public float StartScale = 0.8f;
	public float ScaleIncrease = 0.2f;

	private Vector3 startScale;
	private Vector3 scaleIncrease;

	// Use this for initialization
	void Start () {
		startScale = new Vector3 (StartScale, StartScale, StartScale);
		scaleIncrease = new Vector3 (ScaleIncrease, ScaleIncrease, ScaleIncrease);
		// set start scale
		transform.localScale = startScale;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setLevelUp(int currentLevel) {
		// TODO level up animation?


		transform.localScale = startScale + scaleIncrease * currentLevel;
	}

}
