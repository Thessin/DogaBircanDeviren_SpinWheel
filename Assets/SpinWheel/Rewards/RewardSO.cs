using UnityEngine;
using UnityEngine.AddressableAssets;

[CreateAssetMenu]
public class RewardSO : ScriptableObject
{
    [SerializeField]
    private int rewardId;
    [SerializeField]
    private AssetReferenceSprite rewardImgRef;
    [SerializeField]
    private RewardType rewardType;

    public int GetRewardId() => rewardId;
    public AssetReferenceSprite GetRewardImgRef() => rewardImgRef;
    public RewardType GetRewardType() => rewardType;
}

public enum RewardType
{
    NORMAL,
    SPECIAL,
    BOMB
}
