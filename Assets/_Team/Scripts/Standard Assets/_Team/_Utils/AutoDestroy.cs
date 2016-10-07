using UnityEngine;
using System.Collections;

public class AutoDestroy : MonoBehaviour {
	public float Time;

	void Start () {
		Destroy(gameObject, Time);
	}

}
