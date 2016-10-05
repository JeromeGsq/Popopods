using UnityEngine;
using System.Collections;

public class ClampPosition : MonoBehaviour {

	public float maxVelocity;
	public Vector3 magnitude;
	private Rigidbody rigidbody;

	void Start() {
		rigidbody = GetComponent<Rigidbody>();
	}

	void FixedUpdate() {
		rigidbody.velocity = Vector3.ClampMagnitude(rigidbody.velocity, maxVelocity);
		magnitude = rigidbody.velocity;
	}
}
