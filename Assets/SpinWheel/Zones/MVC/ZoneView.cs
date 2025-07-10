using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneView : MonoBehaviour
{
    [SerializeField]
    private ZoneButton btnGO;

    [SerializeField]
    private Transform zoneBtnParent;

    private ZoneButton[] instantiatedBtns;

    public event Action<int> OnBtnClicked;

    private void OnDestroy()
    {
        OnBtnClicked = null;
    }

    public void SetupZones(ZoneListWrapper zoneList)
    {
        int zoneListCount = zoneList.GetZoneListCount();

        instantiatedBtns = new ZoneButton[zoneListCount];

        for (int i = 0; i < zoneList.GetZoneListCount(); i++)
        {
            ZoneButton btn = Instantiate(btnGO, zoneBtnParent);
            btn.SetupBtn(i, zoneList.GetZoneType(i));
            btn.OnClicked -= OnButtonClicked;
            btn.OnClicked += OnButtonClicked;
            instantiatedBtns[i] = btn;
        }
    }

    private void OnButtonClicked(int clickedIndex)
    {
        // Need to send every zone button which one is chosen so they can decide on their states.
        foreach (ZoneButton btn in instantiatedBtns)
        {
            btn.ZoneBtnState.OnBtnClicked(clickedIndex);
        }

        OnBtnClicked?.Invoke(clickedIndex);
    }

    public void UpdateButtons(ZoneModel model)
    {

    }
}
