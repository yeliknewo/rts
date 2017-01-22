using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyController : MonoBehaviour
{

	public float walkSpeed = 10f;

	private PlayerController player
	{
		get
		{
			return Object.FindObjectOfType<PlayerController>();
		}
	}

	private Rigidbody rigid
	{
		get
		{
			return GetComponent<Rigidbody>();
		}
	}

	void Update()
	{
		float theta = Mathf.Atan2(player.transform.position.x - transform.position.x, player.transform.position.z - transform.position.z);

		rigid.AddForce(new Vector3(
			Utils.GetSpeed(Mathf.Sin(theta), rigid.velocity.x, walkSpeed),
			0,
			Utils.GetSpeed(Mathf.Cos(theta), rigid.velocity.z, walkSpeed)
		), ForceMode.Acceleration);
	}
}
