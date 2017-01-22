using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils
{
	public static float GetSpeed(float axis, float velocity, float walkSpeed)
	{
		if (velocity < 0)
		{
			if (axis < 0)
			{
				return Mathf.Abs(walkSpeed + velocity) * axis;
			}
			else
			{
				return Mathf.Abs(walkSpeed - velocity) * axis;
			}
		}
		else
		{
			if (axis < 0)
			{
				return Mathf.Abs(walkSpeed + velocity) * axis;
			}
			else
			{
				return Mathf.Abs(walkSpeed - velocity) * axis;
			}
		}
	}

	public static float GetDrag(float drag)
	{
		return 1f - drag * Time.fixedDeltaTime;
	}

	public static Vector3 UseDrag(Vector3 vector, bool x, bool z, float drag)
	{
		drag = Utils.GetDrag(drag);
		if (x)
		{
			if (z)
			{
				return vector * drag;
			}
			else
			{
				return new Vector3(vector.x * drag, 0, vector.z);
			}
		}
		else
		{
			if (z)
			{
				return new Vector3(vector.x, 0, vector.z * drag);
			}
			else
			{
				return vector;
			}
		}
	}
}
