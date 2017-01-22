using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeonController : EnemyController
{
	protected new void Update()
	{
		target = player.transform.position;
		base.Update();
	}
}
