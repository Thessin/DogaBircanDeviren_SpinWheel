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

        if (instantiatedBtns == null)
            instantiatedBtns = new ZoneButton[zoneListCount];

        for (int i = 0; i < zoneListCount; i++)
        {
            ZoneButton btn;
            if (instantiatedBtns[i] == null)
            {
                btn = Instantiate(btnGO, zoneBtnParent);
                btn.gameObject.name += ("_" + i);
                instantiatedBtns[i] = btn;
            }
            else
                btn = instantiatedBtns[i];

            btn.SetupBtn(i, zoneList.GetZoneType(i));
            btn.OnClicked -= ButtonClicked;
            btn.OnClicked += ButtonClicked;
        }
    }

    private void ButtonClicked(int clickedIndex)
    {
        OnBtnClicked?.Invoke(clickedIndex);
    }

    public void ZoneSelected(ZoneModel model)
    {
        foreach(ZoneButton btn in instantiatedBtns)
        {
            btn.ZoneBtnState.ZoneSelected(model);
        }
    }

    public void ZoneRewarded(ZoneModel model)
    {
        foreach (ZoneButton btn in instantiatedBtns)
        {
            btn.ZoneBtnState.ZoneRewarded(model);
        }
    }
}
