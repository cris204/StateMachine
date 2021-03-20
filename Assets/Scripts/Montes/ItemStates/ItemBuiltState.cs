using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBuiltState : ItemBaseState
{
    public override void EnterState(ItemController item)
    {
        item.SetCurrentStateText("Built");
        item.SetColor(Color.white);
    }

    public override void OnClick(ItemController item)
    {
        
    }

    public override void Update(ItemController item)
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (item.isSelected)
            {
                item.StartDestroyingTime();
                item.SetColor(Color.red);
            }
        }
    }
}
