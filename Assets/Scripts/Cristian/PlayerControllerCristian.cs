using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerCristian : MonoBehaviour
{
    public LayerMask itemLayerMask;
    public RaycastHit2D hit;
    public ItemControllerCristian item;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            if (item != null) {
                item.CurrentState.OnClickAction(item);
            }
        }
    }

    private void FixedUpdate()
    {
        hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 100, itemLayerMask);
        if (hit) {
            item = hit.transform.GetComponent<ItemControllerCristian>();
            item.wasSelected = true;
        } else if (item != null && item.wasSelected) {
            item.wasSelected = false;
            item = null;
        }
        Debug.DrawRay(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Color.red);
    }

}
