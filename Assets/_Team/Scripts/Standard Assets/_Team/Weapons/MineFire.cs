using UnityEngine;
using System.Collections;
using Rewired;

public class MineFire : MonoBehaviour {

	public int PlayerId = 0;
	private Player player;

	public GameObject MinePrefab;
	public Transform MineSpawnPoint;

	public float CoolDown;
	private float coolDownValue;

	void Awake() {

		coolDownValue = CoolDown;
		player = ReInput.players.GetPlayer(int.Parse(transform.root.name.Replace("Machine ", "")));
	}

	void Update() {
		Fire();
	}

	void Fire() {
		if (player.GetButton("Y") && coolDownValue >= CoolDown) {
			coolDownValue = 0;
			GameObject mine = (GameObject) Instantiate(MinePrefab, MineSpawnPoint.position, Quaternion.Euler(0, 0, 0));
			mine.GetComponent<MineController>().player = PlayerId;
		} else if (coolDownValue < CoolDown) {
			coolDownValue += 1;
		}

	}
}
