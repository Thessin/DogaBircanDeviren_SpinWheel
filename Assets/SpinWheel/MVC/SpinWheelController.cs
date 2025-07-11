using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpinWheelController : MonoBehaviour
{
    [SerializeField]
    private SpinWheelView wheelView;

    [SerializeField]
    private InventoryView inventoryView;

    private SpinWheelModel model;

    [SerializeField, HideInInspector]
    private Button spinBtn;

    public event Action<int> OnReward;

    public bool IsSpinning { get; private set; } = false;

    private void OnValidate()
    {
        spinBtn = GetComponentInChildren<Button>();
    }

    private void OnDestroy()
    {
        OnReward = null;
    }

    private void OnEnable()
    {
        spinBtn.onClick.AddListener(OnSpinBtnClicked);
        wheelView.OnSpinRotateComplete += GiveReward;
    }

    private void OnDisable()
    {
        spinBtn.onClick.RemoveListener(OnSpinBtnClicked);
        wheelView.OnSpinRotateComplete -= GiveReward;
    }

    public void SetupController(ZoneInfo zoneInfo)
    {
        if (model == null)
            model = new SpinWheelModel();

        model.currentZone = zoneInfo;
        spinBtn.interactable = model.IsSpinnable();
        wheelView.SetupWheel(model);
    }

    private void OnSpinBtnClicked()
    {
        int spinCount = model.currentZone.GetRandomSpinCount();

        // Since spin count changes with every call, we need to send the reference of the reward to the chosen object and listen back.
        wheelView.SpinTheWheel(spinCount * 45.0f, model.currentZone.GetReward(spinCount % 8));
        IsSpinning = true;

        // SpinBtn needs to be locked during spinning.
        spinBtn.interactable = false;
    }

    private void GiveReward(RewardInfo reward)
    {
        switch (reward.GetRewardType())
        {
            case RewardType.BOMB:
                model.ResetModel();
                inventoryView.ResetView();
                // TODO: Restart the game / Open the continue system. 
                break;
            default:
                model.AddReward(reward);
                inventoryView.UpdateInventory(model);
                break;
        }

        OnReward?.Invoke(model.GetRewardedCount());
        IsSpinning = false;
    }

    public void ResetController()
    {
        model.ResetModel();
        spinBtn.interactable = false;
        inventoryView.ResetView();
    }
}
