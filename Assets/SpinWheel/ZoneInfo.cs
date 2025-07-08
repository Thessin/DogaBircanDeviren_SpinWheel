using System;
using UnityEngine;

[Serializable]
public class ZoneInfo
{
    public RewardInfo[] rewards;
    [HideInInspector]
    public ZoneType zoneType;
    [Tooltip("Each spin count will rotate the wheel by 45 degrees. Randomly generates a value between given min/max values."), SerializeField]
    private int spinCountMin, spinCountMax;

    public int GetRandomSpinCount()
    {
        return UnityEngine.Random.Range(spinCountMin, spinCountMax);
    }
}

public enum ZoneType
{
    NORMAL,
    SAFE,
    SUPER
}
