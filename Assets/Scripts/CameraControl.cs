﻿using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {
	// Drag your target (tower crane) to this varable in authoring GUI
	public Transform target;

	Vector3 originalPosition;

	Vector3 Position_5;
	Vector3 Position_2;
	Vector3 Position_4;
	Vector3 Position_6;
	Vector3 Position_8;

	string Projection_Mode_String;
	Rect Projection_Mode_Rect;

	// Use this for initialization
	void Start () {
		originalPosition = Camera.main.transform.position;
		Camera.main.transform.LookAt(target);
		Projection_Mode_Rect = new Rect (10, 10, 100, 50);

		// Top View
		Position_5 = new Vector3 (0, 20, 0) + target.position;

		// Complete the Remaining Part
		// Front View
		Position_2 = new Vector3 (0, 0, -10) + target.position;
		// left View
		Position_4 = new Vector3 (-10, 0, 0) + target.position;
		// right View
		Position_6 = new Vector3 (10, 0, 0) + target.position;
		// back View
		Position_8 = new Vector3 (0, 0, 10) + target.position;
		UIManager.Instance.ShowPanel("HelpPanel");
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

		if (Input.GetKey(KeyCode.P)) {
			Camera.main.orthographic = false;
		}
		if (Input.GetKey(KeyCode.O)) {
			Camera.main.orthographic = true;
			Camera.main.orthographicSize = 10;
		}

		if (Input.GetKey("0")) {
			Camera.main.orthographic = false;
			Camera.main.transform.position = originalPosition;
			Camera.main.transform.LookAt(target);
		}

		if (Input.GetKey("5")) {
			Camera.main.orthographic = true;
			Camera.main.orthographicSize = 10;
			Camera.main.transform.position = Position_5;
			Camera.main.transform.LookAt(target, Vector3.forward);
		}

		// Complete the Remaining Part
		if (Input.GetKey("2")) {
			Camera.main.orthographic = true;
			Camera.main.orthographicSize = 10;
			Camera.main.transform.position = Position_2;
			Camera.main.transform.LookAt(target);
		}

		if (Input.GetKey("4")) {
			Camera.main.orthographic = true;
			Camera.main.orthographicSize = 10;
			Camera.main.transform.position = Position_4;
			Camera.main.transform.LookAt(target);
		}

		if (Input.GetKey("6")) {
			Camera.main.orthographic = true;
			Camera.main.orthographicSize = 10;
			Camera.main.transform.position = Position_6;
			Camera.main.transform.LookAt(target);
		}

		if (Input.GetKey("8")) {
			Camera.main.orthographic = true;
			Camera.main.orthographicSize = 10;
			Camera.main.transform.position = Position_8;
			Camera.main.transform.LookAt(target);
		}

		// Translate Camera by arrow
		// Camera move forward
		if (Input.GetKey(KeyCode.UpArrow)) {
			Camera.main.transform.position += Camera.main.transform.forward * Time.deltaTime * 5;
		}
		// Camera move backward
		if (Input.GetKey(KeyCode.DownArrow)) {
			Camera.main.transform.position -= Camera.main.transform.forward * Time.deltaTime * 5;
		}
		// Camera move right
		if (Input.GetKey(KeyCode.RightArrow)) {
			Camera.main.transform.position += Camera.main.transform.right * Time.deltaTime * 5;
		}
		// Camera move left
		if (Input.GetKey(KeyCode.LeftArrow)) {
			Camera.main.transform.position -= Camera.main.transform.right * Time.deltaTime * 5;
		}
		// Camera move up
		if (Input.GetKey("'")) {
			Camera.main.transform.position += Camera.main.transform.up * Time.deltaTime * 5;
		}
		// Camera move left
		if (Input.GetKey("/")) {
			Camera.main.transform.position -= Camera.main.transform.up * Time.deltaTime * 5;
		}

		// Click mouse left button and drag to look around
		if (Input.GetKey(KeyCode.Mouse1)) {
			//Rotate horizontally by the X direction of mouse movement
			Camera.main.transform.RotateAround(transform.position, Vector3.up,
												Input.GetAxis ("Mouse X") * 100f *Time.deltaTime);

			//Rotate vertically by the Y direction of mouse movement
			Camera.main.transform.Rotate (-Input.GetAxis ("Mouse Y") * 100f * Time.deltaTime, 0, 0);
		}

		// Scroll mouse midde wheel to move forward and back
		if (Input.GetAxis ("Mouse ScrollWheel") != 0) {
			Camera.main.transform.position += Input.GetAxis ("Mouse ScrollWheel") *　
												Camera.main.transform.forward * 100f　* Time.deltaTime;
		}
	}

	void OnGUI () {
		GUI.Label (Projection_Mode_Rect, Projection_Mode_String);
	}
}
