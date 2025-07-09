using UnityEngine;
using UnityEngine.AddressableAssets;

[System.Serializable]
public class RewardInfo
{
    [SerializeField]
    private RewardSO rewardSO;
    
    public int rewardMultiplier;

    public string GetRewardMultiplierTxt()
    {
        return (rewardMultiplier / 1000).ToString("D") + "K";
    }

    public int GetRewardId() => rewardSO.rewardId;
    public AssetReferenceSprite GetRewardImgRef() => rewardSO.rewardImgRef;
    public RewardType GetRewardType() => rewardSO.rewardType;
}
