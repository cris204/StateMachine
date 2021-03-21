using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStateFinishedBuildCristian : ItemStateBaseCristian
{
    public override void StateInit(ItemControllerCristian item)
    {
        item.SetStateText("Built");
        item.SetSpriteColor(Color.green);
    }

    public override void OnClickAction(ItemControllerCristian item)
    {
        Debug.LogError("Finish build click state");
    }

    public override void UpdateState(ItemControllerCristian item)
    {
        if (Input.GetKeyDown(KeyCode.X)) {
            item.DeconstructItem();
        }
    }
}
