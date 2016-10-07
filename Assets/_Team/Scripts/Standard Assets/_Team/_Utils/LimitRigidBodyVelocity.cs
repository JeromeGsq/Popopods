using UnityEngine;
using System.Collections;

public class LimitRigidBodyVelocity : MonoBehaviour {

    private Rigidbody rbody;
    private Vector3 magnitude;
    public float MaxVelocity;

	void Start() {
        rbody = GetComponent<Rigidbody>();
	}

	void FixedUpdate() {
        rbody.velocity = Vector3.ClampMagnitude(rbody.velocity, MaxVelocity);
		magnitude = rbody.velocity;
	}
}
