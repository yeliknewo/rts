using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class RememberPlayerLocation : RAINAction
{


	public override void Start(RAIN.Core.AI ai)
    {
        base.Start(ai);
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
		if(ai.WorkingMemory.ItemExists(Consts.PLAYER_FORM))
		{
			GameObject player = ai.WorkingMemory.GetItem<GameObject>(Consts.PLAYER_FORM);
			ai.WorkingMemory.SetItem<Vector3>(Consts.PLAYER_LOCATION, player.transform.position);
		}
        return ActionResult.SUCCESS;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}

