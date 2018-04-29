using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OKbtnHandler : MonoBehaviour {
	void Start() {
		Button btn = GetComponent<Button>();
		btn.onClick.AddListener(OnClick);
	}
	void OnClick() {
		UIManager.Instance.ClosePanel("HelpPanel");
	}
}
