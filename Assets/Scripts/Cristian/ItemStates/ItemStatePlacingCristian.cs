using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStatePlacingCristian : ItemStateBaseCristian
{
    public Vector3 mousePosition;
    public override void StateInit(ItemControllerCristian item)
    {
        item.SetStateText("Placing");
        item.SetSpriteColor(Color.white);
    }

    public override void OnClickAction(ItemControllerCristian item)
    {
        item.SetNewState(item.BuildingState);
    }

    public override void UpdateState(ItemControllerCristian item)
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        item.transform.position = mousePosition;
    }
}
