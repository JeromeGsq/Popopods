using UnityEngine;
using System.Collections;
using Rewired;

public class TurretController : MonoBehaviour {

	public int playerId = 0;
	private Player player;

	[Space(20)]

	public GameObject Turret;

	[Space(20)]

	public GameObject bulletPrefab;
	public Transform bulletSpawnPoint;

	[Space(20)]

	public float CoolDown;
	private float coolDownValue;

	void Awake() {
		player = ReInput.players.GetPlayer(int.Parse(transform.root.name.Replace("Machine ", "")));
        Debug.Log(player);
	}

	void Update() {
		//Fire();
		Rotate();
	}

	void Fire() {
		if (/*player.GetButtonDown("A")  &&*/ coolDownValue >= CoolDown) {
			coolDownValue = 0;
			GameObject bullet = (GameObject) Instantiate(bulletPrefab, bulletSpawnPoint.position, transform.rotation * Quaternion.Euler(0, 90, 0));
		} else if (coolDownValue < CoolDown) {
			coolDownValue += 1;
		}

	}

	void Rotate() {
		Vector3 vNewInput = new Vector3(player.GetAxis("Rotation X"), player.GetAxis("Rotation Y"), 0.0f);
		if (vNewInput.sqrMagnitude < 0.5f) {
			return;
		}
        Fire();

        var angle = Mathf.Atan2(player.GetAxis("Rotation X"), player.GetAxis("Rotation Y")) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(angle, 0, 0);

		Turret.transform.rotation = Quaternion.Euler(0, angle, 0) * Quaternion.Euler(0, -30, 0);
	}
}
