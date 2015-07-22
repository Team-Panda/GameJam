using UnityEngine;
using System.Collections;

public class PlayerStateController : MonoBehaviour {

	public float StartSpeed = 80f;
	public int Health;
	public int CollectionHealthIncrease;
	public int IdleHealthDegrease;
	public int CollisionHealthDegrease;


	private int level = 0;
	private int collectionPoints = 0;

	private float speed;


	// Use this for initialization
	void Start () {

		setSpeed (StartSpeed);

	}
	
	// Update is called once per frame
	void Update () {
//		Debug.Log (GameRules.LevelConditions[2]);
//		Debug.Log (speed);

		// TODO degreas live value in smallll amounts --> prevent endless "doing nothing"
	}

	void setSpeed(float newSpeed) {
		speed = newSpeed;

		// TODO set speed for cam
	}

	void collectSpirit() {
		// TODO increase my live value
		// TODO add the collections points --> test if i can level up
	}

	void takeDamage() {
		// TODO degrease live value about certain amount
	}

	public void collideWithSpirit(GameObject spirit) {
		SpiritStateController spiritState = spirit.GetComponent<SpiritStateController>();

		// TODO, check if i can collect it (am i at the correct level?

		collectionPoints += spiritState.CollectionsPoints;

		Debug.Log ("Player now has " +collectionPoints +" Collection Points");
	}
}
