using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemControllerCristian : MonoBehaviour
{
    [Header("Player")]
    public PlayerControllerCristian player;

    public SpriteRenderer sprite;
    public TextMeshProUGUI stateText;
    public bool wasSelected;
    private ItemStateBaseCristian currentState;

    [Header("UI")]
    public GameObject canvasGO;
    public Image fillerImage;

    public ItemStateBaseCristian CurrentState
    {
        get
        {
            return currentState;
        }
    }

    public readonly ItemStateIdleCristian IdleState = new ItemStateIdleCristian();
    public readonly ItemStatePlacingCristian PlacingState = new ItemStatePlacingCristian();
    public readonly ItemStateBuildingCristian BuildingState = new ItemStateBuildingCristian();
    public readonly ItemStateFinishedBuildCristian FinishedBuildState = new ItemStateFinishedBuildCristian();

    [Header("general")]
    public float constructTime;
    public float deconstructTime;

    private void Start()
    {
        SetNewState(IdleState);
    }

    private void Update()
    {
        currentState.UpdateState(this);
    }

    public void SetSpriteColor(Color color)
    {
        sprite.color = color;
    }

    public void SetStateText(string text)
    {
        stateText.text = text;
    }
    public void SetNewState(ItemStateBaseCristian state)
    {
        this.currentState = state;
        currentState.StateInit(this);
    }

    public void StartBuildItem()
    {
        if (player.item !=null && player.item == this) {
            this.fillerImage.color = Color.green;
            StartCoroutine(TimeCoroutine(constructTime, true));
        }
    }
    public void DeconstructItem()
    {
        if (player.item != null && player.item == this) {
            this.fillerImage.color = Color.yellow;
            StartCoroutine(TimeCoroutine(deconstructTime, false));
        }
    }

    private IEnumerator TimeCoroutine(float time, bool isBuilding)
    {
        canvasGO.SetActive(true);
        this.fillerImage.fillAmount = 0;
        while (this.fillerImage.fillAmount < 1) {
            this.fillerImage.fillAmount += Time.deltaTime / time;
            yield return null;
        }
        if (isBuilding) {
            this.SetNewState(FinishedBuildState);
        } else {
            this.SetNewState(IdleState);
        }
        canvasGO.SetActive(false);
    }

}
