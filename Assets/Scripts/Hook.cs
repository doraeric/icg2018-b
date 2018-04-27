using UnityEngine;

[RequireComponent(typeof(ConfigurableJoint))]
[RequireComponent(typeof(Rigidbody))]

public class Hook : MonoBehaviour {
	[SerializeField]LineRenderer rope;
	[SerializeField]float ropeLen = 15.5f;

	ConfigurableJoint joint2trolley;
	Joint joint2obj;
	Rigidbody rb;
	RaycastHit hit;
	GameObject aimTarget;
	GameObject colliderObj;

	// Use this for initialization
	void Start () {
		joint2trolley = GetComponent<ConfigurableJoint>();
		rb = GetComponent<Rigidbody>();
		if (rope == null) {
			rope = gameObject.AddComponent<LineRenderer>();
		}
	}

	// Update is called once per frame
	void Update () {
		// Rope
		rope.SetPosition(0, joint2trolley.connectedBody.transform.position + joint2trolley.connectedAnchor);
		rope.SetPosition(1, transform.position);

		// Move up and down
		if(Input.GetKey("left shift")){
			if(joint2trolley.anchor.y < ropeLen) {
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

		// Raycast
		if (Physics.Raycast(joint2trolley.connectedBody.position, Vector3.down, out hit, ropeLen)) {
			if (hit.collider.GetComponent<Pickable>()) {
				aimTarget = hit.collider.gameObject;
				aimTarget.GetComponent<Renderer>().material.color = Color.yellow;
			} else if (aimTarget) {
				aimTarget.GetComponent<Renderer>().material.color = Color.white;
				aimTarget = null;
			}
		}
		else if (aimTarget) {
			aimTarget.GetComponent<Renderer>().material.color = Color.white;
			aimTarget = null;
		}

		// Press space to connect or disconnect the cube with a ConfigurableJoint
		if (Input.GetKeyDown(KeyCode.E)) {
			if (!joint2obj && colliderObj) {
				joint2obj = gameObject.AddComponent<HingeJoint>();
				joint2obj.connectedBody = colliderObj.GetComponent<Rigidbody>();
				if (joint2obj.connectedBody == null)
					Destroy(joint2obj);
				Debug.Log(joint2obj.connectedBody);
			}
			else if (joint2obj) {
				Destroy(joint2obj);
			}
		}
	}

	// Collide
	void OnTriggerEnter (Collider other) {
		if (aimTarget != null && aimTarget == other.gameObject) {
			colliderObj = aimTarget;
		}
	}
	void OnTriggerExit  (Collider other) {
		if (colliderObj)
			colliderObj = null;
	}
}
