using UnityEngine;
using UnityEngine.AddressableAssets;

[CreateAssetMenu]
public class RewardSO : ScriptableObject
{
    public int rewardId;
    public AssetReferenceSprite rewardImgRef;
    public RewardType rewardType;
}

public enum RewardType
{
    NORMAL,
    SPECIAL,
    BOMB
}
