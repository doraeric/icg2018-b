using UnityEngine;

public class UIRootHandler : MonoBehaviour {
	void Awake () {
		UIManager.Instance.CanvasRoot = gameObject;
	}
}