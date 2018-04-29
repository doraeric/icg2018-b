using UnityEngine;

public class Jib : MonoBehaviour {

	public Animator cameraSwitcher;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.A)){
			cameraSwitcher.Play("jib_turnRightLeft");
			transform.Rotate(Vector3.down * Time.deltaTime * 10);
		}
		if(Input.GetKey(KeyCode.D)){
			cameraSwitcher.Play("jib_turnRightLeft");
			transform.Rotate(Vector3.up * Time.deltaTime * 10);
		}

		if (Input.GetKeyUp("a") || Input.GetKeyUp("d")) {
			cameraSwitcher.Play("missionless");
		}

	}
}
