using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CursorSpinning : MonoBehaviour {

	private Color frontColor;
	private Color selectionColor;
	private Color spinnerColor;
	private Image front;
	private Image spinner;

	// Use this for initialization
	void Awake () {
		front = transform.FindChild ("Front").GetComponent<Image> ();
		spinner = transform.FindChild ("Spinner").GetComponent<Image> ();
	}


	public void init(Color _frontColor, Color _selectionColor, Color _spinnerColor) {
		frontColor = _frontColor;
		selectionColor = _selectionColor;
		spinnerColor = _spinnerColor;

		front.color = frontColor;
		spinner.color = spinnerColor;

		Debug.Log (frontColor+" "+ spinnerColor);
		setProgress (0f);
	}

	public void setSelect(bool active) {
		if (active) {
			front.color = selectionColor;
		} else {
			front.color = frontColor;
		}
	}

	public void setProgress(float p) {
		spinner.fillAmount = p;
	}
}
