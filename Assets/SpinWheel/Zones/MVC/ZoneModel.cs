using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneModel
{
    public int CurrentZoneIndex { get; private set; }

    public int SelectedZoneIndex { get; private set; }

    public ZoneModel(int currentZoneIndex)
    {
        CurrentZoneIndex = currentZoneIndex;
        SelectedZoneIndex = currentZoneIndex;
    }

    public void ZoneSpun()
    {
        CurrentZoneIndex++;
        SelectedZoneIndex = CurrentZoneIndex;
    }

    public void ZoneSelected(int zoneIndex)
    {
        SelectedZoneIndex = zoneIndex;
    }

    public void ResetModel()
    {
        CurrentZoneIndex = 0;
        SelectedZoneIndex = 0;
    }
}
