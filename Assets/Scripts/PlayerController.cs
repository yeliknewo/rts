using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {
	public float xAxisMinThreshold = 0.1f;
	public float yAxisMinThreshold = 0.1f;

	public int agilityStat = 0;

	public GameObject prefabProjectile;

	private float baseWalkSpeed = 10f;
	private float baseProjectileSpeed = 1.5f;
	private float baseRange = 1f;

	private float walkSpeedAgilityMult = 1f;
	private float projectileSpeedAgilityMult = 0.1f;
	private float rangeAgilityMult = 0.2f;

	private float timer = 0f;

	private float range {
		get {
			return baseRange + agilityStat * rangeAgilityMult;
		}
	}

	private float projectileSpeed {
		get {
			return baseProjectileSpeed + agilityStat * projectileSpeedAgilityMult;
		}
	}

	private float walkSpeed {
		get {
			return baseWalkSpeed + agilityStat * walkSpeedAgilityMult;
		}
	}

	private Rigidbody rigid {
		get {
			return this.GetComponent<Rigidbody> ();
		}
	}

	void Update () {
		timer += Time.deltaTime;
		if (timer > 1f) {
			agilityStat += 1;
			timer = 0f;
		}

		float xAxis = Input.GetAxis (InputManager.AXIS_X);
		float yAxis = Input.GetAxis (InputManager.AXIS_Y);

		if (Mathf.Abs (xAxis) < xAxisMinThreshold) {
			rigid.AddForce (new Vector3(rigid.velocity.x * -8.0f, 0, 0), ForceMode.Acceleration);
		}

		if (Mathf.Abs (yAxis) < yAxisMinThreshold) {
			rigid.AddForce (new Vector3(0, 0, rigid.velocity.z * -8.0f), ForceMode.Acceleration);
		}

		rigid.AddForce(new Vector3 (
			(this.walkSpeed - Mathf.Abs(rigid.velocity.x))*xAxis,
			0, 
			(this.walkSpeed - Mathf.Abs(rigid.velocity.z))*yAxis
		), ForceMode.Acceleration);

		if (Input.GetMouseButton (InputManager.BUTTON_MOUSE_LEFT)) {
			Shoot ();
		}
	}

	void Shoot() {
		GameObject projectile = Instantiate<GameObject> (prefabProjectile, transform.position, transform.rotation, transform);
		projectile.GetComponent<Rigidbody> ().velocity = rigid.velocity * this.projectileSpeed;
		projectile.GetComponent<ProjectileController>().SetRange(this.range);
	}
}
