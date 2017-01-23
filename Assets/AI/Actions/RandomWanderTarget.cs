using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class RandomWanderTarget : RAINAction
{
	public const string WANDER_TARGET = "wanderTarget";

    public override void Start(RAIN.Core.AI ai)
    {
        base.Start(ai);
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
		ai.WorkingMemory.SetItem<Vector3>(WANDER_TARGET, new Vector3(Random.Range(-255, 255), 0, Random.Range(-255, 255)));
        return ActionResult.SUCCESS;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}