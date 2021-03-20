using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public LayerMask raycastLayerMask;
    private RaycastHit2D hit;

    public ItemController currentItem;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(currentItem != null)
            {
                currentItem.CurrentState.OnClick(currentItem);
            }
        }
    }

    private void FixedUpdate()
    {
        hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 100, raycastLayerMask);

        if (hit.collider != null)
        {
            if (hit.collider.tag == "Item")
            {
                currentItem = hit.transform.gameObject.GetComponent<ItemController>();
                currentItem.isSelected = true;
            }
        }
        else
        {
            if (currentItem != null){
                currentItem.isSelected = false;
                currentItem = null;
            }
        }
    }
}
