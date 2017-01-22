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
}
