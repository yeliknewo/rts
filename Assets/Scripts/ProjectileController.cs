using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ProjectileController : MonoBehaviour
{
	private float timer = 0f;
	private float range = 1f;

	private PlayerController player
	{
		get
		{
			return Object.FindObjectOfType<PlayerController>();
		}
	}

	void Update()
	{
		timer += Time.deltaTime;

		if (timer > range)
		{
			Destroy(gameObject);
		}
	}

	public void SetRange(float newRange)
	{
		range = newRange;
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
		{
			player.AddStat(collision.gameObject.GetComponent<EnemyType>().enemyType);
			Destroy(collision.gameObject);
			Destroy(gameObject);
		}
	}
}
