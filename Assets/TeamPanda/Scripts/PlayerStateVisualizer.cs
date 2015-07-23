using UnityEngine;
using System.Collections;

public class PlayerStateVisualizer : MonoBehaviour {

	public float StartScale = 0.8f;
	public float ScaleIncrease = 0.2f;

	private Vector3 startScale;
	private Vector3 scaleIncrease;

	private SkinnedMeshRenderer rend;
	private GameObject model;

	// Use this for initialization
	void Start () {
		startScale = new Vector3 (StartScale, StartScale, StartScale);
		scaleIncrease = new Vector3 (ScaleIncrease, ScaleIncrease, ScaleIncrease);

		model = GameObject.FindWithTag ("PlayerModel");
		rend = model.GetComponent<SkinnedMeshRenderer> ();
		//Debug.Log (GameRules.LevelColors [0] +" ..... "+Color.red);
		setColor(GameRules.LevelColors [0]);

		// set start scale
		transform.localScale = startScale;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void setColor(Color col) {
		rend.material.color = col;
	}

	public void setLevelUp(int currentLevel) {
		// TODO level up animation?

	
		// set color according to level
		Color newColor = GameRules.LevelColors [currentLevel];
		setColor(newColor);

		transform.localScale = startScale + scaleIncrease * currentLevel;
	}

}
