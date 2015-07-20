using UnityEngine;
using System.Collections;

public class MusSelectionController : MonoBehaviour {

	private MusPlayer player;

	void Awake () {
		player = GameObject.FindWithTag("Player").GetComponent<MusPlayer>();
	}

	public void ObjectSelected (MusSelectableObject so) {

		// check if an exhibit was selected
		MusExhibit exh = so.GetComponent<MusExhibit>();

		if (exh) {
			// tell player to attach to this exhibit
			player.walkToExhibit(exh);
		}

	}
}
