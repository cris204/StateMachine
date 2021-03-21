using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemStateBaseCristian
{
    public string stateId;
    public abstract void StateInit(ItemControllerCristian item);
    public abstract void UpdateState(ItemControllerCristian item);
    public abstract void OnClickAction(ItemControllerCristian item);

}
