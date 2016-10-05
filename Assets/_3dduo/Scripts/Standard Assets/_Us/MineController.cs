using UnityEngine;
using System.Collections;

public class MineController :  MonoBehaviour {

	public SphereCollider sphereCollider;
	public GameObject sphere;
	public float ColliderSize;

	[Space(20)]

	public Light Light;
	public int player;

	[Space(20)]

	public GameObject ExplosionPrefab;
	public float Damage;

	void Awake() {
		sphereCollider.radius = 0;
		sphere.transform.localScale = Vector3.zero;
		StartCoroutine(EnableCollider());


	}

	void Start() {
		if (player == 0) {
			Light.color = Color.green;
		} else if (player == 1) {
			Light.color = Color.red;
		}
	}

	void OnTriggerEnter(Collider coll) {
		if (coll.CompareTag("Machine") && coll.transform.root.GetComponentInChildren<RobotController>().playerId != player) {
			coll.transform.root.GetComponentInChildren<RobotLifeManager>().Life -= Damage;
			Explosion();
		}
	}


	IEnumerator EnableCollider() {
		yield return new WaitForSeconds(1f);
		for (float i = 0; i < ColliderSize; i += 0.1f) {
			sphereCollider.radius = i;
			sphere.transform.localScale = new Vector3(i*2, 0.1f, i*2)  ;
			yield return 0;
		}
	}

	void Explosion() {
		Instantiate(ExplosionPrefab, transform.position, Quaternion.Euler(0, 0, 0));
		Destroy(gameObject);
	}


}
