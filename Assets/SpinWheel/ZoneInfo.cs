using System;
using UnityEngine;

[Serializable]
public class ZoneInfo
{
    public RewardInfo[] rewards;
    [HideInInspector]
    public ZoneType zoneType;
}

public enum ZoneType
{
    NORMAL,
    SAFE,
    SUPER
}
