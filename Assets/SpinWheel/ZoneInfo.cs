using System;

[Serializable]
public class ZoneInfo
{
    public RewardSO[] rewards;
    public ZoneType zoneType;
}

public enum ZoneType
{
    NORMAL,
    SAFE,
    SUPER
}
