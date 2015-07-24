using UnityEngine;
using System.Collections;

public class SpiritStateController : MonoBehaviour {

	public int Level = 0;
	public int CollectionsPoints { get { return collectionPoints; } }
	
	private int collectionPoints;

	public bool canCallFusion = true;

	private GameController GC;

	public void collideWithSpirit (GameObject spirit, ContactPoint contact){

		SpiritStateController otherSpiritState = spirit.GetComponent <SpiritStateController> ();

		// es wird ausgeschlossen, dass beide Spirits einen neuen Spirit erzeugen
		if (canCallFusion)
		{
			//nur wenn sie den gleichen Level haben, darf ein neuer Spirit entstehen
			if (Level != spirit.GetComponent<SpiritStateController>().Level){
				//Debug.Log("LEVEL");
				return;
			}

			if (Level >= GameRules.MaxLevel) {			
				return;			
			}

			otherSpiritState.canCallFusion = false ;
			//Debug.Log("TEST");

			// ein Spirit wird zerstört
			spirit.GetComponent<SpiritStateController>().destroy();

			GC.FuseSpirits(Level, contact.point);

			destroy();

		}
		
		//Debug.Log ("colliding with spirit");
	}

	// Use this for initialization
	void Start () {

		collectionPoints = GameRules.LevelConditions [Level];
		GC = GameObject.FindWithTag ("GameController").GetComponent<GameController>();
	}
	
	// Update is called once per frame
	void Update () {
	}
	// gets called if the player collects (eats) this spirit
	public void GetCollected() {
		// TODO play collections animation??
		destroy ();
	}

	public void destroy() {
		GC.decSpiritCount ();
		Destroy (this.gameObject);
	}
}

