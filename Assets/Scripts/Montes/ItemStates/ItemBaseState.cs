using UnityEngine;

public abstract class ItemBaseState
{
    public abstract void EnterState(ItemController item);

    public abstract void Update(ItemController item);

    public abstract void OnClick(ItemController item);
}
