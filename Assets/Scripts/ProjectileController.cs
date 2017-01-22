using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ProjectileController : MonoBehaviour
{
	private float timer = 0f;
	private float range = 1f;

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
}
