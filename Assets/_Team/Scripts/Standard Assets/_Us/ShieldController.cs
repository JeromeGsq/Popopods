using UnityEngine;
using System.Collections;
using Rewired;

public class ShieldController : MonoBehaviour {
	public int playerId = 0;
	private Player player;

	void Awake() {
		player = ReInput.players.GetPlayer(int.Parse(transform.root.name.Replace("Machine ", "")));
	}

	void Update () {
		if (player.GetButton("B") && transform.localScale.x < 6) {
			transform.localScale = transform.localScale * 1.2f;
		} else if(!player.GetButton("B") && transform.localScale.x > 0.1f) {
			transform.localScale = transform.localScale * 0.9f;
		}
	}

	void OnTriggerEnter(Collider coll) {
		if (coll.CompareTag("Bullet")) {
			Debug.Log("Bloqué");
			coll.GetComponent<BulletFire>().DestroyThis();
		}
	}
}
