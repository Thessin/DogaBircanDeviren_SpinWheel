using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneView : MonoBehaviour
{
    [SerializeField]
    private ZoneButton btnGO;

    private List<ZoneButton> instantiatedBtns = new List<ZoneButton>();

    public void SetupZones(ZoneListWrapper zoneList, Action<int> OnBtnClicked)
    {
        for (int i = 0; zoneList.GetZoneListCount() > 0; i++)
        {
            ZoneButton btn = Instantiate(btnGO);
            btn.SetupBtn(i, zoneList.GetZoneType(i));
            btn.OnClicked += OnBtnClicked;
            instantiatedBtns.Add(btn);
        }
    }
}
