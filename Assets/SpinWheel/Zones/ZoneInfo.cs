using System;
using UnityEngine;

[Serializable]
public class ZoneInfo
{
    [SerializeField]
    private int zoneIndex;
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

    public int GetZoneIndex() => zoneIndex;
}

public enum ZoneType
{
    NORMAL,
    SAFE,
    SUPER
}
