using UnityEngine;
using System.Collections;

public class MusSelectableObject : MonoBehaviour {

	public float selectionTime = 3f;

	private bool isSelectable = true;
	private MusSelectionController selectionController;

	public bool IsSelectable {
		get {
			return isSelectable;
		}
		set {
			isSelectable = value;
		}
	}

	void Awake() {
		selectionController = GameObject.FindWithTag("SelectionController").GetComponent<MusSelectionController>();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SelectionEvent() {
		isSelectable = false;

		// tell selection manager
		selectionController.ObjectSelected(this);

	}
}
