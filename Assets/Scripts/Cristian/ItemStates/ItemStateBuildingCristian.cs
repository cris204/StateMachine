using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ItemStateBuildingCristian : ItemStateBaseCristian
{
    public override void StateInit(ItemControllerCristian item)
    {
        item.SetStateText("Building");
        item.SetSpriteColor(Color.yellow);
        item.StartBuildItem();
    }

    public override void OnClickAction(ItemControllerCristian item)
    {
    }

    public override void UpdateState(ItemControllerCristian item)
    {
    }


}
