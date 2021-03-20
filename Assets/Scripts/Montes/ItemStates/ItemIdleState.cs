using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemIdleState : ItemBaseState
{
    public override void EnterState(ItemController item)
    {
        item.SetCurrentStateText("Idle");
        item.SetColor(Color.white);
        //item.transform.position = Vector3.zero;
    }

    public override void OnClick(ItemController item)
    {
        item.TransitionToState(item.PlacingState);
    }

    public override void Update(ItemController item)
    {
        
    }

}
