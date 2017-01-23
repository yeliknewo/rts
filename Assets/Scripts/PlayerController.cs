using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : Hero
{
	public GameObject prefabProjectile;

	public float strength;
	public float agility;
	public float intelligence;

	public float accelerationMultiplier;

	private float lastShotTime;

	private Rigidbody rigid
	{
		get
		{
			return GetComponent<Rigidbody>();
		}
	}

	new private Camera camera
	{
		get
		{
			return Object.FindObjectOfType<Camera>();
		}
	}

	private void OnEnable()
	{
		SetupAttributes();
		RecalculateUI();
	}

	void Update()
	{
		strength = attributes[Attributes.Strength];
		agility = attributes[Attributes.Agility];
		intelligence = attributes[Attributes.Intelligence];

		float walkSpeedValue = walkSpeed.GetCalculatedValue(attributes);

		float xAxis = Input.GetAxis(InputManager.AXIS_X);
		float zAxis = Input.GetAxis(InputManager.AXIS_Y);

		rigid.velocity = Utils.UseDrag(rigid.velocity, Mathf.Abs(xAxis) < Mathf.Abs(rigid.velocity.x / walkSpeedValue), Mathf.Abs(zAxis) < Mathf.Abs(rigid.velocity.z / walkSpeedValue), walkSpeedDrag.GetCalculatedValue(attributes));

		rigid.AddForce(new Vector3(
			Utils.GetSpeed(xAxis, rigid.velocity.x, walkSpeedValue),
			0,
			Utils.GetSpeed(zAxis, rigid.velocity.z, walkSpeedValue)
		) * accelerationMultiplier, ForceMode.Acceleration);

		if (Input.GetMouseButton(InputManager.BUTTON_MOUSE_LEFT))
		{
			Shoot();
		}
	}

	void Shoot()
	{
		if (CanShoot())
		{
			GameObject projectile = Instantiate<GameObject>(prefabProjectile, transform.position, transform.rotation, transform);
			projectile.GetComponent<Rigidbody>().velocity = (camera.transform.position - transform.position) * projectileSpeed.GetCalculatedValue(attributes);
			projectile.GetComponent<ProjectileController>().SetRange(range.GetCalculatedValue(attributes));
			lastShotTime = Time.time;
		}
	}

	private bool CanShoot()
	{
		return lastShotTime < Time.time - this.shotCooldown.GetCalculatedValue(this.attributes);
	}

	public void AddStat(EnemyTypes enemyType)
	{
		if (enemyType == EnemyTypes.Chaser)
		{
			attributes[Attributes.Strength] += 1;
		}
		else if (enemyType == EnemyTypes.Peasant)
		{
			attributes[Attributes.Agility] += 1;
		}
		else if (enemyType == EnemyTypes.Base)
		{
			attributes[Attributes.Intelligence] += 1;
		}
		RecalculateUI();
	}

	public void RecalculateUI()
	{
		foreach (CanvasRenderer renderer in FindObjectsOfType<CanvasRenderer>())
		{
			UnityEngine.UI.Text text = renderer.GetComponent<UnityEngine.UI.Text>();
			if (text == null)
			{
				continue;
			}
			if (text.gameObject.name.Equals("StrengthUI"))
			{
				text.text = "Strength: " + attributes[Attributes.Strength];
			}
			else if (text.gameObject.name == "AgilityUI")
			{
				text.text = "Agility: " + attributes[Attributes.Agility];
			}
			else if (text.gameObject.name == "IntelligenceUI")
			{
				text.text = "Intelligence: " + attributes[Attributes.Intelligence];
			}
			else if (text.gameObject.name == "BaseUI")
			{
				text.text = "Base Count: " + Object.FindObjectsOfType<BaseController>().Length;
			}
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
		{
			Destroy(gameObject);
			Destroy(collision.gameObject);
			Application.Quit();
		}
	}
}
