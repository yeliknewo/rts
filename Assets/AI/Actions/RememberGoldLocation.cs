using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class RememberGoldLocation : RAINAction
{


    public override void Start(RAIN.Core.AI ai)
    {
        base.Start(ai);
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
		GameObject gold = ai.WorkingMemory.GetItem<GameObject>(Consts.GOLD_FORM);
		ai.WorkingMemory.SetItem<Vector3>(Consts.GOLD_TARGET, gold.transform.position);
		return ActionResult.SUCCESS;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}