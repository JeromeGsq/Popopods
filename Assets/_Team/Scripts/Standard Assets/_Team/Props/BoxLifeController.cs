using UnityEngine;
using System.Collections;

public class BoxLifeController : MonoBehaviour {

	public GameObject LifeUpPrefab;

	void OnTriggerEnter(Collider coll) {
		if (coll.CompareTag("Machine")) {
			coll.transform.root.GetComponentInChildren<RobotLifeManager>().Life += 30;
			Instantiate(LifeUpPrefab, transform.position, LifeUpPrefab.transform.rotation);
			Destroy(gameObject);
		}
	}

}
