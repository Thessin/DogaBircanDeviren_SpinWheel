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
        if (model == null)
            model = new ZoneModel(0);

        view.SetupZones(zoneList);

        view.OnBtnClicked -= ZoneSelected;
        view.OnBtnClicked += ZoneSelected;

        // Should start as first zone selected.
        ZoneSelected(0);
    }

    private void ZoneSelected(int zoneIndex)
    {
        OnZoneSelected?.Invoke(zoneIndex);
        model.ZoneSelected(zoneIndex);
        view.ZoneSelected(model);
    }

    public void ZoneRewarded(int zoneIndex)
    {
        model.ZoneSpun();
        view.ZoneRewarded(model);
    }
}
