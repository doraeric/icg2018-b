using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIListener : MonoBehaviour {

	void Start () {
		UIManager.Instance.ShowPanel("HintPanel");
		UIManager.Instance.ShowPanel("HelpPanel");
	}

	void Update () {
	}
}
