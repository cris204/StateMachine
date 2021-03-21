using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStateIdleCristian : ItemStateBaseCristian
{
    public override void StateInit(ItemControllerCristian item)
    {
        item.SetSpriteColor(Color.gray);
    }

    public override void OnClickAction(ItemControllerCristian item)
    {
        item.SetNewState(item.PlacingState);
    }

    public override void UpdateState(ItemControllerCristian item)
    {
    }
}
