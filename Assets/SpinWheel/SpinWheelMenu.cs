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

    private void OnEnable()
    {
        zoneController.OnZoneSelected += ZoneSelected;
        spinWheelController.OnReward += OnRewarded;
    }

    private void OnDisable()
    {
        zoneController.OnZoneSelected -= ZoneSelected;
        spinWheelController.OnReward -= OnRewarded;
    }

    private void Awake()
    {
        zoneController.SetupController(zoneList);
    }

    private void ZoneSelected(int zoneIndex)
    {
        spinWheelController.SetupController(zoneList.GetZoneInfo(zoneIndex));
    }

    private void OnRewarded(int rewardedIndex)
    {
        zoneController.ZoneRewarded(rewardedIndex);
    }
}
