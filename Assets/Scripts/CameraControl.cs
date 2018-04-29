using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {
	// Drag your target (tower crane) to this varable in authoring GUI
	public Transform target;

	Vector3 originalPosition;

	Vector3 Position_5;
	Vector3 Position_4;
	Vector3 Position_6;
	Vector3 Position_8;

	string Projection_Mode_String;
	Rect Projection_Mode_Rect;

	public Camera mainCam;
	public Camera driverCam;
	bool isMain = true;

	// Use this for initialization
	void Start () {
		originalPosition = Camera.main.transform.position;
		Camera.main.transform.LookAt(target);
		Projection_Mode_Rect = new Rect (10, 10, 100, 50);

		// Top View
		Position_8 = new Vector3 (0, 20, 0) + target.position;
		// Front View
		Position_5 = new Vector3 (0, 0, 10) + target.position;
		// left View
		Position_4 = new Vector3 (10, 0, 0) + target.position;
		// right View
		Position_6 = new Vector3 (-10, 0, 0) + target.position;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.H) && !UIManager.Instance.IsPanelLive("HelpPanel")) {
			UIManager.Instance.ShowPanel("HelpPanel");
		}
		if (Camera.main.orthographic) {
			Projection_Mode_String = "Orthographic";
		}
		else {
			Projection_Mode_String = "Perspective";
		}

		if (Input.GetKeyDown("1")) {
			if (Camera.main.orthographic) {
				Camera.main.orthographic = false;
			} else {
				Camera.main.orthographic = true;
				Camera.main.orthographicSize = 10;
			}
		}

		if (Input.GetKey("0") && isMain) {
			Camera.main.orthographic = false;
			Camera.main.transform.position = originalPosition;
			Camera.main.transform.LookAt(target);
		}

		// Top
		if (Input.GetKey("8") && isMain) {
			Camera.main.orthographic = true;
			Camera.main.orthographicSize = 18;
			Camera.main.transform.position = Position_8;
			Camera.main.transform.LookAt(target, Vector3.forward);
		}

		// Front
		if (Input.GetKey("5") && isMain) {
			Camera.main.orthographic = true;
			Camera.main.orthographicSize = 14;
			Camera.main.transform.position = Position_5;
			Camera.main.transform.LookAt(target);
		}

		if (Input.GetKey("4") && isMain) {
			Camera.main.orthographic = true;
			Camera.main.orthographicSize = 14;
			Camera.main.transform.position = Position_4;
			Camera.main.transform.LookAt(target);
		}

		if (Input.GetKey("6") && isMain) {
			Camera.main.orthographic = true;
			Camera.main.orthographicSize = 14;
			Camera.main.transform.position = Position_6;
			Camera.main.transform.LookAt(target);
		}

		if (Input.GetKey("v")) {
			mainCam.enabled=!isMain;
			driverCam.enabled=isMain;
			originalPosition = Camera.main.transform.position;
			isMain=!isMain;
		}

		// Translate Camera by arrow
		// Camera move forward
		if (Input.GetKey(KeyCode.UpArrow) && isMain) {
			Camera.main.transform.position += Camera.main.transform.forward * Time.deltaTime * 5;
		}
		// Camera move backward
		if (Input.GetKey(KeyCode.DownArrow) && isMain) {
			Camera.main.transform.position -= Camera.main.transform.forward * Time.deltaTime * 5;
		}
		// Camera move right
		if (Input.GetKey(KeyCode.RightArrow) && isMain) {
			Camera.main.transform.position += Camera.main.transform.right * Time.deltaTime * 5;
		}
		// Camera move left
		if (Input.GetKey(KeyCode.LeftArrow) && isMain) {
			Camera.main.transform.position -= Camera.main.transform.right * Time.deltaTime * 5;
		}
		// Camera move up
		if (Input.GetKey("'") && isMain) {
			Camera.main.transform.position += Camera.main.transform.up * Time.deltaTime * 5;
		}
		// Camera move down
		if (Input.GetKey("/") && isMain) {
			Camera.main.transform.position -= Camera.main.transform.up * Time.deltaTime * 5;
		}

		// Click mouse left button and drag to look around
		if (Input.GetKey(KeyCode.Mouse1)) {
			//Rotate horizontally by the X direction of mouse movement
			Camera.main.transform.RotateAround(Camera.main.transform.position, Vector3.up,
												Input.GetAxis ("Mouse X") * 100f *Time.deltaTime);

			//Rotate vertically by the Y direction of mouse movement
			Camera.main.transform.Rotate (-Input.GetAxis ("Mouse Y") * 100f * Time.deltaTime, 0, 0);
		}

		// Scroll mouse midde wheel to move forward and back
		if (Input.GetAxis ("Mouse ScrollWheel") != 0 && isMain) {
			Camera.main.transform.position += Input.GetAxis ("Mouse ScrollWheel") *　
												Camera.main.transform.forward * 100f　* Time.deltaTime;
		}
	}

	void OnGUI () {
		GUI.Label (Projection_Mode_Rect, Projection_Mode_String);
	}
}
