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

    private void OnDestroy()
    {
        OnZoneSelected = null;
    }

    public void SetupController(ZoneListWrapper zoneList)
    {
        view.SetupZones(zoneList);
        view.OnBtnClicked -= ZoneSelected;
        view.OnBtnClicked += ZoneSelected;
        if (model == null)
            model = new ZoneModel();

        model.zoneList = zoneList;

        // Should start as first zone selected.
        ZoneSelected(0);
    }

    private void ZoneSelected(int zoneIndex)
    {
        OnZoneSelected?.Invoke(zoneIndex);
        view.UpdateButtons(model);
    }
}
