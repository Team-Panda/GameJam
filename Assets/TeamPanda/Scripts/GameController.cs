using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public GameObject [] spiritPrefabs;

	private bool isGameOver = false;
	private float gameOverTimer = 3f;
	private float gameOverTimerCount = 0f;

	private GameObject gameOverCanvas;

	// Use this for initialization
	void Start () {
		// TODO initialize stuff
		gameOverCanvas = GameObject.FindWithTag ("GameOverScreen");
		gameOverCanvas.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {

		if (isGameOver) {
			gameOverTimerCount += Time.deltaTime;

			if(gameOverTimerCount > gameOverTimer) {
				Application.LoadLevel (0);  
			}
		}
	
	}

	public void FuseSpirits(int level, Vector3 position) {
		// TODO get level of both spirits, get collision position, create one next level spirit at collision position


		Instantiate(spiritPrefabs [level + 1], position, Quaternion.identity);
		//Debug.Log ("In Level: " + level + "an Position: " + position);
	}

	public void GameOver() {

		isGameOver = true;
		gameOverCanvas.SetActive (true);

	}
}
