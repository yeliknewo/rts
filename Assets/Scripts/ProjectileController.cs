using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ProjectileController : MonoBehaviour {
	private float timer = 0f;
	private float range = 1f;

	void Update () {
		this.timer += Time.deltaTime;

		if (this.timer > this.range) {
			Destroy (gameObject);
		}
	}

	public void SetRange(float range) {
		this.range = range;
	}
}
