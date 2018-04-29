using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintHandler : MonoBehaviour {
	Text displayText;
	void Start() {
		displayText = GetComponent<Text>();
	}
	//
	// Update is called once per frame
	void Update () {
		displayText.text = GameManager.Instance.hintMsg;
	}
}
