using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager {

	public GameObject CanvasRoot;

	private string UI_GAMEPANEL_ROOT = "Prefabs/GamePanel/";
	private static UIManager _instance;
	public bool autoCursorVisibility = false;

	public static UIManager Instance {
		get {
			if (_instance == null) {
				_instance = new UIManager();
			}
			return _instance;
		}
	}

	public Dictionary<string, GameObject> m_PanelList = new Dictionary<string, GameObject>();

	public bool IsClear() {
		if (IsPaneVisible("PausePanel") || IsPaneVisible("WeaponWheel"))
			return false;
		return true;
	}

	private bool CheckCanvasRootIsNull() {
		if (CanvasRoot == null) {
			Debug.LogError("CanvasRoot is Null, Please in your Canvas add UIRootHandler.cs");
			return true;
		}
		else {
			return false;
		}
	}

	public bool IsPanelLive(string name) {
		return m_PanelList.ContainsKey(name);
	}

	public bool IsPaneVisible(string name) {
		return m_PanelList[name].activeSelf;
	}

	public GameObject ShowPanel(string name) {
		if (CheckCanvasRootIsNull())
			return null;

		if (IsPanelLive(name)) {
			Debug.LogErrorFormat("[{0}] is Showing, if you want to show, please close first!!", name);
			return null;
		}

		GameObject loadGo = Resources.Load<GameObject>(UI_GAMEPANEL_ROOT + name);
		if (loadGo == null)
			return null;

		GameObject panel = InstantiateGameObject(CanvasRoot, loadGo);
		panel.name = name;

		m_PanelList.Add(name, panel);
		if (autoCursorVisibility)
			showCursor(true);

		return panel;
	}

	public void TogglePanel(string name, bool isOn) {
		if (IsPanelLive(name)) {
			if (m_PanelList[name] != null) {
				m_PanelList[name].SetActive(isOn);
				if (autoCursorVisibility) {
					if (IsClear()) {
						showCursor(false);
					} else {
						showCursor(true);
					}
				}
			}
		} else {
			Debug.LogErrorFormat("TogglePanel [{0}] not found.", name);
		}
	}

	public void ClosePanel(string name) {
		if (IsPanelLive(name)) {
			if (m_PanelList[name] != null)
				Object.Destroy(m_PanelList[name]);

			m_PanelList.Remove(name);
			if (autoCursorVisibility)
				showCursor(false);
		} else {
			Debug.LogErrorFormat("ClosePanel [{0}] not found.", name);
		}
	}

	public void CloseAllPanel() {
		foreach (KeyValuePair<string, GameObject> item in m_PanelList) {
			if (item.Value != null)
				Object.Destroy(item.Value);
		}

		m_PanelList.Clear();
	}

	public Vector2 GetCanvasSize() {
		if (CheckCanvasRootIsNull())
			return Vector2.one * -1;

		RectTransform trans = CanvasRoot.transform as RectTransform;

		return trans.sizeDelta;
	}

	GameObject InstantiateGameObject(GameObject parent, GameObject prefab) {

		GameObject go = GameObject.Instantiate(prefab) as GameObject;

		if (go != null && parent != null) {
			Transform t = go.transform;
			t.SetParent(parent.transform);
			t.localPosition = Vector3.zero;
			t.localRotation = Quaternion.identity;
			t.localScale = Vector3.one;

			RectTransform rect = go.transform as RectTransform;
			if (rect != null) {
				rect.anchoredPosition = Vector3.zero;
				rect.localRotation = Quaternion.identity;
				rect.localScale = Vector3.one;

				//判斷anchor是否在同一點
				if (rect.anchorMin.x != rect.anchorMax.x && rect.anchorMin.y != rect.anchorMax.y) {
					rect.offsetMin = Vector2.zero;
					rect.offsetMax = Vector2.zero;
				}
			}

			go.layer = parent.layer;
		}
		return go;
	}

	void showCursor(bool show) {
		if (show) {
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		} else {
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}
	}
}
