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
    }

    private void OnDisable()
    {
        spinBtn.onClick.RemoveListener(OnSpinBtnClicked);
    }

    private void OnSpinBtnClicked()
    {
        int spinCount = model.currentZone.GetRandomSpinCount();

        view.SpinTheWheel(spinCount * 45.0f);

        RewardInfo reward = model.currentZone.rewards[spinCount % 8];
    }

    private void GiveReward(RewardInfo reward)
    {
        model.AddReward(reward);
    }
}
