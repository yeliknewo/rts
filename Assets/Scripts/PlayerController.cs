using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : Hero
{
	public float xAxisMinThreshold = 0.1f;
	public float yAxisMinThreshold = 0.1f;

	public GameObject prefabProjectile;

	private float timer = 0f;

	private Rigidbody rigid
	{
		get
		{
			return this.GetComponent<Rigidbody>();
		}
	}

	void Update()
	{
		timer += Time.deltaTime;
		if (timer > 1f)
		{
			attributes[Attributes.Agility] += 1;
			timer = 0f;
		}

		float xAxis = Input.GetAxis(InputManager.AXIS_X);
		float yAxis = Input.GetAxis(InputManager.AXIS_Y);

		if (Mathf.Abs(xAxis) < xAxisMinThreshold)
		{
			rigid.AddForce(new Vector3(rigid.velocity.x * -8.0f, 0, 0), ForceMode.Acceleration);
		}

		if (Mathf.Abs(yAxis) < yAxisMinThreshold)
		{
			rigid.AddForce(new Vector3(0, 0, rigid.velocity.z * -8.0f), ForceMode.Acceleration);
		}

		rigid.AddForce(new Vector3(
			Utils.GetSpeed(xAxis, rigid.velocity.x, walkSpeed.getCalculatedValue(attributes)),
			0,
			Utils.GetSpeed(yAxis, rigid.velocity.z, walkSpeed.getCalculatedValue(attributes))
		), ForceMode.Acceleration);

		if (Input.GetMouseButton(InputManager.BUTTON_MOUSE_LEFT))
		{
			Shoot();
		}
	}

	void Shoot()
	{
		GameObject projectile = Instantiate<GameObject>(prefabProjectile, transform.position, transform.rotation, transform);
		projectile.GetComponent<Rigidbody>().velocity = rigid.velocity * projectileSpeed.getCalculatedValue(attributes);
		projectile.GetComponent<ProjectileController>().SetRange(range.getCalculatedValue(attributes));
	}
}
