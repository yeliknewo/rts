using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class RandomWanderTarget : RAINAction
{
	public override void Start(RAIN.Core.AI ai)
	{
		base.Start(ai);
	}

	public override ActionResult Execute(RAIN.Core.AI ai)
	{
		MapGenerator map = Object.FindObjectOfType<MapGenerator>();
		ai.WorkingMemory.SetItem<Vector3>(Consts.WANDER_TARGET, new Vector3(Random.Range(map.min.x, map.max.x), 0, Random.Range(map.min.z, map.max.z)));
		return ActionResult.SUCCESS;
	}

	public override void Stop(RAIN.Core.AI ai)
	{
		base.Stop(ai);
	}
}