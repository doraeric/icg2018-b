using UnityEngine;

public class Trolley : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.W)){
			transform.Translate(Vector3.forward * Time.deltaTime);
		}
		if(Input.GetKey(KeyCode.S)){
			transform.Translate(Vector3.back * Time.deltaTime);
		}
	}
}
