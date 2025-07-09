using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpinWheelController : MonoBehaviour
{
    [SerializeField]
    private SpinWheelView view;

    private SpinWheelModel model;

    [SerializeField, HideInInspector]
    private Button spinBtn;

    private void OnValidate()
    {
        spinBtn = GetComponentInChildren<Button>();
    }

    private void OnEnable()
    {
        spinBtn.onClick.AddListener(OnSpinBtnClicked);
        view.OnSpinRotateComplete += GiveReward;
    }

    private void OnDisable()
    {
        spinBtn.onClick.RemoveListener(OnSpinBtnClicked);
        view.OnSpinRotateComplete -= GiveReward;
    }

    public void SetupController(ZoneInfo zoneInfo)
    {
        model.currentZone = zoneInfo;
        view.SetupWheel(model);
    }

    private void OnSpinBtnClicked()
    {
        int spinCount = model.currentZone.GetRandomSpinCount();

        // Since spin count changes with every call, we need to send the reference of the reward to the chosen object and listen back.
        view.SpinTheWheel(spinCount * 45.0f, model.currentZone.GetReward(spinCount % 8));

        // SpinBtn needs to be locked during spinning.
        spinBtn.interactable = false;
    }

    private void GiveReward(RewardInfo reward)
    {
        switch (reward.GetRewardType())
        {
            case RewardType.BOMB:
                model.ResetModel();
                // TODO: Restart the game / Open the continue system. 
                break;
            default:
                model.AddReward(reward);
                break;
        }
    }
}
