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
            ZoneInfo infoObj = zoneInfoList[i];

            if ((i + 1) % 30 == 0 && i != 0)
            {
                zoneType = ZoneType.SUPER;
            }
            else if ((i + 1) % 5 == 0 || i == 0)
            {
                zoneType = ZoneType.SAFE;
            }
            else
            {
                zoneType = ZoneType.NORMAL;
            }

            // Setting zone types with needed values.
            infoObj.zoneType = zoneType;

            // Setting zone index.
            infoObj.zoneIndex = i;

            // Give warning about missing/surplus rewards.
            if (infoObj.GetRewardCount() != 8)
            {
                Debug.LogWarning("Zone info " + i + "th element doesn't have 8 rewards.");
            }
        }

        CreateTestList(35);
    }

#if UNITY_EDITOR
    /// <summary>
    /// Only to be used in the editor. For testing purposes only.
    /// </summary>
    /// <param name="zoneCount"></param>
    private void CreateTestList(int zoneCount)
    {
        if (zoneInfoList == null)
            zoneInfoList = new List<ZoneInfo>();

        for (int i = zoneInfoList.Count; i < zoneCount; i++)
        {
            ZoneInfo infoObj = new ZoneInfo();
            infoObj.SetRandomRewards(i);
            zoneInfoList.Add(infoObj);
        }
    }
#endif
}
