using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneController : MonoBehaviour
{
    [SerializeField]
    private ZoneView view;

    private ZoneModel model;

    public event Action<int> OnZoneSelected;

    public void SetupController(ZoneListWrapper zoneList)
    {
        view.SetupZones(zoneList, OnZoneSelected);
    }
}
