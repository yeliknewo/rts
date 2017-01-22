using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyController : MonoBehaviour
{
	public float walkSpeed = 10f;

	public Vector3 target = Vector3.zero;

	protected PlayerController player
	{
		get
		{
			return Object.FindObjectOfType<PlayerController>();
		}
	}

	protected Rigidbody rigid
	{
		get
		{
			return GetComponent<Rigidbody>();
		}
	}

	protected void Update()
	{
		float theta = Mathf.Atan2(target.x - transform.position.x, target.z - transform.position.z);

		float xAxis = Mathf.Sin(theta);
		float zAxis = Mathf.Cos(theta);

		rigid.velocity = Utils.UseDrag(rigid.velocity, Mathf.Abs(xAxis) < Mathf.Abs(rigid.velocity.x / walkSpeed), Mathf.Abs(zAxis) < Mathf.Abs(rigid.velocity.z / walkSpeed), 2f);

		rigid.AddForce(new Vector3(
			Utils.GetSpeed(xAxis, rigid.velocity.x, walkSpeed),
			0,
			Utils.GetSpeed(zAxis, rigid.velocity.z, walkSpeed)
		), ForceMode.Acceleration);
	}
}
