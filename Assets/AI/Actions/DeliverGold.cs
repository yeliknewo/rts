using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class DeliverGold : RAINAction
{
	public override void Start(RAIN.Core.AI ai)
	{
		base.Start(ai);
	}

	public override ActionResult Execute(RAIN.Core.AI ai)
	{
		if(ai.WorkingMemory.ItemExists(Consts.BASE_FORM))
		{
			ai.WorkingMemory.SetItem<bool>(Consts.HAS_GOLD, false);
			ai.WorkingMemory.GetItem<GameObject>(Consts.BASE_FORM).GetComponent<BaseController>().AddGold(1);
			return ActionResult.SUCCESS;
		} else
		{
			return ActionResult.FAILURE;
		}
	}

	public override void Stop(RAIN.Core.AI ai)
	{
		base.Stop(ai);
	}
}