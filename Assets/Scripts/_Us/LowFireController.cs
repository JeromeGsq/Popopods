using UnityEngine;
using System.Collections;
using Rewired;

public class LowFireController : MonoBehaviour {

    public int playerId = 0;
    private Player player;

    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;

    public float CoolDown;
    private float coolDownValue;


    void Awake() {

        Debug.Log(transform.root.name.Replace("Machine ", ""));

        player = ReInput.players.GetPlayer(int.Parse(transform.root.name.Replace("Machine ", "")));
    }

    void Update() {

            Fire();



    }

    void Fire() {
        if(player.GetButtonDown("X") && coolDownValue >= CoolDown) {
            coolDownValue = 0;
            GameObject bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawnPoint.position, transform.rotation * Quaternion.Euler(0, 90, 0));
        } else if(coolDownValue < CoolDown) {
            coolDownValue += 1;
        }

    }
}
