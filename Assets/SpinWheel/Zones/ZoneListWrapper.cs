using UnityEngine;

[System.Serializable]
public class ZoneListWrapper
{
    [SerializeField]
    private ZoneListSO zoneListSO;

    public int GetZoneListCount() => zoneListSO.zoneInfoList.Count;

    public ZoneType GetZoneType(int zoneNum) => zoneListSO.zoneInfoList[zoneNum].zoneType;

    public ZoneInfo GetZoneInfo(int zoneNum) => zoneListSO.zoneInfoList[zoneNum];
}
