using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MusCursor : MonoBehaviour {
		
	public static MusCursor instance;
		
	public float cursorDistance = 2f;
	public float cursorSize = 0.005f;
	public GameObject cursorPrefab;
	public Color cursorColor;
	public Color cursorSelectionColor;
	public Color cursorSpinnerColor;

	private GameObject cursor = null;
	//private Renderer cursorRenderer = null;
	private RectTransform cursorRect;
	private CursorSpinning cursorSpinner;

	private float selectionTimer = 0;
	private MusSelectableObject lastSelectedSo = null; // neue klasse!
	private int selectionMask;
	private float selectionRayLength = 500f;


	// private MusPlayer player;


	void Awake()
	{
		instance = this;
		selectionMask = LayerMask.GetMask("Selectable");

		if (!cursor) CreateCursor ();
	}
	
	// Attaches an icon to the cursor
	public void AttachIcon(GameObject prefab)
	{
		GameObject attachment = (GameObject)Instantiate (prefab);
		attachment.transform.parent = cursor.transform;
		attachment.transform.localPosition = Vector3.zero;
		attachment.transform.localRotation = Quaternion.identity;

		 
	}
	

	// Creates a cursor for the camera
	void CreateCursor()
	{
		cursor = (GameObject)Instantiate (cursorPrefab);//GameObject.CreatePrimitive(PrimitiveType.Sphere);
		cursor.name = "Cursor";
		cursor.transform.parent = transform;

		cursorRect = cursor.GetComponent<RectTransform> ();
		cursorRect.localScale = new Vector3(cursorSize, cursorSize, 0);
		cursorRect.localRotation = Quaternion.identity;
		cursorSpinner = cursor.GetComponent<CursorSpinning> ();

		cursorSpinner.init (cursorColor, cursorSelectionColor, cursorSpinnerColor);

		if (cursor.GetComponent<Collider>())
		{
			Destroy(cursor.GetComponent<Collider>());
		}

	}
	
	// Update is called once per frame
	void Update () {
		if (!cursor) CreateCursor();
		PositionCursor();
		CheckCollision();
	}
	
	
	// Positions the cursor in the center of the left and right camera
	void PositionCursor(){
		cursorRect.localPosition = new Vector3(0,0, cursorDistance);
	}
	

	
	void ShowCursor(bool value)
	{
		//cursor.GetComponent<Renderer>().enabled = value;
	}
	

	
	void CheckCollision()
	{
		ShowCursor (true);
		RaycastHit hitInfo;

		if (Physics.Raycast(transform.position, cursor.transform.position - transform.position, out hitInfo, selectionRayLength, selectionMask)){

			// check if a MusSelectableObject was hit
			MusSelectableObject so = hitInfo.collider.gameObject.GetComponent<MusSelectableObject>();

			if(so && so.IsSelectable) {

				cursorSpinner.setSelect(true);

				if(so == lastSelectedSo) {
					selectionTimer += Time.deltaTime;
					cursorSpinner.setProgress(selectionTimer/so.selectionTime);
				}

				// selection is made
				if(selectionTimer >= so.selectionTime) {
					so.SelectionEvent();
				}

				lastSelectedSo = so;

			} else {

				selectionTimer = 0;
				if(lastSelectedSo != null) lastSelectedSo = null;
				// TODO zeigen dass man nicht selektieren kann?
				cursorSpinner.setSelect(false);
				cursorSpinner.setProgress(0f);

			}

		} else {

			selectionTimer = 0;
			if(lastSelectedSo != null) lastSelectedSo = null;
			cursorSpinner.setSelect(false);
			cursorSpinner.setProgress(0f);

		}

	}
}
