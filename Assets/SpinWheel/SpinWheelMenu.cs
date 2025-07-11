using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpinWheelMenu : MonoBehaviour
{
    [SerializeField]
    private SpinWheelController spinWheelController;

    [SerializeField]
    private ZoneController zoneController;

    [SerializeField]
    private ZoneListWrapper zoneList;

    [SerializeField, HideInInspector]
    private Button retireBtn;

    private void OnValidate()
    {
        retireBtn = GetComponentInChildren<Button>();
    }

    private void OnEnable()
    {
        zoneController.OnZoneSelected += ZoneSelected;
        spinWheelController.OnReward += OnRewarded;
        retireBtn.onClick.AddListener(Retire);
    }

    private void OnDisable()
    {
        zoneController.OnZoneSelected -= ZoneSelected;
        spinWheelController.OnReward -= OnRewarded;
        retireBtn.onClick.RemoveListener(Retire);
    }

    private void Start()
    {
        StartGame();
    }

    private void ZoneSelected(int zoneIndex)
    {
        spinWheelController.SetupController(zoneList.GetZoneInfo(zoneIndex));
    }

    private void OnRewarded(int rewardedIndex)
    {
        zoneController.ZoneRewarded(rewardedIndex);
    }

    private void StartGame()
    {
        zoneController.SetupController(zoneList); // When setup, zone controller raises OnZoneSelected event. This script will trigger spinWheelController setup afterwards.
    }

    private void RestartGame()
    {
        spinWheelController.ResetController();
        zoneController.ResetController();
        zoneController.SetupController(zoneList);
    }

    private void Retire()
    {
        if (!spinWheelController.IsSpinning && (zoneList.GetZoneType(zoneController.GetCurrentZoneIndex()) != ZoneType.NORMAL)) // Retirement condition.
            RestartGame();

        // Else we can show a popup that informs the user why they can't retire.
    }
}
