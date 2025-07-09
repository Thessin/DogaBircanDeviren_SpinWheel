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

    private List<ZoneButton> instantiatedBtns = new List<ZoneButton>();

    public void SetupZones(ZoneListWrapper zoneList, Action<int> OnBtnClicked)
    {
        for (int i = 0; i < zoneList.GetZoneListCount(); i++)
        {
            ZoneButton btn = Instantiate(btnGO, zoneBtnParent);
            btn.SetupBtn(i, zoneList.GetZoneType(i));
            btn.OnClicked += OnBtnClicked;
            instantiatedBtns.Add(btn);
        }
    }
}
