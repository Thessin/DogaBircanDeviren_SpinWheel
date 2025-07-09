using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ZoneListSO : ScriptableObject
{
    public List<ZoneInfo> zoneInfoList;

    private void OnValidate()
    {
        ZoneType zoneType = ZoneType.NORMAL;
        for (int i = 0; i < zoneInfoList.Count; i++)
        {
            if (i % 30 == 0 && i != 0)
            {
                zoneType = ZoneType.SUPER;
            }
            else if (i % 5 == 0 && i != 0)
            {
                zoneType = ZoneType.SAFE;
            }
            else
            {
                zoneType = ZoneType.NORMAL;
            }

            // Setting zone types with needed values.
            zoneInfoList[i].zoneType = zoneType;

            // Give warning about missing/surplus rewards.
            if (zoneInfoList[i].GetRewardCount() != 8)
            {
                Debug.LogWarning("Zone info " + i + "th element doesn't have 8 rewards.");
            }
        }
    }
}
