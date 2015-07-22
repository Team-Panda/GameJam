using UnityEngine;
using System.Collections;

public class PlayerStateController : MonoBehaviour {

	public int Level = 0;
	public float StartSpeed = 80f;
	public int StartHealth;
	public int CollectionHealthIncrease;
	public int IdleHealthDecrease;
	public int CollisionHealthDecrease;

	public float TimerIdleHealthDecrease;
	private float TimerIdleHealthDecreaseCount;



	private int collectionPoints = 0;
	private float speed;
	private PlayerCamController playerCam;
	private int health;


	// Use this for initialization
	void Start () {
		playerCam = GameObject.FindWithTag ("PlayerCam").GetComponent<PlayerCamController>();

		health = StartHealth;
		SetSpeed (StartSpeed);
		TimerIdleHealthDecreaseCount = 0;
	}
	
	// Update is called once per frame
	void Update () {

		TimerIdleHealthDecreaseCount += Time.deltaTime;

		// decrease health in intervals
		if (TimerIdleHealthDecreaseCount > TimerIdleHealthDecrease) {
			DecreaseHealth(IdleHealthDecrease);
			TimerIdleHealthDecreaseCount = 0;
		}

		// TODO degreas live value in smallll amounts --> prevent endless "doing nothing"
	}

	void SetSpeed(float newSpeed) {
		speed = newSpeed;
		playerCam.MaxSpeed = speed;
	}

	void DecreaseHealth(int amount) {
		health -= amount;
		Debug.Log ("healt down! "+health);

		// TODO check if dead!!
		if (health <= 0) {
			Debug.Log ("DEAAAAD");
		}
	}

	void IncreaseHealth(int amount) {

		if (health + amount <= StartHealth) {
			health += amount;
		} else {
			health = StartHealth;
		}

		Debug.Log ("healt up! "+health);	
	}

	void CollectSpirit(SpiritStateController spiritState) {

		// reset idle health decrease timer
		TimerIdleHealthDecreaseCount = 0;

		// increase my live value
		IncreaseHealth (CollectionHealthIncrease);

		// add the collections points
		collectionPoints += spiritState.CollectionsPoints;

		Debug.Log ("Spirit collected!! Points: "+collectionPoints+ " ||| needed next: "+GameRules.LevelConditions [Level + 1]);

		// TODO test if i can leven up
		if (collectionPoints >= GameRules.LevelConditions [Level + 1]) {
			LevelUp();
		}

		// trigger Spirit destruction
		spiritState.GetCollected ();
	}

	void LevelUp() {
		Level += 1;

		// TODO chenge visuals of character - to represent level
		// TODO level up animation?

		// TODO Test if max level is reached!

		Debug.Log ("Level UP! " + Level);
	}

	public void TakeDamage() {
		// degrease live value by certain amount
		DecreaseHealth(CollisionHealthDecrease);

		// TODO damage animation
		Debug.Log ("DAMAAAAAGE");
	}


	public void CollideWithSpirit(GameObject spirit) {

		SpiritStateController spiritState = spirit.GetComponent<SpiritStateController>();

		// check if i can collect the Spirit (by LEVEL)
		if (spiritState.Level <= Level) {
			CollectSpirit (spiritState);
		// i cant, so take collision damge (to large Spirit)
		} else {
			TakeDamage();
		}

	}
}
