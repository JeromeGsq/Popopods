using UnityEngine;
using Rewired;

public class BulletFire : MonoBehaviour {


	[Space(20)]

	public Rigidbody rigidbody;

	public float PowerX;
	public float PowerY;

	public float RandomDirection;

	public float Damage;

	public GameObject ExplosionPrefab;


	void OnEnable () {
		rigidbody.AddForce(transform.forward * PowerX + new Vector3(0, PowerY, 0) + new Vector3(Random.Range(0, RandomDirection), Random.Range(0, RandomDirection), Random.Range(0, RandomDirection)), ForceMode.Impulse);
		transform.forward = rigidbody.velocity;
		Destroy(gameObject, 10);
	}

	void OnCollisionEnter(Collision coll) {
		Instantiate(ExplosionPrefab, transform.position, Quaternion.Euler(-90, -90, -90));
		Destroy(gameObject);
	}

	public void DestroyThis() {
		Damage = 0;
		Instantiate(ExplosionPrefab, transform.position, Quaternion.Euler(-90, -90, -90));
		Destroy(gameObject);
	}

	void Update() {
		transform.forward = rigidbody.velocity;
	}

}
