using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

[Serializable]
public class ZoneInfo
{
    [HideInInspector]
    public int zoneIndex;
    [SerializeField] 
    private RewardInfo[] rewards;
    [HideInInspector]
    public ZoneType zoneType;
    [Tooltip("Each spin count will rotate the wheel by 45 degrees. Randomly generates a value between given min/max values."), SerializeField]
    private int spinCountMin, spinCountMax;

    public int GetRandomSpinCount()
    {
        return UnityEngine.Random.Range(spinCountMin, spinCountMax);
    }

    public RewardInfo GetReward(int rewardIndex) => rewards[rewardIndex];

    public int GetRewardCount() => rewards.Length;

#if UNITY_EDITOR
    /// <summary>
    /// Only to be used in the editor, for testing purposes.
    /// </summary>
    public void SetRandomRewards(int zoneIndex)
    {
        this.zoneIndex = zoneIndex;

        ZoneType chosenType = ZoneType.NORMAL;
        if ((zoneIndex + 1) % 30 == 0 && zoneIndex != 0)
        {
            chosenType = ZoneType.SUPER;
        }
        else if ((zoneIndex + 1) % 5 == 0 || zoneIndex == 0)
        {
            chosenType = ZoneType.SAFE;
        }
        else
        {
            chosenType = ZoneType.NORMAL;
        }

        // Setting zone types with needed values.
        zoneType = chosenType;

        spinCountMin = 24;
        spinCountMax = 32;

        rewards = new RewardInfo[8];

        string folderPath = "Assets/SpinWheel/Rewards/RewardObjects";

        string[] guids = AssetDatabase.FindAssets("t:ScriptableObject", new[] { folderPath });

        List<RewardSO> rewardAssets = new List<RewardSO>();

        foreach (string guid in guids)
        {
            string assetPath = AssetDatabase.GUIDToAssetPath(guid);

            rewardAssets.Add(AssetDatabase.LoadAssetAtPath<RewardSO>(assetPath));
        }

        // Randomize the reward assets list.
        rewardAssets = rewardAssets.OrderBy(x => UnityEngine.Random.value).ToList();
        int addedRewardCount = 0;
        foreach (RewardSO infoObj in rewardAssets)
        {
            if (zoneType != ZoneType.NORMAL && infoObj.rewardType == RewardType.BOMB)
                continue;
            else if (addedRewardCount >= 8)
                return;
            else
            {
                RewardInfo info = new RewardInfo();
                info.SetRewardSO(infoObj);
                info.rewardMultiplier = UnityEngine.Random.Range(20, 500000); // Randomly giving multiplier.
                rewards[addedRewardCount] = info;
                addedRewardCount++;
            }
        }
    }
#endif
}

public enum ZoneType
{
    NORMAL,
    SAFE,
    SUPER
}
