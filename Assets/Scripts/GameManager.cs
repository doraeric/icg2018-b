using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager {
	public string hintMsg;

	private GameObject _gameObject;
	private static GameManager _Instance;

	public static GameManager Instance {
		get {
			if (_Instance == null) {
				_Instance = new GameManager();
				_Instance._gameObject = new GameObject("GameManager");
			}
			return _Instance;
		}
	}
}
