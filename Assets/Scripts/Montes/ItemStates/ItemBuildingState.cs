using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBuildingState : ItemBaseState
{
    public override void EnterState(ItemController item)
    {
        item.SetCurrentStateText("Building");
        item.SetColor(Color.black);
        item.StartBuildingTime();
    }

    public override void OnClick(ItemController item)
    {
        
    }

    public override void Update(ItemController item)
    {
        
    }
}
