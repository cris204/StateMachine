using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemController : MonoBehaviour
{
    public TextMeshProUGUI currentStateText;
    public SpriteRenderer itemSprite;
    public Image timeImage;
    public float buildingTime;
    public float destroyingTime;
    public bool isSelected;

    private ItemBaseState currentState;

    public ItemBaseState CurrentState
    {
        get
        {
            return currentState;
        }
    }

    public readonly ItemIdleState IdleState = new ItemIdleState();
    public readonly ItemPlacingState PlacingState = new ItemPlacingState();
    public readonly ItemBuildingState BuildingState = new ItemBuildingState();
    public readonly ItemBuiltState BuiltState = new ItemBuiltState();

    // Start is called before the first frame update
    void Start()
    {
        TransitionToState(IdleState);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.Update(this);
    }

    public void TransitionToState(ItemBaseState state)
    {
        this.currentState = state;
        currentState.EnterState(this);
    }

    public void OnClick()
    {
        currentState.OnClick(this);
    }

    public void SetCurrentStateText(string text)
    {
        currentStateText.text = text;
    }

    public void SetColor(Color color)
    {
        itemSprite.color = color;
    }

    public void DestroyItem()
    {
        SetCurrentStateText("Destroyed");
        Destroy(this.gameObject);
    }

    public void StartBuildingTime()
    {
        timeImage.fillAmount = 0;
        timeImage.gameObject.SetActive(true);
        timeImage.color = Color.green;
        StartCoroutine(TimeCoroutine(buildingTime,true));
    }
    
    public void StartDestroyingTime()
    {
        timeImage.fillAmount = 0;
        timeImage.gameObject.SetActive(true);
        timeImage.color = Color.red;
        StartCoroutine(TimeCoroutine(destroyingTime, false));
    }

    IEnumerator TimeCoroutine(float time, bool isBuilding)
    {
        while (timeImage.fillAmount < 1)
        {
            timeImage.fillAmount += Time.deltaTime/time;
            yield return null;
        }
        timeImage.gameObject.SetActive(false);
        if (isBuilding)
        {
            TransitionToState(BuiltState);
        }
        else
        {
            DestroyItem();
        }
    }
}
