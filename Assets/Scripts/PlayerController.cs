using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : Hero
{
	public GameObject prefabProjectile;

	public float agility;

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
		agility = attributes[Attributes.Agility];

		timer += Time.deltaTime;
		if (timer > 1f)
		{
			attributes[Attributes.Agility] += 1;
			timer = 0f;
		}

		float walkSpeedValue = walkSpeed.getCalculatedValue(attributes);

		float xAxis = Input.GetAxis(InputManager.AXIS_X);
		float zAxis = Input.GetAxis(InputManager.AXIS_Y);

		rigid.velocity = Utils.UseDrag(rigid.velocity, Mathf.Abs(xAxis) < Mathf.Abs(rigid.velocity.x / walkSpeedValue), Mathf.Abs(zAxis) < Mathf.Abs(rigid.velocity.z / walkSpeedValue), walkSpeedDrag.getCalculatedValue(attributes));

		rigid.AddForce(new Vector3(
			Utils.GetSpeed(xAxis, rigid.velocity.x, walkSpeedValue),
			0,
			Utils.GetSpeed(zAxis, rigid.velocity.z, walkSpeedValue)
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
