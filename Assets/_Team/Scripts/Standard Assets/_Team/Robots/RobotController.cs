﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Rewired;

public class RobotController : MonoBehaviour {

    // Rewired input
    public int RewiredPlayerId = 1;
    private Player player;

    [Space(20)]

    // Rigidbodies pods movement
    public Rigidbody[] podsRigidbody = new Rigidbody[4];
    public float intensityY;
    public float intensityXZ;

    [Space(20)]

    // Body movement
    private Rigidbody rigidBody;
    private Vector2 direction;
    private Vector3 translateX;
    private Vector3 translateZ;

    [Space(20)]

    // Input
    private List<int> listButtonPressed;

    [Space(20)]

    // Life value
    public float Life;

    // Life text
    public TextMesh LifeText;

    [Space(20)]

    // OnDie instantiate this prefab
    public GameObject OnDie_ExplosionPrefab;



    void Awake() {
        // Get Rewired input
        player = ReInput.players.GetPlayer(RewiredPlayerId);

        // Get RigidBody
        rigidBody = GetComponent<Rigidbody>();

        // Instantiate list of inputs 
        listButtonPressed = new List<int>();

        if(LifeText != null) {
            LifeText.text = Life + "";
        } else {
            LifeText = new TextMesh();
        }
    }


    void Update() {
        Move();
    }

    void FixedUpdate() {
        MoveFixed();
    }


    void OnTriggerEnter(Collider coll) {
        if(coll.CompareTag("Bullet")) {
            OnHittedEvent(coll);
        }
    }


    #region Life Events
    void OnHittedEvent(Collider coll) {
        // Remove amount of life
        Life -= coll.GetComponent<BulletFire>().Damage;
        LifeText.text = Life.ToString();

        // Check if life < 0 then Die;
        if(Life <= 0) {
            OnDie();
        }
    }

    void OnDie() {
        if(OnDie_ExplosionPrefab != null) {
            Instantiate(OnDie_ExplosionPrefab, transform.position, transform.rotation);
        }
        transform.root.gameObject.SetActive(false);
    }

    #endregion

    #region Move Pods : Update / FixedUpdate
    // Move pods
    void Move() {
        float joyX = player.GetAxis("Move X");
        float joyZ = player.GetAxis("Move Y");
        joyX = (Mathf.Abs(joyX) > 0.2) ? joyX : 0;
        joyZ = (Mathf.Abs(joyZ) > 0.2) ? joyZ : 0;

        translateX = Vector3.zero;
        translateZ = Vector3.zero;


        if(joyX != 0) {
            translateX = ((joyX > 0) ? transform.right : -transform.right) * intensityXZ;
        }
        if(joyZ != 0) {
            translateZ = ((joyZ > 0) ? transform.forward : -transform.forward) * intensityXZ;
        }

        listButtonPressed.Clear();

        if(player.GetButton("L1")) {
            listButtonPressed.Add(0);
        }
        if(player.GetButton("R1")) {
            listButtonPressed.Add(1);
        }
        if(player.GetButton("R2")) {
            listButtonPressed.Add(2);
        }
        if(player.GetButton("L2")) {
            listButtonPressed.Add(3);
        }
    }

    void MoveFixed() {
        foreach(int i in listButtonPressed) {
            podsRigidbody[i].AddForce(0, intensityY, 0);
            podsRigidbody[i].AddForce(translateX);
            podsRigidbody[i].AddForce(translateZ);
        }
        rigidBody.AddForce(0, -intensityY * listButtonPressed.Count, 0);


        foreach(Rigidbody g in podsRigidbody) {
            Debug.DrawLine(g.transform.position, transform.position, Color.red);
        }
    }
    #endregion

}
