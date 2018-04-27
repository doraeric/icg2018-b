using UnityEngine;

[RequireComponent(typeof(ConfigurableJoint))]
[RequireComponent(typeof(Rigidbody))]

public class Hook : MonoBehaviour {
	ConfigurableJoint joint2trolley;
	Rigidbody rb;

	// Use this for initialization
	void Start () {
		joint2trolley = GetComponent<ConfigurableJoint>();
		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKey("left shift")){
			if(joint2trolley.anchor.y < 16f) {
				joint2trolley.anchor += Vector3.up * Time.deltaTime;
				rb.WakeUp();
			}
		}
		if(Input.GetKey("space")){
			if(joint2trolley.anchor.y > .7f) {
				joint2trolley.anchor -= Vector3.up * Time.deltaTime;
				rb.WakeUp();
			}
		}
	}
}
