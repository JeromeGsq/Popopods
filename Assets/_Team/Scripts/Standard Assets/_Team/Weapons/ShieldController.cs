using UnityEngine;
using System.Collections;
using Rewired;

public class ShieldController : MonoBehaviour {
    private RobotController RobotController;

	private Player player;

	void Awake() {
        RobotController = transform.root.GetComponentInChildren<RobotController>();
        if(RobotController == null) {
            Debug.LogError("Impossible de trouver RobotController ! GameObject désactivé");
            gameObject.SetActive(false);
            return;
        }

        player = ReInput.players.GetPlayer(RobotController.RewiredPlayerId);
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
			coll.GetComponent<BulletFire>().DestroyThis();
		}
	}
}
