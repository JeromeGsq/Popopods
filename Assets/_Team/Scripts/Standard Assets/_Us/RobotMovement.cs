using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RobotMovement : MonoBehaviour {

    public Rigidbody[] podsRigidbody = new Rigidbody[4];
    public float intensityY;
    public float intensityXZ;

    private Rigidbody rigidBody;
    private Vector2 direction;
    private Vector3 translateX;
    private Vector3 translateZ;

    [Space(20)]

    private List<int> listButtonPressed;

    void Awake() {
        rigidBody = GetComponent<Rigidbody>();
        listButtonPressed = new List<int>();
    }

    void Update() {
        float joyX = Input.GetAxis("Joystick Axis X");
        float joyZ = Input.GetAxis("Joystick Axis Z");
        joyX = (Mathf.Abs(joyX) > 0.2) ? joyX : 0;
        joyZ = (Mathf.Abs(joyZ) > 0.2) ? joyZ : 0;

        translateX = Vector3.zero;
        translateZ = Vector3.zero;


        if(joyX != 0) {
            translateX = ((joyX > 0) ? transform.right : -transform.right) * intensityXZ;
        }
        if(joyZ != 0) {
            translateZ = ((joyZ > 0) ? -transform.forward : transform.forward) * intensityXZ;
        }
        listButtonPressed.Clear();

        if(Input.GetButton("LB")) {
            listButtonPressed.Add(0);
        }
        if(Input.GetButton("RB")) {
            listButtonPressed.Add(1);
        }
        if(Input.GetAxis("RT") > 0.9f) {
            listButtonPressed.Add(2);
        }
        if(Input.GetAxis("LT") > 0.9f) {
            listButtonPressed.Add(3);
        }
    }

    void FixedUpdate() {
        foreach(int i in listButtonPressed) {
            podsRigidbody[i].AddForce(0, intensityY, 0);
            podsRigidbody[i].AddForce(translateX);
            podsRigidbody[i].AddForce(translateZ);
        }
      rigidBody.AddForce(0, -intensityY * listButtonPressed.Count , 0);
    }
}
