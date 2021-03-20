using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPlacingState : ItemBaseState
{
    private Vector2 inputDirection;
    private Vector3 mousePos;

    public override void EnterState(ItemController item)
    {
        item.SetCurrentStateText("Placing");
        item.SetColor(Color.green);
    }

    public override void OnClick(ItemController item)
    {
        item.TransitionToState(item.BuildingState);
    }

    public override void Update(ItemController item)
    {
        this.mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        this.mousePos.z = 0;
        this.inputDirection = mousePos;
        item.transform.position = inputDirection;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            item.TransitionToState(item.IdleState);
        }
    }
}
