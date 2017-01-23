using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class RememberBaseLocation : RAINAction
{
    public override void Start(RAIN.Core.AI ai)
    {
        base.Start(ai);
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
		GameObject baseObj = ai.WorkingMemory.GetItem<GameObject>(Consts.BASE_FORM);
		ai.WorkingMemory.SetItem<Vector3>(Consts.BASE_TARGET, baseObj.transform.position);
		return ActionResult.SUCCESS;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}