using UnityEngine;
using System.Collections;

public class RobotLifeManager : MonoBehaviour {


	public float Life;
	public TextMesh LifeText;

	[Space(20)]

	public GameObject ExplosionPrefab;


	void Start () {
		LifeText.text = Life + "";
	}


	void OnTriggerEnter(Collider coll) {
		if (coll.CompareTag("Bullet")) {
			Debug.Log("Touché");
			Life -= coll.GetComponent<BulletFire>().Damage;
			coll.GetComponent<BulletFire>().DestroyThis();
		}
	}


	void Update () {
		LifeText.text = Life + "";

		if (Life <= 0) {
			Instantiate(ExplosionPrefab, transform.position, transform.rotation);
			transform.root.gameObject.SetActive(false);
		}
	}
}
